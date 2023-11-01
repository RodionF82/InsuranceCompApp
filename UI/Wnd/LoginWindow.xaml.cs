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
using System.Windows.Shapes;

namespace InsuranceCompApp.UI.Wnd
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            textBoxPassword.Text = passwordBoxPassword.Password;
            textBoxPassword.Visibility = Visibility.Visible;
            passwordBoxPassword.Visibility = Visibility.Hidden;
        }

        private void checkBoxPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBoxPassword.Password = textBoxPassword.Text;
            passwordBoxPassword.Visibility = Visibility.Visible;
            textBoxPassword.Visibility = Visibility.Hidden;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            passwordBoxPassword.Password = "";
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.ShowDialog();
        }
    }
}
