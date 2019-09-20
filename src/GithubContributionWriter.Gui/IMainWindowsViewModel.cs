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
        ReactiveProperty<string> Text { get; }
    }

    class MainWindowsDesignViewModel : IMainWindowsViewModel, IDisposable
    {
        public ReactiveProperty<RowViewModel[]> GridItems { get; }
        public ReactiveProperty<string> Text { get; }

        public MainWindowsDesignViewModel()
        {
            var dateTimeOffset = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(356));
            if (dateTimeOffset.DayOfWeek != DayOfWeek.Sunday)
            {
                dateTimeOffset = dateTimeOffset.Subtract(TimeSpan.FromDays((int) dateTimeOffset.DayOfWeek));
            }

            Text = new ReactiveProperty<string>("BADF00D");

            var source = Text
                .Select(newText =>
                {
                    var contributionGrid =
                        GithubContributionsGrid.CreateFakes(dateTimeOffset, newText, Alphabet.Default, 10, 52);
                    return contributionGrid.ToRows()
                        .Select(Observable.Return).ToArray();
                });

            GridItems = new ReactiveProperty<RowViewModel[]>();
            GridItems.Value = new []
            {
                new RowViewModel("",source.Select(rows => rows[0]).Switch()),
                new RowViewModel("Mon",source.Select(rows => rows[1]).Switch()),
                new RowViewModel("",source.Select(rows => rows[2]).Switch()),
                new RowViewModel("Wed",source.Select(rows => rows[3]).Switch()),
                new RowViewModel("",source.Select(rows => rows[4]).Switch()),
                new RowViewModel("Fri",source.Select(rows => rows[5]).Switch()),
                new RowViewModel("",source.Select(rows => rows[6]).Switch()),
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
            Text?.Dispose();
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
        public CellViewModel Column30 { get; }
        public CellViewModel Column31 { get; }
        public CellViewModel Column32 { get; }
        public CellViewModel Column33 { get; }
        public CellViewModel Column34 { get; }
        public CellViewModel Column35 { get; }
        public CellViewModel Column36 { get; }
        public CellViewModel Column37 { get; }
        public CellViewModel Column38 { get; }
        public CellViewModel Column39 { get; }
        public CellViewModel Column40 { get; }
        public CellViewModel Column41 { get; }
        public CellViewModel Column42 { get; }
        public CellViewModel Column43 { get; }
        public CellViewModel Column44 { get; }
        public CellViewModel Column45 { get; }
        public CellViewModel Column46 { get; }
        public CellViewModel Column47 { get; }
        public CellViewModel Column48 { get; }
        public CellViewModel Column49 { get; }
        public CellViewModel Column50 { get; }
        public CellViewModel Column51 { get; }
        public CellViewModel Column52 { get; }

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
            Column30 = new CellViewModel(rowStream.Select(rows => rows.Cells[30]));
            Column31 = new CellViewModel(rowStream.Select(rows => rows.Cells[31]));
            Column32 = new CellViewModel(rowStream.Select(rows => rows.Cells[32]));
            Column33 = new CellViewModel(rowStream.Select(rows => rows.Cells[33]));
            Column34 = new CellViewModel(rowStream.Select(rows => rows.Cells[34]));
            Column35 = new CellViewModel(rowStream.Select(rows => rows.Cells[35]));
            Column36 = new CellViewModel(rowStream.Select(rows => rows.Cells[36]));
            Column37 = new CellViewModel(rowStream.Select(rows => rows.Cells[37]));
            Column38 = new CellViewModel(rowStream.Select(rows => rows.Cells[38]));
            Column39 = new CellViewModel(rowStream.Select(rows => rows.Cells[39]));
            Column40 = new CellViewModel(rowStream.Select(rows => rows.Cells[40]));
            Column41 = new CellViewModel(rowStream.Select(rows => rows.Cells[41]));
            Column42 = new CellViewModel(rowStream.Select(rows => rows.Cells[42]));
            Column43 = new CellViewModel(rowStream.Select(rows => rows.Cells[43]));
            Column44 = new CellViewModel(rowStream.Select(rows => rows.Cells[44]));
            Column45 = new CellViewModel(rowStream.Select(rows => rows.Cells[45]));
            Column46 = new CellViewModel(rowStream.Select(rows => rows.Cells[46]));
            Column47 = new CellViewModel(rowStream.Select(rows => rows.Cells[47]));
            Column48 = new CellViewModel(rowStream.Select(rows => rows.Cells[48]));
            Column49 = new CellViewModel(rowStream.Select(rows => rows.Cells[49]));
            Column50 = new CellViewModel(rowStream.Select(rows => rows.Cells[50]));
            Column51 = new CellViewModel(rowStream.Select(rows => rows.Cells[51]));
            //Column52 = new CellViewModel(rowStream.Select(rows => rows.Cells[52]));
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
            Column20?.Dispose();
            Column21?.Dispose();
            Column22?.Dispose();
            Column23?.Dispose();
            Column24?.Dispose();
            Column25?.Dispose();
            Column26?.Dispose();
            Column27?.Dispose();
            Column28?.Dispose();
            Column29?.Dispose();
            Column30?.Dispose();
            Column31?.Dispose();
            Column32?.Dispose();
            Column33?.Dispose();
            Column34?.Dispose();
            Column35?.Dispose();
            Column36?.Dispose();
            Column37?.Dispose();
            Column38?.Dispose();
            Column39?.Dispose();
            Column40?.Dispose();
            Column41?.Dispose();
            Column42?.Dispose();
            Column43?.Dispose();
            Column44?.Dispose();
            Column45?.Dispose();
            Column46?.Dispose();
            Column47?.Dispose();
            Column48?.Dispose();
            Column49?.Dispose();
            Column50?.Dispose();
            Column51?.Dispose();
            Column52?.Dispose();
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