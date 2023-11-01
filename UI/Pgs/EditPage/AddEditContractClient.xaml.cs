using InsuranceCompApp.Classes;
using InsuranceCompApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace InsuranceCompApp.UI.Pgs.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditContractClient.xaml
    /// </summary>
    public partial class AddEditContractClient : Page
    {
        private ContractClient _currentContractClient = new ContractClient();
        private Client _currentClient = new Client();
        public AddEditContractClient(ContractClient contractCleintForEdit)
        {
            InitializeComponent();
            if (contractCleintForEdit != null)
            {
                _currentContractClient = contractCleintForEdit;
                
            }
            DataContext = _currentContractClient;
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentContractClient.IdClient == null && _currentContractClient.IdContract == null)
            {
                if (string.IsNullOrWhiteSpace(_currentContractClient.CoefAgeDriver.ToString()))
                {
                    errors.AppendLine("Укажите коэффицент");
                }
            }
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentContractClient.IdClient == null && _currentContractClient.IdContract == null)
            {
                string strIdContract = txtBoxContract.Text;
                int numIdContract = Convert.ToInt32(strIdContract);

                string strIdClient = txtBoxClient.Text;
                int numIdClient = Convert.ToInt32(strIdClient);

                _currentContractClient.IdContract = numIdContract;
                _currentContractClient.IdClient = numIdClient;

                InsuranceCompanyDBEntities.GetContext().ContractClient.Add(_currentContractClient);

                
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

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            var birthdayDateVar = birthdayDate.Text;
            var driverLicenseDateVar = driverLicenseDate.Text;

            DateTime dtBirthday;
            DateTime.TryParse(birthdayDateVar, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dtBirthday);

            DateTime dtDriverLicenseDate;
            DateTime.TryParse(driverLicenseDateVar, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dtDriverLicenseDate);

            int dtBirth = dtBirthday.Year;
            int dtDLD = dtDriverLicenseDate.Year;
            int now = DateTime.Now.Year;

            dtBirth = now - dtBirth - 16;
            dtDLD = now - dtDLD;

            ArrayCAE ar = new ArrayCAE();

            double a = ar.ArrayGet(dtBirth, dtDLD);
            txtKVS.Text = a.ToString();
            _currentContractClient.CoefAgeDriver = a;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
