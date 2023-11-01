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
using InsuranceCompApp.UI.Pgs.EditPage;
using InsuranceCompApp.Data.Models;


namespace InsuranceCompApp.UI.Pgs
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var clientForEdit = DGridClients.SelectedItems.Cast<Client>().FirstOrDefault();
            Manager.MainFrame.Navigate(new AddEditClientPage(clientForEdit));
        }

        private void DGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditClientPage(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientForDelete = DGridClients.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForDelete.Count()} элеменотв", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    InsuranceCompanyDBEntities.GetContext().Client.RemoveRange(clientForDelete);
                    InsuranceCompanyDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridClients.ItemsSource = InsuranceCompanyDBEntities.GetContext().Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            InsuranceCompanyDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridClients.ItemsSource = InsuranceCompanyDBEntities.GetContext().Client.ToList();
        }
    }
}
