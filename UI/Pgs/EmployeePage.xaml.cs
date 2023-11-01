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
using InsuranceCompApp.Data.Models;
using InsuranceCompApp.Classes;
using InsuranceCompApp.UI.Pgs.EditPage;

namespace InsuranceCompApp.UI.Pgs
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            //DGridEmployee.ItemsSource = InsuranceCompanyDBEntities.GetContext().Employee.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var employeeForEdit = DGridEmployee.SelectedItems.Cast<Employee>().FirstOrDefault();
            Manager.MainFrame.Navigate(new AddEditEmployee(employeeForEdit));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditEmployee(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var employeeForDelete = DGridEmployee.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {employeeForDelete.Count()} элементов", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    InsuranceCompanyDBEntities.GetContext().Employee.RemoveRange(employeeForDelete);
                    InsuranceCompanyDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridEmployee.ItemsSource = InsuranceCompanyDBEntities.GetContext().Employee.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                InsuranceCompanyDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridEmployee.ItemsSource = InsuranceCompanyDBEntities.GetContext().Employee.ToList();
            }
        }
    }
}
