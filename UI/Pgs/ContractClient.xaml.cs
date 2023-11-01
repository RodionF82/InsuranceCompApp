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
using InsuranceCompApp.Classes;
using InsuranceCompApp.Data.Models;
using InsuranceCompApp.UI.Pgs.EditPage;

namespace InsuranceCompApp.UI.Pgs
{
    /// <summary>
    /// Логика взаимодействия для ContractClient.xaml
    /// </summary>
    public partial class ContractClient : Page
    {
        public ContractClient()
        {
            InitializeComponent();
            DGridContractClient.ItemsSource = InsuranceCompanyDBEntities.GetContext().ContractClient.ToList();
        }

        private void DGridContractClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var employeeForEdit = DGridEmployee.SelectedItems.Cast<Employee>().FirstOrDefault();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditContractClient(null));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var contractCleintForEdit = DGridContractClient.SelectedItems.Cast<ContractClient>().FirstOrDefault();
            
            //if (contractCleintForEdit)
            Manager.MainFrame.Navigate(new AddEditContractClient(contractCleintForEdit));



            /*var selectedContract = DGridContracts.SelectedItems.Cast<InsuranceContract>().FirstOrDefault();

            if (selectedContract != null)
            {
                Manager.MainFrame.Navigate(new AddEditContractPage(selectedContract));
            }
            else
            {
                MessageBox.Show("Выберите запись", "Внимание");
            }*/
        }

    }
}
