using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace ElectronicSchoolDiary.Repos
{
    class ParentRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static bool AddParent(string ParentName, string ParentSurname,string Address,string Email,string Phone_number,string jmbg, int departmentsId,
            string StudentName, string StudentSurname, string Jmbg, string Address1, string Phone_number1)
        {
            bool flag = false;
           
            try
            {
                if (Phone_number.Length > 0 && Information.IsNumeric(Phone_number) == false)
                {
                    MessageBox.Show("Broj telefona se sastoji samo od brojeva!");
                }
               
                else
                {
                   bool isStudentAdded = StudentRepository.AddStudent(StudentName, StudentSurname, Jmbg, Address1, Phone_number1,departmentsId);

                    if (isStudentAdded == true)
                    {
                        int StudentId = StudentRepository.GetIdByJmbg(jmbg);
                        SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Parents (Name,Surname,Address,Email,Phone_number,StudentsId)
                        VALUES (@name, @surname, @address, @email, @phone, @studId)", Connection);
                        command.Parameters.AddWithValue("@name", ParentName);
                        command.Parameters.AddWithValue("@surname", ParentSurname);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@email", Email);
                        command.Parameters.AddWithValue("@phone", Phone_number);
                        command.Parameters.AddWithValue("@studId", StudentId);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            flag = true;
                            MessageBox.Show("Roditelj je uspješno dodat !");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;

        }
        public static Parent GetParentByStudentId(int studentId)
        {
            Parent parent;
            SqlCeCommand command = new SqlCeCommand(@"SELECT Name, Surname, Address, Email, Phone_number FROM Parents WHERE StudentsId = @studId", Connection);
            command.Parameters.AddWithValue("@studId", studentId);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();
            string name = reader["Name"].ToString();
            string surname = reader["Surname"].ToString();
            string address = reader["Address"].ToString();
            string email = reader["Email"].ToString();
            string phone = reader["Phone_number"].ToString();
            parent = new Parent(name, surname, address, email, phone);
            reader.Close();

            return parent;
        }

    }
}
