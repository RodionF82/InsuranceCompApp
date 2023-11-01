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

namespace InsuranceCompApp.UI.Pgs
{
    /// <summary>
    /// Логика взаимодействия для VehiclePage.xaml
    /// </summary>
    public partial class VehiclePage : Page
    {
        private IList<string> itemsVehicle = new List<string>();
        public VehiclePage()
        {
            InitializeComponent();
            var obj = InsuranceCompanyDBEntities.GetContext().Vehicle.ToArray();
            foreach (var item in obj)
            {
                itemsVehicle.Add(item.IdVehicle.ToString());
            }
            itemsVehicleListView.ItemsSource = itemsVehicle;
        }

        private void itemsVehicleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemsVehicleListView.ItemsSource = itemsVehicle;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
