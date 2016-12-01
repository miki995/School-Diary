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
    class ParentRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static bool AddParent(string ParentName, string ParentSurname,string Address,string Email,string Phone_number,string jmbg)
        {
            bool flag = false;
            
            try
            {
                int StudentId = StudentRepository.GetIdByJmbg(jmbg);
                Parent parent = new Parent(ParentName, ParentSurname, Address, Email, Phone_number);
                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Parents (Name,Surname,Address,Email,Phone_number,StudentsId)
                VALUES (@name, @surname, @address, @email, @phone, @studId)", Connection);
                command.Parameters.AddWithValue("@name", parent.Name);
                command.Parameters.AddWithValue("@surname", parent.Surname);
                command.Parameters.AddWithValue("@address", parent.Address);
                command.Parameters.AddWithValue("@email", parent.Email);
                command.Parameters.AddWithValue("@phone", parent.Phone_number);
                command.Parameters.AddWithValue("@studId", StudentId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    flag = true;
                    MessageBox.Show("Roditelj je uspješno dodat !");
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
