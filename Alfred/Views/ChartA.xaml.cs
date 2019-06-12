using Alfred.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Alfred.Views
{
    /// <summary>
    /// Interaction logic for ChartA.xaml
    /// </summary>
    public partial class ChartA : UserControl
    {
        public ChartA()
        {
            InitializeComponent();
            List<int> countList = new List<int>();
            countList = TheOrderViewModel.OrderRanges();

            Values = new ChartValues<int> { countList[0], countList[1], countList[2], countList[3],
                     countList[4]};
            Labels = new[] { "$0 - $10", "$10 - $15", "$15 - $20", "$20 - $25", "$25 - $30", "over $30" };
            Formatter = value => value.ToString("N");
            DataContext = this;

        }

        //    List<int> countList = new List<int>();
        //    countList = TheOrderViewModel.OrderRanges();


            //    SeriesCollection = new SeriesCollection
            //    {
            //        new ColumnSeries
            //        {
            //            Title = "Number of Orders",
            //            Values = new ChartValues<int> { countList[0], countList[1], countList[2], countList[3],
            //            countList[4]}
            //        }
            //    };

            //    SeriesCollection[0].Values.Add(countList[5]);

            //    Labels = new[] { "$0 - $10", "$10 - $15", "$15 - $20", "$20 - $25", "$25 - $30", "over $30" };
            //    Formatter = value => value.ToString("N");

            //    DataContext = this;
            //}

            //public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<int> Values { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}

