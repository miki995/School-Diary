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
    class DirectorRepository
    {
        public static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;
        
        public static bool AddDirector(string DirectorName, string DirectorSurname, string DirectorUserName, string Password)
        {
            bool flag = false;
            
            try
            {
                   UsersRepository.InsertUser(DirectorUserName, Password);
                   int DirectorId = UsersRepository.GetIdByName(DirectorUserName);

                    SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Directors (Name,Surname,UsersId)
                    VALUES (@name, @surname, @usersId)", Connection);
                    command.Parameters.AddWithValue("@name", DirectorName);
                    command.Parameters.AddWithValue("@surname", DirectorSurname);
                    command.Parameters.AddWithValue("@usersId", DirectorId);
                int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                        MessageBox.Show("Direktor je uspješno dodat !");
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
