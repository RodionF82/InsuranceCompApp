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


namespace InsuranceCompApp.UI.Pgs.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Page
    {
        private Employee _currentEmployee = new Employee();
        public AddEditEmployee(Employee selectedEmployee)
        {
            InitializeComponent();

            if (selectedEmployee != null)
            {
                _currentEmployee = selectedEmployee;
                datePickerEmployment.SelectedDate = _currentEmployee.EmploymentDate;
            }
            else if (selectedEmployee == null)
            {
                var now = DateTime.Now;
                datePickerEmployment.SelectedDate = now;
                datePickerEmployment.DisplayDateStart = DateTime.Now;
            }
            DataContext = _currentEmployee;
            datePickerEmployment.SelectedDate = DateTime.MaxValue;
            datePickerEmployment.DisplayDateStart = DateTime.Now;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeePage());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmployee.LastName))
            {
                errors.AppendLine("Укажите фамилию");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.FirstName))
            {
                errors.AppendLine("Укажите имя");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic))
            {
                errors.AppendLine("Укажите отчество");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.Passport))
            {
                errors.AppendLine("Укажите паспортные данные");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.Phone))
            {
                errors.AppendLine("Укажите телефон");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.EmploymentDate.ToString()))
            {
                errors.AppendLine("Укажите дату приёма на работу");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.Birthday.ToString()))
            {
                errors.AppendLine("Укажите дату рождения");
            }
            if (string.IsNullOrWhiteSpace(_currentEmployee.Address))
            {
                errors.AppendLine("Укажите адрес");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEmployee.IdEmployee == 0)
            {
                InsuranceCompanyDBEntities.GetContext().Employee.Add(_currentEmployee);
                _currentEmployee.IdRole = 1;
            }

            try
            {
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsuranceCompanyDBEntities.GetContext().Employee.Remove(_currentEmployee);
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены", MessageBoxImage.Information.ToString());
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }
    }
}
