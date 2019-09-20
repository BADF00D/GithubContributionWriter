using System;

namespace GithubContributionWriter.Gui.Model
{
    internal class Cell
    {
        public DateTimeOffset Timestamp { get; }
        public uint Contributions { get; }

        public Cell(DateTimeOffset timestamp, uint contributions)
        {
            Timestamp = timestamp;
            Contributions = contributions;
        }
    }

    internal class Row
    {
        public Cell[] Cells { get; }

        public Row(Cell[] cells)
        {
            Cells = cells;
        }
    }

    internal class Table
    {
        public Table(Row[] rows)
        {
            Rows = rows;
        }

        public Row[] Rows { get; }

    } 
}