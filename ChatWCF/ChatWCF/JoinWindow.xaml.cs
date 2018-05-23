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
    /// Логика взаимодействия для JoinWindow.xaml
    /// </summary>
    public partial class JoinWindow : Window
    {
        List<string> chatsNameList;

        public string selectChatName { get; set; }

        public JoinWindow(List<string> chats)
        {
            chatsNameList = chats;

            AddChatsInChatLst();
            InitializeComponent();
        }

        private void JoinChatBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (NameChatListBox.SelectedIndex != -1)
            //{
            //    ListBoxItem listItm = (ListBoxItem)NameChatListBox.SelectedItem;

            //    selectChatName = listItm.Content.ToString();
            //}
        }

        private void AddChatsInChatLst()
        {
            int numChatNames = chatsNameList.Count();

            //for (int i = 0; i < numChatNames; i++)
            //{
            //    ListBoxItem listItem = new ListBoxItem();
            //    listItem.Content = chatsNameList[i];
            //    //MessageBox.Show(listItem.Content.ToString());

            //    NameChatListBox.Items.Add(new ListItem());
            //}
            //foreach (var item in chatsNameList)
            //{
            //    ListBoxItem listItem = new ListBoxItem();
            //    MessageBox.Show(item);
            //    listItem.Content = item;
            //    //NameChatListBox.Items.Add(listItem);
            //}
            ListBoxItem listItem = new ListBoxItem();
            listItem.Content = "dvdv";
            ListBox.Items.Add(listItem);
        }
    }
}
