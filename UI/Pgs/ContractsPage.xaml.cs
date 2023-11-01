using InsuranceCompApp.Classes;
using InsuranceCompApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using InsuranceCompApp.UI.Pgs.EditPage;

namespace InsuranceCompApp.UI.Pgs
{
    /// <summary>
    /// Логика взаимодействия для ContractsPage.xaml
    /// </summary>
    public partial class ContractsPage : Page
    {
        public static bool isEnabledCalcButton;
        public ContractsPage()
        {
            InitializeComponent();
            
        }

        private void DGridContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditContractPage(null));
            isEnabledCalcButton = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedContract = DGridContracts.SelectedItems.Cast<InsuranceContract>().FirstOrDefault();
            
            if (selectedContract != null)
            {
                Manager.MainFrame.Navigate(new AddEditContractPage(selectedContract));
                isEnabledCalcButton = true;
            }
            else
            {
                MessageBox.Show("Выберите запись", "Внимание");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedContractForDelete = DGridContracts.SelectedItems.Cast<InsuranceContract>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {selectedContractForDelete.Count} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    InsuranceCompanyDBEntities.GetContext().InsuranceContract.RemoveRange(selectedContractForDelete);
                    InsuranceCompanyDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridContracts.ItemsSource = InsuranceCompanyDBEntities.GetContext().InsuranceContract.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                InsuranceCompanyDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridContracts.ItemsSource = InsuranceCompanyDBEntities.GetContext().InsuranceContract.ToList();
            }
        }
    }
}
