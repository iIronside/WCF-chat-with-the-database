using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // один сервис для всех клиентов
    public class ServiceChat : IServiceChat
    {
        private DBManager dbManager;

        List<ChatUser> chatUsers = new List<ChatUser>();

        public ServiceChat()
        {

            dbManager = new DBManager();
        }

        public bool CreateChat(string chatName, string author)
        {
            return dbManager.AddChat(chatName, author);
        }

        public void Disconnect(string userID)
        {
            var user = chatUsers.FirstOrDefault(i => i.UserID == userID);
            if (user != null)
            {
                chatUsers.Remove(user);
            }
        }

        public List<Chat> GetChatList()
        {
            return dbManager.GetChatList();
        }

        public List<Chat> GetUserChatList(string userID)
        {
            return dbManager.GetUserChatList(userID);
        }

        public void SendMessage(Message message)
        {
            List<string> userIDInChat = dbManager.GetUserIDInChat(message.ChatID);

            foreach (var userOnline in chatUsers)
            {
                foreach (var userID in userIDInChat)
                {
                    if (userOnline.UserID == userID && message.UserID != userID)
                    {
                        userOnline.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(message);
                    }
                }
            }

            dbManager.AddMessage(message);
        }

        public ChatUser UserLogin(string login, string password)
        {
            ChatUser chatUser = new ChatUser();

            chatUser = dbManager.GetUser(login, password);
            chatUser.operationContext = OperationContext.Current;

            chatUsers.Add(chatUser);

            return chatUser;
        }

        public bool UserRegistration(ChatUser chatUser)
        {
            if (dbManager.AddUser(chatUser))
            {
                return true;
            }
            return false;
        }
    }
}
