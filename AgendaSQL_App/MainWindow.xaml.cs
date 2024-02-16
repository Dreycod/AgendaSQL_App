using AgendaSQL_App.View;
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

namespace AgendaSQL_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void DashboardBTN_Click(object sender, RoutedEventArgs e)
        {
            Page_Dashboard dashboardPage = new Page_Dashboard();
            Grid_Content.Children.Clear();
            Grid_Content.Children.Add(dashboardPage);
        }

        private void ContactsBTN_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Page_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
