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
    class StudentRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;
 
        public static bool AddStudent(string StudentName, string StudentSurname, string Jmbg, string Address, string Phone_number)
        {
            bool flag = false;

            try
            {
              
                    SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Students (Name,Surname,Jmbg,Address,Phone_number,DepartmentsId)
                    VALUES (@name, @surname, @jmbg, @address, @phone, @depId)", Connection);
                    command.Parameters.AddWithValue("@name", StudentName);
                    command.Parameters.AddWithValue("@surname", StudentSurname);
                    command.Parameters.AddWithValue("@jmbg", Jmbg);
                    command.Parameters.AddWithValue("@address", Address);
                    command.Parameters.AddWithValue("@phone", Phone_number);
                    command.Parameters.AddWithValue("@depId", 5);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                        MessageBox.Show("Učenik je uspješno dodat !");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;
            }

             public static int GetIdByJmbg(string jmbg)
              {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Students WHERE Jmbg = @jmbg", Connection);
                command.Parameters.AddWithValue("@jmbg", jmbg);
                SqlCeDataReader reader = command.ExecuteReader();

                reader.Read();

                int result = (int)reader["Id"];
                reader.Close();

                return result;
              }
    
    }
}
