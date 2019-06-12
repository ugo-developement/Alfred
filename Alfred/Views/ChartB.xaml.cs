using Alfred.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Alfred.Views
{
    /// <summary>
    /// Interaction logic for ChartB.xaml
    /// </summary>
    public partial class ChartB : UserControl
    {
        public ChartB()
        {
            InitializeComponent();
            List<int> countList = new List<int>();
            countList = TheOrderViewModel.BasketAverages();

            Values = new ChartValues<double> {countList[0], countList[1], countList[2], countList[3],
                     countList[4], countList[5]};
            Labels = new[] { "1", "2", "3", "4", "5", "over 5" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
            public ChartValues<double> Values { get; set; }
            public string[] Labels { get; set; }
            public Func<double, string> Formatter { get; set; }

        //InitializeComponent();

        //List<int> countList = new List<int>();
        //countList = TheOrderViewModel.BasketAverages();


        //SeriesCollection = new SeriesCollection
        //{
        //    new ColumnSeries
        //    {
        //        Title = "Number of Orders",
        //        Values = new ChartValues<int> { countList[0], countList[1], countList[2], countList[3],
        //        countList[4]}
        //    }
        //};

        //SeriesCollection[0].Values.Add(countList[5]);

        //Labels = new[] { "1", "2", "3", "4", "5", "over 5" };
        //Formatter = value => value.ToString("N");

        //DataContext = this;
        //}

        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> Formatter { get; set; }
    }
}
