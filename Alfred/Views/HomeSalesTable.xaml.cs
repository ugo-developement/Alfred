using Alfred.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alfred.Views
{
    /// <summary>
    /// Interaction logic for HomeSalesTable.xaml
    /// </summary>
    public partial class HomeSalesTable : UserControl
    {
        public HomeSalesTable()
        {
            InitializeComponent();

            List<double> daycounts = HomeSalesTableViewModel.ReadData();
            List<double> weekcounts = HomeSalesTableViewModel.ReadDataWeek();
            List<double> monthcounts = HomeSalesTableViewModel.ReadDataMonth();
            List<double> yearcounts = HomeSalesTableViewModel.ReadDataYear();


            DayOrderCount.Content = daycounts[0];
            DayAvgBasket.Content = daycounts[1];
            DayAvgPrice.Content = string.Format("${0}", daycounts[2]);

            WeekOrderCount.Content = weekcounts[0];
            WeekAvgBasket.Content = weekcounts[1];
            WeekAvgPrice.Content = string.Format("${0}", weekcounts[2]);

            MonthOrderCount.Content = monthcounts[0];
            MonthAvgBasket.Content = monthcounts[1];
            MonthAvgPrice.Content = string.Format("${0}", monthcounts[2]);

            YearOrderCount.Content = yearcounts[0];
            YearAvgBasket.Content = yearcounts[1];
            YearAvgPrice.Content = string.Format("${0}", yearcounts[2]);
        }
    }
}
