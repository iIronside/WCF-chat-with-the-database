using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WCFService
{
    class DBManager
    {
        SqlConnection sqlConnection;

        public DBManager()
        {
            sqlConnection = new SqlConnection(@"Data Source=ADMIN-ПК\SQLEXPRESS;Initial Catalog=WCFChat;Integrated Security=True");
        }

        public List<string> GetUserIDInChat(string chatID)
        {
            List<string> usersIDInChat = new List<string>();

            sqlConnection.Open();

            SqlDataReader sqlReader = null;
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandText = "SELECT IDПользователя FROM Сообщение WHERE ЧатID = " + chatID + " Group By IDПользователя";
            sqlCmd.Connection = sqlConnection;

            sqlReader = sqlCmd.ExecuteReader();

            try
            {
                while (sqlReader.Read()) // проверка ридера на пустоту
                {
                    usersIDInChat.Add(sqlReader[0].ToString());
                }

                return usersIDInChat;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return usersIDInChat;
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

                sqlConnection.Close();
            }
        }

        public List<Chat> GetUserChatList(string userID)
        {
            List<Chat> UserListChats = new List<Chat>();
            List<string> chatListID = new List<string>();

            sqlConnection.Open();

            SqlDataReader sqlReader = null;
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandText = "SELECT ЧатID from Сообщение WHERE IDПользователя = "+ userID +" Group By ЧатID";
            sqlCmd.Connection = sqlConnection;

            sqlReader = sqlCmd.ExecuteReader();

            try
            {
                while (sqlReader.Read()) // проверка ридера на пустоту
                {
                    chatListID.Add(sqlReader[0].ToString());
                }
                sqlReader.Close();

                int chatNumber = chatListID.Count();
                for (int i = 0; i < chatNumber; i++)
                {
                    if (i == 0)
                    {
                        sqlCmd.CommandText = "Select * from Чат WHERE ЧатID = " + chatListID[i];
                    }
                    else
                    {
                        sqlCmd.CommandText += " OR ЧатID = " + chatListID[i];
                    }
                }

                sqlCmd.Connection = sqlConnection;
                sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) // проверка ридера на пустоту
                {
                    UserListChats.Add(new Chat());

                    UserListChats.Last().ChatID = sqlReader[0].ToString();
                    UserListChats.Last().ChatName = sqlReader[1].ToString();
                    UserListChats.Last().ChatAuthor = sqlReader[2].ToString();
                    UserListChats.Last().availability = sqlReader[3].ToString();
                }

                return UserListChats;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return UserListChats;
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

                sqlConnection.Close();
            }
        }

        public List<Chat> GetChatList()
        {
            List<Chat> listChats = new List<Chat>();

            sqlConnection.Open();

            SqlDataReader sqlReader = null;
            SqlCommand cmdGetUser = new SqlCommand();

            cmdGetUser.CommandText = "SELECT * FROM Чат;";
            cmdGetUser.Connection = sqlConnection;
            sqlReader = cmdGetUser.ExecuteReader();

            try
            {             
                while (sqlReader.Read()) // проверка ридера на пустоту
                {
                    listChats.Add(new Chat());

                    listChats.Last().ChatID = sqlReader[0].ToString();
                    listChats.Last().ChatName = sqlReader[1].ToString();
                    listChats.Last().ChatAuthor = sqlReader[2].ToString();
                    listChats.Last().availability = sqlReader[3].ToString();
                }

                return listChats;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return listChats;
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

                sqlConnection.Close();
            }
        }

        public void AddMessage(Message message)
        {
            sqlConnection.Open();

            SqlCommand cmdIsert = new SqlCommand();
            cmdIsert.CommandType = CommandType.Text;

            string cmdText = "INSERT INTO Сообщение([Текст], [Автор], [Дата_создания], [IDПользователя], [ЧатID]) VALUES" +
                " (" + "'" + message.Text + "', '" + message.Author + "','" + message.CreationDate + "','" + message.UserID + "','" + message.ChatID + "');";

            try
            {
                cmdIsert.CommandText = cmdText;
                cmdIsert.Connection = sqlConnection;
                cmdIsert.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool AddChat(string chatName, string author)
        {
            sqlConnection.Open();

            SqlCommand cmdIsert = new SqlCommand();
            cmdIsert.CommandType = CommandType.Text;

            string cmdText = "INSERT INTO Чат([Имя_чата], [Автор], [Доступность]) VALUES (" + "'" + chatName + "', '" + author + "','Публичный');";

            try
            {
                cmdIsert.CommandText = cmdText;
                cmdIsert.Connection = sqlConnection;
                cmdIsert.ExecuteNonQuery();

                sqlConnection.Close();

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public ChatUser GetUser(string login, string password)
        {
            ChatUser user = new ChatUser();

            sqlConnection.Open();

            SqlDataReader sqlReader = null;
            SqlCommand cmdGetUser = new SqlCommand();

            cmdGetUser.CommandText = "SELECT * FROM Пользователь WHERE Логин = " + "'" + login + "'" + " AND Пароль = " + "'" + password + "'";
            cmdGetUser.Connection = sqlConnection;
            sqlReader = cmdGetUser.ExecuteReader();

            try
            {
                int numberOfColums = sqlReader.FieldCount;
                
                if (sqlReader.Read()) // проверка ридера на пустоту
                {
                    user.UserID = sqlReader[0].ToString();
                    user.Login = sqlReader[1].ToString();
                    user.Password = sqlReader[2].ToString();
                    user.Name = sqlReader[3].ToString();
                    user.Surename = sqlReader[4].ToString();
                    user.Patronymic = sqlReader[5].ToString();
                    user.RegistrationDate = sqlReader[6].ToString();
                    user.LastActivityDate = sqlReader[7].ToString();
                }
                
                return user;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return user;
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

                sqlConnection.Close();
            }
        }

        public bool AddUser(ChatUser chatUser)
        {
            sqlConnection.Open();

            SqlCommand cmdIsert = new SqlCommand();
            cmdIsert.CommandType = CommandType.Text;

            string cmdText = "INSERT INTO Пользователь ([Логин], [Пароль], [Имя], [Фамилия], [Отчество], [Дата_регистрации], [Дата_последней_активности])" +
                " VALUES(" + "'" + chatUser.Login + "', '" + chatUser.Password + "', '" + chatUser.Name + "', '" + chatUser.Surename + "', '"
                + chatUser.Patronymic + "', '" + chatUser.RegistrationDate + "', '" + chatUser.LastActivityDate + "');";

            try
            {
                cmdIsert.CommandText = cmdText;
                cmdIsert.Connection = sqlConnection;
                cmdIsert.ExecuteNonQuery();

                sqlConnection.Close();

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
