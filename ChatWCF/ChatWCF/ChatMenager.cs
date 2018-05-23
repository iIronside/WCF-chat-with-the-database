using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatWCF.ServiceChatReference;

namespace ChatWCF
{
    class ChatMenager : IServiceChatCallback
    {
        public ChatUser chatUser;
        public List<Chat> chats;
        public List<Chat> userChats;
        public List<Message> receivedMessages;

        public string CurrentChatId;

        ServiceChatClient client;
        
        public ChatMenager()
        {
            chatUser = new ChatUser();
            chats = new List<Chat>();
            userChats = new List<Chat>();
            receivedMessages = new List<Message>();

            CurrentChatId = "";

            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
        }

        public bool UserRegistration()
        {
            if (chatUser.Login != "" && chatUser.Login != null)
            {
                if (client.UserRegistration(chatUser))
                {
                    return true;
                }  
            }
            return false;
        }

        public bool Login()
        {
            if (chatUser.Login != "" && chatUser.Login != null)
            {
                chatUser = client.UserLogin(chatUser.Login, chatUser.Password);

                if (chatUser.Login != "" && chatUser.Login != null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CreateChat(string chatName)
        {
            if (chatUser.Login != "" && chatUser.Login != null && chatName != null)
            {
                if (client.CreateChat(chatName, chatUser.Login))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Chat> GetChats()
        {
            chats = client.GetChatList().ToList();

            return chats;
        }

        public List<Chat> GetUserChats()
        {
            userChats = client.GetUserChatList(chatUser.UserID).ToList();

            return userChats;
        }

        public string GetUserLogin()
        {
            return chatUser.Login;
        }

        public void SetCurrentChatId(string chatName)
        {
            foreach (var item in userChats)
            {
                if (item.ChatName == chatName)
                {
                    CurrentChatId = item.ChatID;

                    break;
                }
            }
        }

        public void SendMsg(Message message)
        {
            client.SendMessage(message);
        }

        public void Disconect()
        {
            if (chatUser.UserID != "" && chatUser.UserID != null)
            {
                client.Disconnect(chatUser.UserID);
            }
        }

        public void MsgCallback(Message message)
        {
            receivedMessages.Add(message);
        }
    }
}
