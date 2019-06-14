using System.Windows.Controls;
using Alfred.ViewModels;
namespace Alfred.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Page
    {
        public CustomersView()
        {
            InitializeComponent();

            TC_Act.Content = CustomerDataViewModel.TotalCustActive();
            TC_Dor.Content = CustomerDataViewModel.TotalCustDormant();
            TC_Tot.Content = CustomerDataViewModel.TotalCustTotal();

            NC_Today.Content = CustomerDataViewModel.NewCustToday();
            NC_Week.Content = CustomerDataViewModel.NewCustWeek();
            NC_Month.Content = CustomerDataViewModel.NewCustMonth();
            NC_Year.Content = CustomerDataViewModel.NewCustYear();

            AAL_Act.Content = CustomerDataViewModel.LifeSpanActive();
            AAL_Dor.Content = CustomerDataViewModel.LifeSpanDormant();
            AAL_Tot.Content = CustomerDataViewModel.LifeSpanTotal();
        }
    }
}
