using System;
using System.Collections.Generic;
using System.Linq;

namespace GithubContributionWriter.Core
{
    public class GithubContributionsWriter
    {
        //public void Write(DateTimeOffset startDate, )
    }

    public class GithubContributionsGrid
    {
        public int Weeks { get; }
        public int Days { get; } = 7;
        private readonly ContributionPerDate[,] _contributions;

        private GithubContributionsGrid(ContributionPerDate[,] contributions, int weeks)
        {
            Weeks = weeks;
            _contributions = contributions;
        }

        public ContributionPerDate this[int x, int y] => _contributions[x, y];


        public static GithubContributionsGrid CreateFakes(DateTimeOffset start, string text, Alphabet alphabet, uint count, int weeks)
        {
            if(start.DayOfWeek != 0) throw new ArgumentException();

            var contributions = new ContributionPerDate[weeks, 7];
            var currentDate = start;
            for (var x = 0; x < weeks; x++)
            {
                for (var y = 0; y < 7; y++)
                {
                    contributions[x,y] = new ContributionPerDate(currentDate);
                    currentDate = start.AddDays(1);
                }
            }

            var position = 0;
            foreach (var characters in text)
            {
                var key = characters.ToString().ToUpper();
                var character = alphabet[key];

                position = CopyTo(character, contributions, position, count);
            }

            return new GithubContributionsGrid(contributions, weeks);
        }

        private static int CopyTo(Character character, ContributionPerDate[,] contributions, int position, uint count)
        {
            for (var y = 0; y < character.Height; y++)
            {
                for (var x = 0; x < character.Width; x++)
                {
                    if (character[(byte) x, (byte) y])
                    {
                        contributions[x + position, y].Count = count;
                    }
                }
            }

            return position + character.Width + 1;
        }
    }

    public class ContributionPerDate
    {
        public DateTimeOffset Date { get; }
        public uint Count { get; set; }

        public ContributionPerDate(DateTimeOffset date)
        {
            Date = date;
        }
    }


    public class Alphabet
    {
        private readonly Dictionary<string, Character> _characters;

        private Character MissingCharacter = new Character(string.Empty, 3, 7, new bool[21]);

        public Character this[string key]
        {
            get
            {
                try
                {
                    return _characters[key];
                }
                catch (Exception)
                {
                    return MissingCharacter;
                }
            }
        }

        public Alphabet(IEnumerable<Character> characters)
        {
            var enumerable = characters.ToArray();
            _characters = enumerable.ToDictionary(c => c.Id);
        }

        public static Alphabet Default => new Alphabet(ParseAlphabet(DefaultAlphabet));

        public static IEnumerable<Character> ParseAlphabet(string[] source)
        {
            var rows = source.Select(s => s.ToCharArray())
                .ToArray();
            var position = 0;
            for (var y = 0; y < source.Length; y++)
            {
                for (var x = 0; x < rows[0].Length && position < rows[0].Length; x++)
                {
                    var id = rows[0][position].ToString();
                    var width = int.Parse(rows[1][position].ToString());
                    var height = int.Parse(rows[2][position].ToString());
                    var glyph = ExtractGlyphFrom(rows, position+1, width, height);
                    yield return new Character(id, width, height, glyph.ToArray());
                    position += width+2;
                }
            }
        }

        private static IEnumerable<bool> ExtractGlyphFrom(IReadOnlyList<char[]> rows, int position, int width, int height)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    yield return rows[y][position + x] == 'X';
                }
            }
        }

        private static readonly string[] DefaultAlphabet =
        {
            "AXXX BXX  CXXX DXX  EXXX FXXX GXXXX HX X IX JXXX KX  X LX   MX X X NX  X OXXX PXXX QXXX  RXXXX SXXX TXXX UX X VX X WX X X XX X YX X ZXXX 0XXX 1 X 2XXX 3XXX 4X   5XXX 6XXX 7XXX 8XXX 9XXX",
            "3X X 3X X 3X   3X X 3X   3X   4X    3X X 1X 3  X 4X X  3X   5XXXXX 4XX X 3X X 3X X 4X X  4X  X 3X   3 X  3X X 3X X 5X X X 3XXX 3X X 3  X 3X X 2XX 3  X 3  X 3X X 3X   3X   3  X 3X X 3X X",
            "6XXX 6XXX 6X   6X X 6XX  6XX  6X XX 6XXX 6X 6  X 6XX   6X   6XXXXX 6XXXX 6X X 6XXX 6X X  6XXXX 6XXX 6 X  6X X 6X X 6X X X 6 X  6XXX 6 X  6X X 6 X 6 X  6 XX 6XXX 6XXX 6XXX 6 X  6XXX 6XXX",
            " X X  X X  X    X X  X    X    X  X  X X  X    X  X X   X    X X X  X XX  X X  X    X X   X X     X   X   X X  X X  X X X  X X   X   X    X X   X  X      X    X    X  X X   X   X X    X",
            " X X  X X  X    X X  X    X    X  X  X X  X    X  X  X  X    X X X  X  X  X X  X    X X   X  X    X   X   X X  X X  X X X  X X   X   X    X X   X  X      X    X    X  X X   X   X X    X",
            " X X  XXX  XXX  XX   XXX  X    XXXX  X X  X  XX   X  X  XXX  X X X  X  X  XXX  X    XXXX  X  X  XXX   X   XXX   X   XXXXX  X X   X   XXX  XXX   X  XXX  XXX    X  XXX  XXX   X   XXX  XXX"
        };

    }

    public sealed class Character
    {
        private const int DaysPerWeek = 7;
        private const int WeeksPerYear = 52;
        public int Width { get; }
        public int Height { get; }
        public string Id { get; }

        private readonly bool[] _contributionCategory;

        public Character( string id, int width, int height, bool[] source)
        {
            if(width*height != source.Length)
                throw new ArgumentException("Expect source to be of correct size", nameof(source));
            if(height > DaysPerWeek || height < 1) throw new ArgumentOutOfRangeException(nameof(height), "Expect height to be in range [1,7]");
            if(width > WeeksPerYear || width < 1) throw new ArgumentOutOfRangeException(nameof(width), "Expect width to be in range [1,52]");
            Width = width;
            Height = height;
            Id = id;
            _contributionCategory = source.ToArray();
        }
        public bool this[byte x, byte y]
        {
            get
            {
                if(x >= Width) throw new ArgumentOutOfRangeException(nameof(x));
                if(y >= Height) throw new ArgumentOutOfRangeException(nameof(y));
                var index = y * Width + x;
                return _contributionCategory[index];
            }
        }
    }

    public enum ContributionCategory : byte
    {
        Zero,
        OneToThree,
        FourToSix,
        SevenToNine,
        TenAndMore
    }
}
