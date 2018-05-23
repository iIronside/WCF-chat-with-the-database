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
using ChatWCF.ServiceChatReference;

namespace ChatWCF
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ChatUser authorizedUser;

        public LoginWindow(ChatUser user)
        {
            authorizedUser = user;

            authorizedUser.Login = "";
            authorizedUser.Password = "";

            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text != "" && PasswordTextBox.Text != "")
            {
                authorizedUser.Login = LoginTextBox.Text;
                authorizedUser.Password = PasswordTextBox.Text;

                Close();
            }
            else
            {
                MessageBox.Show("Not all fields are filled!", "Empty field", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
        }
    }
}
