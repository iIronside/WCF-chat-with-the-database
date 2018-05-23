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
using ChatWCF.ServiceChatReference;
using System.Windows.Threading;

namespace ChatWCF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window//, IServiceChatCallback
    {
        ChatMenager chatMenager;
        private DispatcherTimer timer = null;

        public MainWindow()
        {
            //проверять активен ли сервер если нет сообщение, окно не активно this.IsHitTestVisible = false;
            chatMenager = new ChatMenager();

            InitializeComponent();

            SetBtnVisibleFalse();
            timerStart();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrWindow = new RegistrationWindow(chatMenager.chatUser);
            registrWindow.ShowDialog();

            if (chatMenager.UserRegistration())
            {
                MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK);
            }
            else
            {
                ClearFields();

                SetBtnVisibleFalse();

                chatMenager.CurrentChatId = "";

                MessageBox.Show("Registration failed", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            SetBtnVisibleFalse();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(chatMenager.chatUser);
            loginWindow.ShowDialog();

            if (chatMenager.Login())
            {
                chatMenager.GetUserChats();
                chatMenager.GetChats();

                SetUserLoginInTexyBox();

                AddUserChatsInChatLst();
                AddChatsInChatLst();

                SetBtnVisibleTrue(); // блокировать кнопки если user пустой

                //MessageBox.Show("Login successful", "Successful", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ClearFields();

                SetBtnVisibleFalse();

                chatMenager.CurrentChatId = "";

                MessageBox.Show("Login failed", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateChat_Click(object sender, RoutedEventArgs e)
        {
            string chatName = "";

            Create_Chat createChatWindow = new Create_Chat(chatName);
            createChatWindow.ShowDialog();
            // обновлять список чатов
            if (chatMenager.CreateChat(createChatWindow.chatName))
            {
                MessageBox.Show("Chat created", "Successful", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Unauthorized user or chat name not specified", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SelectChat_Click(object sender, RoutedEventArgs e)
        {
            if (ChatListBox.SelectedIndex != -1)
            {             
                ListBoxItem listItm = (ListBoxItem)ChatListBox.SelectedItem;

                chatMenager.SetCurrentChatId(listItm.Content.ToString());

                CurrentChatTextBox.Text = listItm.Content.ToString();

                if (ChatTextBox.Text != null && ChatTextBox.Text != "")
                {
                    ChatTextBox.Clear();
                }
            }
        }

        private void JoinChatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AllChatListBox.SelectedIndex != -1)
            {
                ListBoxItem listItm = (ListBoxItem)AllChatListBox.SelectedItem;
                //MessageBox.Show(listItm.Content.ToString());

                string chatName = listItm.Content.ToString();
                string chatID = "";

                foreach (var item in chatMenager.chats)
                {
                    if (chatName == item.ChatName)
                    {
                        chatID = item.ChatID;

                        break;
                    }
                }

                

                Message message = new Message();

                message.Author = chatMenager.chatUser.Login;
                message.ChatID = chatID;
                message.UserID = chatMenager.chatUser.UserID;
                message.Text = chatMenager.chatUser.Login + " Join in Chat.";
                message.CreationDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:fff");

                chatMenager.SendMsg(message);

                chatMenager.GetUserChats();
                AddUserChatsInChatLst();
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WriteMsgTextBox.Text != null && WriteMsgTextBox.Text != "" && CurrentChatTextBox.Text != null && CurrentChatTextBox.Text != "")
            {
                Message message = new Message();

                message.Author = chatMenager.chatUser.Login;
                message.ChatID = chatMenager.CurrentChatId;
                message.UserID = chatMenager.chatUser.UserID;
                message.Text = WriteMsgTextBox.Text;
                message.CreationDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:fff");

                WriteMsg(message);
                chatMenager.SendMsg(message);

                WriteMsgTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Message or chat not entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void WriteMsg(Message msg)
        {
            ChatTextBox.Text += msg.Author + ":" + msg.CreationDate + ":" + msg.Text + Environment.NewLine;

        }

        private void ClearFields()
        {
            WriteMsgTextBox.Clear();
            ChatTextBox.Clear();
            ChatListBox.Items.Clear();
            UserTextBox.Text = null;
            CurrentChatTextBox.Text = null;
        }

        private void AddUserChatsInChatLst()
        {
            ChatListBox.Items.Clear();
            foreach (Chat item in chatMenager.userChats)
            {
                ListBoxItem listItm = new ListBoxItem();
                listItm.Content = item.ChatName;
                ChatListBox.Items.Add(listItm);
            }
        }

        private void AddChatsInChatLst()
        {
            foreach (Chat item in chatMenager.chats)
            {
                ListBoxItem listItm = new ListBoxItem();
                listItm.Content = item.ChatName;
                AllChatListBox.Items.Add(listItm);
            }
        }

        private void SetUserLoginInTexyBox()
        {
            UserTextBox.Text = chatMenager.GetUserLogin();
        }

        private void SetBtnVisibleTrue()
        {
            SendBtn.IsHitTestVisible = true;
            SetChatBtn.IsHitTestVisible = true;
            JoinChatBtn.IsHitTestVisible = true;
         
        }

        private void SetBtnVisibleFalse()
        {
            SendBtn.IsHitTestVisible = false;
            SetChatBtn.IsHitTestVisible = false;
            JoinChatBtn.IsHitTestVisible = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            chatMenager.Disconect();
            Close();
        }

        private void timerStart()
        {
            timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (chatMenager.CurrentChatId != null && chatMenager.CurrentChatId != "")
            {
                foreach (var message in chatMenager.receivedMessages)
                {
                    if (message.ChatID == chatMenager.CurrentChatId)
                    {
                        WriteMsg(message);
                    }
                }
                chatMenager.receivedMessages.RemoveAll(x => x.ChatID == chatMenager.CurrentChatId);
            }
        }
        // в таймере ли проблема попробывать убрать его узнать приходят ли сообщения
    }
}
