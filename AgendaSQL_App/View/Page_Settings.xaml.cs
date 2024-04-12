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
using System.Configuration;

namespace AgendaSQL_App.View
{
    /// <summary>
    /// Interaction logic for Page_Settings.xaml
    /// </summary>
    public partial class Page_Settings : UserControl
    {

        public Page_Settings()
        {
            InitializeComponent();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            Host_TB.Text = ConfigurationManager.AppSettings["host"];
            Port_TB.Text = ConfigurationManager.AppSettings["port"];
            User_TB.Text = ConfigurationManager.AppSettings["user"];
            Database_TB.Text = ConfigurationManager.AppSettings["database"];
            Password_TB.Password = ConfigurationManager.AppSettings["password"];
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Host_TB.Text == "" || Port_TB.Text == "" || User_TB.Text == "" || Database_TB.Text == "")
            {
                MessageBox.Show("Please fill all the fields!");
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            
            config.AppSettings.Settings.Remove("host");
            config.AppSettings.Settings.Add("host", Host_TB.Text);
            config.AppSettings.Settings.Remove("user");
            config.AppSettings.Settings.Add("user", User_TB.Text);
            config.AppSettings.Settings.Remove("password");
            config.AppSettings.Settings.Add("password", Password_TB.Password);
            config.AppSettings.Settings.Remove("server");
            config.AppSettings.Settings.Add("server", Host_TB.Text);
            config.AppSettings.Settings.Remove("port");
            config.AppSettings.Settings.Add("port", Port_TB.Text);
            config.AppSettings.Settings.Remove("database");
            config.AppSettings.Settings.Add("database", Database_TB.Text);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Settings Updated!");

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CheckDatabase();
        }

    }
}
