using _8_login.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int? U_ID = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Update()
        {
            if (U_ID == null) NameBox.Text = "Неизвестный пользователь!";
            else
            {
                using _8LoginContext context = new();
                FullName name = context.FullNames.Find(context.Users.Find(U_ID).UFId);
                if (name.FMiddleName == null) NameBox.Text = name.FLastName + " " + name.FFirstName + "!";
                else NameBox.Text = name.FLastName + " " + name.FMiddleName + " " + name.FFirstName + "!";
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Login login = new Login();
            login.Closed += L_Window_Closed;
            login.ShowDialog();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Registration registration = new Registration();
            registration.Closed += R_Window_Closed;
            registration.ShowDialog();
        }
        private void L_Window_Closed(object? sender, EventArgs e)
        {
            U_ID = Login.Selected_login;
            Update();
            Visibility = Visibility.Visible;
            Activate();
        }
        private void R_Window_Closed(object? sender, EventArgs e)
        {
            U_ID = Registration.Selected_registration;
            Update();
            Visibility = Visibility.Visible;
            Activate();
        }
    }
}