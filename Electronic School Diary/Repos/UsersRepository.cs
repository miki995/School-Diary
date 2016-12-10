using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary.Repos
{
    class UsersRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static bool ChangePassword(int id, string oldPassword, string newPassword, string confirmedNewPassword)
        {
            bool flag = false;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"UPDATE Users SET Password = @pass WHERE Id=@LoggedId;", Connection);
                    command.Parameters.AddWithValue("@LoggedId", id);
                    command.Parameters.AddWithValue("@pass", newPassword);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                    flag = true;
                    MessageBox.Show("Lozinka je uspješno promijenjena !");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;
           
        }
        public static int GetIdByName(string name)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Users WHERE UserName = @name", Connection);
            command.Parameters.AddWithValue("@name", name);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            int result = (int)reader["Id"];
            reader.Close();

            return result;
        }
       
        public static void InsertUser(string UserName, string Password)
        {
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Users (UserName, Password)
                    VALUES (@username, @password)", Connection);
                    command.Parameters.AddWithValue("@username", UserName);
                    command.Parameters.AddWithValue("@password", Password);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                    command.Dispose();
                        MessageBox.Show("Podaci za logovanje su uspješno dodati !");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool CheckUnique(string UserName)
        {
            bool flag = false;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT UserName FROM Users 
                    WHERE @usname = UserName", Connection);
                command.Parameters.AddWithValue("@usname", UserName);
                SqlCeDataReader reader = command.ExecuteReader();
                if (reader.Read() && reader["UserName"].ToString() == UserName)
                {
                    flag = true;
                    MessageBox.Show("Korisničko ime  " + "'" + UserName + "'" + "  već postoji !");
                }

            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message);
            }
            return flag;
        }

    }
}
