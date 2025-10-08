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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly DataBase db = new DataBase();


        public RegisterPage()
        {
            InitializeComponent();
        }

        private void reg_Button(object sender, RoutedEventArgs e)
        {
            if(userPasswordBox1.Password == userPasswordBox2.Password)
            {
                var user = new
                {
                    UserName = userNameTextBox.Text,
                    Password = userPasswordBox1.Password,
                    FullName = userFullNameTextBox.Text,
                    Salt = "",
                    Email = userEmailTextBox.Text
                };

                MessageBox.Show(db.AddNewUser(user).ToString());
            }
            else
            {
                MessageBox.Show("Eltérő jelszavak!");
            }
        }   
    }
}
