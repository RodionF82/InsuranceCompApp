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
using InsuranceCompApp.Classes;

namespace InsuranceCompApp.UI.Pgs.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditContractPage.xaml
    /// </summary>
    public partial class AddEditContractPage : Page
    {
        
        private InsuranceContract _currentContract = new InsuranceContract();
        string infoKVS;
        string infoRegion;
        public AddEditContractPage(InsuranceContract selectedContract)
        {
            InitializeComponent();
            if (selectedContract != null)
            {
                _currentContract = selectedContract;

                infoRegion = Convert.ToString(_currentContract.Region.Coefficent);
                txtRegionInfo.Text = "Регион (коэффициент): " + infoRegion;

                if (_currentContract.ContractClient.FirstOrDefault().CoefAgeDriver == null)
                {
                    MessageBox.Show("123");
                    Manager.MainFrame.GoBack();
                }
                else if (_currentContract.ContractClient.FirstOrDefault().CoefAgeDriver != null)
                {
                    infoKVS = Convert.ToString(_currentContract.ContractClient.FirstOrDefault().CoefAgeDriver);
                }
                txtBoxKVS.Text = infoKVS;
                
            }
            comboStatus.ItemsSource = InsuranceCompanyDBEntities.GetContext().StatusContract.ToList();
            comboTypeInsurance.ItemsSource = InsuranceCompanyDBEntities.GetContext().InsuranceType.ToList();
            comboEmployee.ItemsSource = InsuranceCompanyDBEntities.GetContext().Employee.ToList();
            comboRegion.ItemsSource = InsuranceCompanyDBEntities.GetContext().Region.ToList();
            comboVehicle.ItemsSource = InsuranceCompanyDBEntities.GetContext().Vehicle.ToList();

            DataContext = _currentContract;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentContract.StatusContract == null)
            {
                errors.AppendLine("Укажите статус");
            }
            if (_currentContract.InsuranceType == null)
            {
                errors.AppendLine("Укажите тип");
            }
            if (_currentContract.Employee == null)
            {
                errors.AppendLine("Укажите сотрудника");
            }
            if (_currentContract.Vehicle == null)
            {
                errors.AppendLine("Укажите транспортное средство");
            }
            if (_currentContract.Region == null)
            {
                errors.AppendLine("Укажите регион");
            }
       
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), MessageBoxImage.Error.ToString());
                return;
            }


            if (_currentContract.IdContract == 0)
            {
                InsuranceCompanyDBEntities.GetContext().InsuranceContract.Add(_currentContract);
                _currentContract.DateCons = DateTime.Now;
                _currentContract.DateEnd = DateTime.Now.AddYears(1);
            }

            try
            {
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена", "Внимание");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                InsuranceCompanyDBEntities.GetContext().InsuranceContract.Remove(_currentContract);
                //InsuranceCompanyDBEntities.GetContext().ContractClient.Remove(_currentContractClient);
                InsuranceCompanyDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно удалены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btcCalc_Click(object sender, RoutedEventArgs e)
        {
            double resultPrice = Convert.ToDouble(infoKVS) * _currentContract.Region.Coefficent * 
                _currentContract.Vehicle.BaseTariff * _currentContract.InsuranceType.RestrCoeff * _currentContract.ContractClient.FirstOrDefault().Client.ClassKBM.Coefficent;

            int intResultPrice = Convert.ToInt32(resultPrice);
            txtBoxPrice.Text = Convert.ToString(intResultPrice);
            _currentContract.Price = intResultPrice;

            infoRegion = Convert.ToString(_currentContract.Region.Coefficent);
            txtRegionInfo.Text = "Коэфиициент региона: " + infoRegion;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ContractsPage.isEnabledCalcButton == true)
            {
                btcCalc.Visibility = Visibility.Visible;
            }
            else if (ContractsPage.isEnabledCalcButton == false)
            {
                btcCalc.Visibility = Visibility.Collapsed;
            }
        }
    }
}
