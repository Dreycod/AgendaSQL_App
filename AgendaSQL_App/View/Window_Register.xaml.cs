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
using System.Configuration;
using AgendaSQL_App.Service;
namespace AgendaSQL_App.View
{
    /// <summary>
    /// Interaction logic for Window_Register.xaml
    /// </summary>
    public partial class Window_Register : Window
    {
        public Window_Register()
        {
            InitializeComponent();
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveNewUser_Click(object sender, RoutedEventArgs e)
        {
            // save user & password in the configs

            if (UsernameTB.Text == "")
            {
                MessageBox.Show("Please fill all the fields!");
                return;
            }
            if (PasswordTB.Password != ConfirmTB.Password)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }


            string Pwd = PasswordTB.Password;

            if (Pwd.Length < 8)
            { 
                Pwd = MD5Crypter.CrypterMot_de_passe(PasswordTB.Password).ToString();
            }


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("loginUser");
            config.AppSettings.Settings.Add("loginUser", UsernameTB.Text);
            config.AppSettings.Settings.Remove("loginPassword");
            config.AppSettings.Settings.Add("loginPassword", Pwd);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("User saved successfully!");
            Close();
        }

    }
}
