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
    class AdminRepository
    {
        public static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;
        public static bool AddAdmin(string AdminName, string AdminSurname,string AdminUserName,string Password)
        {
            bool flag = false;
            
            try
            {
                   UsersRepository.InsertUser(AdminUserName, Password);
                   int AdminId = UsersRepository.GetIdByName(AdminUserName);

                    SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Administration (Name,Surname,UsersId)
                    VALUES (@name, @surname, @usersId)", Connection);
                    command.Parameters.AddWithValue("@name", AdminName);
                    command.Parameters.AddWithValue("@surname", AdminSurname);
                    command.Parameters.AddWithValue("@usersId", AdminId);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                    command.Dispose();
                    flag = true;
                        MessageBox.Show("Administrator je uspješno dodat !");
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
