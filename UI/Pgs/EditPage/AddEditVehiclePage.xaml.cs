using InsuranceCompApp.Classes;
using InsuranceCompApp.Data.Models;
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
using InsuranceCompApp.UI.UC;

namespace InsuranceCompApp.UI.Pgs.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditVehiclePage.xaml
    /// </summary>
    public partial class AddEditVehiclePage : Page
    {
        private Vehicle _currentVehicle = new Vehicle();
        public AddEditVehiclePage(Vehicle selectedVehicle)
        {
            InitializeComponent();
            if (selectedVehicle != null)
            {
                //var dbSelectedVehicle = InsuranceCompanyDBEntities.GetContext().Vehicle.Find(selectedVehicle);
                _currentVehicle = selectedVehicle;
                pswBoxVIN.Password = _currentVehicle.VIN;
                txtBoxVIN.Visibility = Visibility.Collapsed;
                pswBoxVIN.Visibility = Visibility.Visible;
            }
            else if (selectedVehicle == null)
            {
                chckBoxVIN.Visibility = Visibility.Collapsed;
                pswBoxVIN.Visibility = Visibility.Collapsed;
                txtBoxVIN.Visibility = Visibility.Visible;
            }
            DataContext = _currentVehicle;
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentVehicle.Brand))
                errors.AppendLine("Введите Марку");
            if (string.IsNullOrEmpty(_currentVehicle.Model))
                errors.AppendLine("Введите модель");
            if (string.IsNullOrEmpty(_currentVehicle.Equipment))
                errors.AppendLine("Укажите комплектацию");
            if (string.IsNullOrEmpty(_currentVehicle.Year.ToString()) || _currentVehicle.Year < 1960 || _currentVehicle.Year > System.DateTime.Now.Year)
                errors.AppendLine("Укажите год выпуска авто");
            if (string.IsNullOrEmpty(_currentVehicle.VIN))
                errors.AppendLine("Укажите VIN");
            if (string.IsNullOrEmpty(_currentVehicle.Color))
                errors.AppendLine("Укажите цвет");
            if (string.IsNullOrEmpty(_currentVehicle.Power.ToString()) || _currentVehicle.Power < 50 || _currentVehicle.Power > 1200)
                errors.AppendLine("Укажите мощность");
            if (string.IsNullOrEmpty(_currentVehicle.BaseTariff.ToString()) || _currentVehicle.BaseTariff < 1000 || _currentVehicle.BaseTariff > 100000)
                errors.AppendLine("Укажите базовый тариф");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentVehicle.IdVehicle == 0)
            {
                InsuranceCompanyDBEntities.GetContext().Vehicle.Add(_currentVehicle);
            }

            try
            {
                if (chckBoxVIN.IsChecked == false)
                {
                    _currentVehicle.VIN = pswBoxVIN.Password;
                }
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена успешно");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsuranceCompanyDBEntities.GetContext().Vehicle.Remove(_currentVehicle);
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void chckBoxVIN_Checked(object sender, RoutedEventArgs e)
        {
            txtBoxVIN.Text = pswBoxVIN.Password;
            txtBoxVIN.Visibility = Visibility.Visible;
            pswBoxVIN.Visibility = Visibility.Collapsed;
        }

        private void chckBoxVIN_Unchecked(object sender, RoutedEventArgs e)
        {
            pswBoxVIN.Password = txtBoxVIN.Text;
            txtBoxVIN.Visibility = Visibility.Collapsed;
            pswBoxVIN.Visibility= Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (UCVehicle.isReadyOnlyTxt == true)
            {
                txtBoxBrand.IsReadOnly = true;
                txtBoxModel.IsReadOnly = true;
                txtBoxEquipment.IsReadOnly = true;
                txtBoxBaseTariff.IsReadOnly = true;
                txtBoxColor.IsReadOnly = true;
                txtBoxImgPath.IsReadOnly = true;    
                txtBoxPower.IsReadOnly = true;
                txtBoxVIN.IsReadOnly = true;
                //pswBoxVIN
                //chckBoxVIN.IsEnabled = true;
                txtBoxYear.IsReadOnly = true;
                btnSave.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else if (UCVehicle.isReadyOnlyTxt == false)
            {

            }
        }

        private void pswBoxVIN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (UCVehicle.isReadyOnlyTxt == true)
            {
                e.Handled = true;
            }
            else if (UCVehicle.isReadyOnlyTxt == false)
            {
                e.Handled = false;
            }
        }
    }
}
