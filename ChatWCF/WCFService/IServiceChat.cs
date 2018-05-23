using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        bool UserRegistration(ChatUser chatUser);

        [OperationContract]
        ChatUser UserLogin(string login, string password);

        [OperationContract]
        bool CreateChat(string chatName, string author);

        [OperationContract]
        List<Chat> GetChatList();

        [OperationContract]
        List<Chat> GetUserChatList(string userID);

        [OperationContract]
        void SendMessage(Message message);

        [OperationContract]
        void Disconnect(string userID);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(Message message);
    }

    [DataContract]
    public class Message
    {
        [DataMember]
        public string MessageID { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string CreationDate { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string ChatID { get; set; }
    }

    [DataContract]
    public class Chat
    {
        [DataMember]
        public string ChatID { get; set; }

        [DataMember]
        public string ChatName { get; set; }

        [DataMember]
        public string ChatAuthor { get; set; }

        [DataMember]
        public string availability { get; set; }
    }

    [DataContract]
    public class ChatUser
    {
        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surename { get; set; }

        [DataMember]
        public string Patronymic { get; set; }

        [DataMember]
        public string RegistrationDate { get; set; }

        [DataMember]
        public string LastActivityDate { get; set; }

        public OperationContext operationContext { get; set; }
    }
}
