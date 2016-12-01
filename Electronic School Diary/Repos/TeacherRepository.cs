using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary.Repos
{
    class TeacherRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static string GetQuery()
        {
            string query;
            query = @"SELECT Name,Surname FROM Classes";
            return query;

        }
        public static bool AddTeacher(string TeacherName, string TeacherSurname, string TeacherUserName, string Address, string Phone_number,string Password)
        {
            bool flag = false;
            try
            {
                    UsersRepository.InsertUser(TeacherUserName, Password);
                    int TeacherId = UsersRepository.GetIdByName(TeacherUserName, Password);

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
    }
}
