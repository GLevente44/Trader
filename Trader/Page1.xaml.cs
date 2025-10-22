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

namespace Trader
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        private readonly DataBase data = new DataBase();
        private readonly MainWindow mainWindow;

        public Page1(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void logButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new
            {
                Name = userNameTextBox.Text,
                Password = userNameTextBox.Text,

            };
            _ = DataBase.LoginUser(user) ? 

        }

        private void regLink_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.StartWindow.Navigate(new RegisterPage(mainWindow));
        }
    }
}
