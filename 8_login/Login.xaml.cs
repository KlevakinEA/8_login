using _8_login.Model;
using Microsoft.EntityFrameworkCore;
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

namespace _8_login
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static int? Selected_login;
        public Login()
        {
            Selected_login = null;
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == null || PassBox.Password == null)
            {
                using _8LoginContext context = new _8LoginContext();
                foreach (var item in context.Users)
                {
                    if (item.ULogin == LoginBox.Text || item.UPassword == PassBox.Password) { Selected_login = item.UId; MessageBox.Show("Login succesfull"); ; break; }
                }
                MessageBox.Show("There're no cuch users with those login and passport.");
            }
            else MessageBox.Show("Text is missing");
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Registration registration = new Registration();
            registration.Closed += R_Window_Closed;
            registration.ShowDialog();
        }
        private void R_Window_Closed(object? sender, EventArgs e)
        {
            Selected_login = Registration.Selected_registration;
            Visibility = Visibility.Visible;
            Activate();
        }
    }
}
