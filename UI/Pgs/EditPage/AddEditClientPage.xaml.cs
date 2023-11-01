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

namespace InsuranceCompApp.UI.Pgs.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientPage.xaml
    /// </summary>
    public partial class AddEditClientPage : Page
    {
        private Client _currentClient = new Client();
        public AddEditClientPage(Client selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
            {
                _currentClient = selectedClient;
            }
            DataContext = _currentClient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsuranceCompanyDBEntities.GetContext().Client.Remove(_currentClient);
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.LastName))
            {
                errors.AppendLine("Укажите фамилию");
            }
            if (string.IsNullOrWhiteSpace(_currentClient.FirstName))
            {
                errors.AppendLine("Укажите имя");
            }
            if (string.IsNullOrWhiteSpace(_currentClient.Patronymic))
            {
                errors.AppendLine("Укажите отчество");
            }
            var dt = datePickerBirthday.Text;
            _currentClient.Birthday = Convert.ToDateTime(dt);

            if (string.IsNullOrEmpty(_currentClient.Birthday.ToString()))
            {
                errors.AppendLine("Укажите Дату рождения");
            }
            if (string.IsNullOrEmpty(_currentClient.Birthday.ToString()))
            {
                errors.AppendLine("Укажите дату получения водительских прав");
            }
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
            {
                errors.AppendLine("Укажите номер телефона");
            }
            if (string.IsNullOrWhiteSpace(_currentClient.NumOfCrashYear.ToString()))
            {
                errors.AppendLine("Укажите количество аварий за год");
            }
            if (_currentClient.NumOfCrashYear > 12 || _currentClient.NumOfCrashYear < 0)
            {
                errors.AppendLine("Укажите правильное количество аварий");
            }
            if (_currentClient.IdClassKBM > 13 || _currentClient.IdClassKBM < -1)
            {
                errors.AppendLine("Укажите правильный класс КБМ");
            }
            if (string.IsNullOrEmpty(_currentClient.ClassKBM.ToString()))
            {
                errors.AppendLine("Укажите класс КБМ");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.IdClient == 0)
            {
                InsuranceCompanyDBEntities.GetContext().Client.Add(_currentClient);
                _currentClient.DriversLicenseDate = DateTime.Now;
                _currentClient.Birthday = DateTime.Now;
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

        private void btnClassKBM_Click(object sender, RoutedEventArgs e)
        {
            int intNumCrashYear = Convert.ToInt32(numCrashYear.Text);
            int intClassKBM = Convert.ToInt32(idClassKBM.Text) + 1;

            ArrayKBM ar = new ArrayKBM();

            double newClassKBM = ar.ArrayGet(intClassKBM, intNumCrashYear) - 1;
            if (newClassKBM == -1)
            {
                idClassKBM.Text = "M";
            }
            else
            {
                idClassKBM.Text = newClassKBM.ToString();
            }
            numCrashYear.Text = "0";
            _currentClient.IdClassKBM = Convert.ToInt32(newClassKBM);
            btnClassKBM.IsEnabled = false;
        }
    }
}
