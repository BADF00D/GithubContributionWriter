using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using GithubContributionWriter.Core;
using GithubContributionWriter.Gui.Model;

namespace GithubContributionWriter.Gui.Extensions
{
    internal static class GithubContributionsGridExt
    {
        public static IEnumerable<Row> ToRows(this GithubContributionsGrid grid)
        {
            for (int day = 0; day < grid.Days; day++)
            {
                yield return new Row(grid.GetCells(day));
            }
        }

        public static string ToDebugString(this GithubContributionsGrid grid)
        {
            var sb = new StringBuilder(grid.Days * grid.Weeks);

            for (var y = 0; y < grid.Days; y++)
            {
                for (var x = 0; x < grid.Weeks; x++)
                {
                    var contributionPerDate = grid[x, y];
                    sb.Append(contributionPerDate.Count > 0 ? "X" : " ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static Cell[] GetCells(this GithubContributionsGrid grid, int row)
        {
            var cells = new List<Cell>(grid.Weeks);
            for (var week = 0; week < grid.Weeks; week++)
            {
                var contributionPerDate = grid[week, row];
                cells.Add(new Cell(contributionPerDate.Date, contributionPerDate.Count));
            }

            return cells.ToArray();
        }
    }
}