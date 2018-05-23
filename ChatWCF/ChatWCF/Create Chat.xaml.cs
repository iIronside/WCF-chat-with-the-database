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

namespace ChatWCF
{
    /// <summary>
    /// Логика взаимодействия для Create_Chat.xaml
    /// </summary>
    public partial class Create_Chat : Window
    {
        public string chatName { get; set; }

        public Create_Chat(string name)
        {
            chatName = name;

            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ChatNameTextBox.Text != "" && ChatNameTextBox.Text != "")
            {
                chatName = ChatNameTextBox.Text;

                Close();
            }
            else
            {
                MessageBox.Show("Not all fields are filled!", "Empty field", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
