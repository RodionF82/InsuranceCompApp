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
using InsuranceCompApp.UI.Pgs;

namespace InsuranceCompApp.UI.UC
{
    /// <summary>
    /// Логика взаимодействия для UCVehicle.xaml
    /// </summary>
    public partial class UCVehicle : UserControl
    {
        public static bool isReadyOnlyTxt;
        public UCVehicle()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }
        public static readonly DependencyProperty UCVehicleProperty = DependencyProperty.Register
            ("MyItem", typeof(int), typeof(UCVehicle), new PropertyMetadata(default(int)));
        public int MyItem
        {
            get
            {
                return (int)GetValue(UCVehicleProperty);
            }
            set
            {
                SetValue(UCVehicleProperty, value);
            }
        }
        public void MyNameChanged()
        {
            if (MyItem != null)
            {
                var obg = InsuranceCompanyDBEntities.GetContext().Vehicle.Find(MyItem);

                brand.Text = "Бренд: " + obg.Brand.ToString();
                model.Text = "Модель: " + obg.Model.ToString();
                year.Text = "Год выпуска: " + obg.Year.ToString() + " г.";
                power.Text = "Мощность: " + obg.Power.ToString() + " л.с";

                ImageSource imgSource = new BitmapImage(new Uri(@"/Data/CarPhoto/" + obg.imgPath, UriKind.Relative));

                vehiclePhoto.Source = imgSource;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MyNameChanged();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            isReadyOnlyTxt = false;
            var obg = InsuranceCompanyDBEntities.GetContext().Vehicle.Find(MyItem);
            Manager.MainFrame.Navigate(new AddEditVehiclePage(obg));
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            isReadyOnlyTxt = true;
            var obg = InsuranceCompanyDBEntities.GetContext().Vehicle.Find(MyItem);
            Manager.MainFrame.Navigate(new AddEditVehiclePage(obg));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditVehiclePage(null));
        }
    }
}
