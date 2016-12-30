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
    class TeacherRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static string GetNameQuery()
        {
            string query;
            query = @"SELECT Name FROM Teachers";
            return query;
        }
        public static string GetSurnameQuery()
        {
            string query;
            query = @"SELECT Surname FROM Teachers";
            return query;
        }
        public static bool AddTeacher(string TeacherName, string TeacherSurname, string TeacherUserName, string Address, string Phone_number,string Password)
        {
            bool flag = false;
            try
            {
                    UsersRepository.InsertUser(TeacherUserName, Password);
                    int TeacherId = UsersRepository.GetIdByName(TeacherUserName);

                    SqlCeCommand command1 = new SqlCeCommand(@"INSERT INTO Teachers (Name,Surname,Address,Phone_number,UsersId)
                    VALUES (@name, @surname, @address, @phonenumber, @usersId)", Connection);
                    command1.Parameters.AddWithValue("@name", TeacherName);
                    command1.Parameters.AddWithValue("@surname", TeacherSurname);
                    command1.Parameters.AddWithValue("@address", Address);
                    command1.Parameters.AddWithValue("@phonenumber", Phone_number);
                    command1.Parameters.AddWithValue("@usersId", TeacherId);
                    int result = command1.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                        MessageBox.Show("Nastavnik je uspješno dodat !");
                    }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;
        }
        public static int GetIdByName(string name, string surname)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Teachers WHERE Name = @name AND Surname = @surname ", Connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                SqlCeDataReader reader = command.ExecuteReader();

                reader.Read();

                 result = (int)reader["Id"];
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}
