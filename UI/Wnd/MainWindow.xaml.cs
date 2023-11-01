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
using InsuranceCompApp.UI.Pgs;

namespace InsuranceCompApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void btnContracts_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ContractsPage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeePage());
        }

        private void btnVehicle_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new VehiclePage());
        }

        private void btnContractClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ContractClientPage());
        }
    }
}
