using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using GithubContributionWriter.Core;
using GithubContributionWriter.Gui.Extensions;
using GithubContributionWriter.Gui.Model;
using Reactive.Bindings;

namespace GithubContributionWriter.Gui
{
    internal interface IMainWindowsViewModel
    {
        ReactiveProperty<RowViewModel[]> GridItems { get; }
    }

    class MainWindowsDesignViewModel : IMainWindowsViewModel, IDisposable
    {
        public ReactiveProperty<RowViewModel[]> GridItems { get; }

        public MainWindowsDesignViewModel()
        {
            var dateTimeOffset = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(356));
            if (dateTimeOffset.DayOfWeek != DayOfWeek.Sunday)
            {
                dateTimeOffset = dateTimeOffset.Subtract(TimeSpan.FromDays((int) dateTimeOffset.DayOfWeek));
            }
            var fake = GithubContributionsGrid.CreateFakes(dateTimeOffset, "BADF00D",
                Alphabet.Default, 10, 52);
            var debugString = fake.ToDebugString();
            Debug.WriteLine(debugString);

            var rows = fake.ToRows().ToArray();
            GridItems = new ReactiveProperty<RowViewModel[]>();
            GridItems.Value = new []
            {
                new RowViewModel("",Observable.Return(rows[0])),
                new RowViewModel("",Observable.Return(rows[1])),
                new RowViewModel("",Observable.Return(rows[2])),
                new RowViewModel("",Observable.Return(rows[3])),
                new RowViewModel("",Observable.Return(rows[4])),
                new RowViewModel("",Observable.Return(rows[5])),
                new RowViewModel("",Observable.Return(rows[6])),
            };
        }

        private static Row CreateDummy(DateTimeOffset start)
        {
            return new Row(new []
            {
                new Cell(start.AddDays(0), 0), 
                new Cell(start.AddDays(7), 1), 
                new Cell(start.AddDays(14), 2), 
                new Cell(start.AddDays(21), 3), 
                new Cell(start.AddDays(28), 4), 
            });
        }

        public void Dispose()
        {
            GridItems?.Dispose();
        }
    }

    internal class RowViewModel : IDisposable
    {
        public string RowName { get; }
        public CellViewModel Column0 { get; }
        public CellViewModel Column1 { get; }
        public CellViewModel Column2 { get; }
        public CellViewModel Column3 { get; }
        public CellViewModel Column4 { get; }
        public CellViewModel Column5 { get; }
        public CellViewModel Column6 { get; }
        public CellViewModel Column7 { get; }
        public CellViewModel Column8 { get; }
        public CellViewModel Column9 { get; }
        public CellViewModel Column10 { get; }
        public CellViewModel Column11 { get; }
        public CellViewModel Column12 { get; }
        public CellViewModel Column13 { get; }
        public CellViewModel Column14 { get; }
        public CellViewModel Column15 { get; }
        public CellViewModel Column16 { get; }
        public CellViewModel Column17 { get; }
        public CellViewModel Column18 { get; }
        public CellViewModel Column19 { get; }
        public CellViewModel Column20 { get; }
        public CellViewModel Column21 { get; }
        public CellViewModel Column22 { get; }
        public CellViewModel Column23 { get; }
        public CellViewModel Column24 { get; }
        public CellViewModel Column25 { get; }
        public CellViewModel Column26 { get; }
        public CellViewModel Column27 { get; }
        public CellViewModel Column28 { get; }
        public CellViewModel Column29 { get; }

        public RowViewModel(string rowName, IObservable<Row> rowStream)
        {
            RowName = rowName;
            Column0 = new CellViewModel(rowStream.Select(rows => rows.Cells[0]));
            Column1 = new CellViewModel(rowStream.Select(rows => rows.Cells[1]));
            Column2 = new CellViewModel(rowStream.Select(rows => rows.Cells[2]));
            Column3 = new CellViewModel(rowStream.Select(rows => rows.Cells[3]));
            Column4 = new CellViewModel(rowStream.Select(rows => rows.Cells[4]));
            Column5 = new CellViewModel(rowStream.Select(rows => rows.Cells[5]));
            Column6 = new CellViewModel(rowStream.Select(rows => rows.Cells[6]));
            Column7 = new CellViewModel(rowStream.Select(rows => rows.Cells[7]));
            Column8 = new CellViewModel(rowStream.Select(rows => rows.Cells[8]));
            Column9 = new CellViewModel(rowStream.Select(rows => rows.Cells[9]));
            Column10 = new CellViewModel(rowStream.Select(rows => rows.Cells[10]));
            Column11 = new CellViewModel(rowStream.Select(rows => rows.Cells[11]));
            Column12 = new CellViewModel(rowStream.Select(rows => rows.Cells[12]));
            Column13 = new CellViewModel(rowStream.Select(rows => rows.Cells[13]));
            Column14 = new CellViewModel(rowStream.Select(rows => rows.Cells[14]));
            Column15 = new CellViewModel(rowStream.Select(rows => rows.Cells[15]));
            Column16 = new CellViewModel(rowStream.Select(rows => rows.Cells[16]));
            Column17 = new CellViewModel(rowStream.Select(rows => rows.Cells[17]));
            Column18 = new CellViewModel(rowStream.Select(rows => rows.Cells[18]));
            Column19 = new CellViewModel(rowStream.Select(rows => rows.Cells[19]));
            Column20 = new CellViewModel(rowStream.Select(rows => rows.Cells[20]));
            Column21 = new CellViewModel(rowStream.Select(rows => rows.Cells[21]));
            Column22 = new CellViewModel(rowStream.Select(rows => rows.Cells[22]));
            Column23 = new CellViewModel(rowStream.Select(rows => rows.Cells[23]));
            Column24 = new CellViewModel(rowStream.Select(rows => rows.Cells[24]));
            Column25 = new CellViewModel(rowStream.Select(rows => rows.Cells[25]));
            Column26 = new CellViewModel(rowStream.Select(rows => rows.Cells[26]));
            Column27 = new CellViewModel(rowStream.Select(rows => rows.Cells[27]));
            Column28 = new CellViewModel(rowStream.Select(rows => rows.Cells[28]));
            Column29 = new CellViewModel(rowStream.Select(rows => rows.Cells[29]));
        }

        public void Dispose()
        {
            Column1?.Dispose();
            Column2?.Dispose();
            Column3?.Dispose();
            Column4?.Dispose();
            Column5?.Dispose();
            Column0?.Dispose();
            Column6?.Dispose();
            Column7?.Dispose();
            Column8?.Dispose();
            Column9?.Dispose();
            Column10?.Dispose();
            Column11?.Dispose();
            Column12?.Dispose();
            Column13?.Dispose();
            Column14?.Dispose();
            Column15?.Dispose();
            Column16?.Dispose();
            Column17?.Dispose();
            Column18?.Dispose();
            Column19?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
            Column21?.Dispose();
        }
    }

    internal class CellViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<DateTimeOffset> Timestamp { get; }
        public ReactiveProperty<uint> Contributions { get; }

        public CellViewModel(IObservable<Cell> cellStream)
        {
            Timestamp = cellStream.Select(c => c.Timestamp).ToReadOnlyReactiveProperty();
            Contributions = cellStream.Select(c => c.Contributions).ToReactiveProperty();
        }

        public void Dispose()
        {
            Timestamp?.Dispose();
            Contributions?.Dispose();
        }
    }
}