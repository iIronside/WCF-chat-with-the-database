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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ChatUser registeredUser;

        public RegistrationWindow(ChatUser user)
        {
            registeredUser = user;
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxtBox.Text != "" && PasswordTxtBox.Text != "" && NameTxtBox.Text != "" && SurenameTxtBox.Text != "" && PatronymicTxtBox.Text != "")
            {
                registeredUser.Login = LoginTxtBox.Text;
                registeredUser.Password = PasswordTxtBox.Text;
                registeredUser.Name = NameTxtBox.Text;
                registeredUser.Surename = SurenameTxtBox.Text;
                registeredUser.Patronymic = PatronymicTxtBox.Text;

                Close();
            }
            else
            {
                MessageBox.Show("Not all fields are filled!", "Empty field", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
