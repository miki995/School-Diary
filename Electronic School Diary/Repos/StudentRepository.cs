using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ElectronicSchoolDiary.Repos
{
    class StudentRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

       
        public static string GetQuery(int DepartmentId)
        {
            string query;
            query = @"SELECT Id, Name, Surname FROM Students WHERE DepartmentsId =" + DepartmentId;
            return query;
        }
        public static string GetNameQuery()
        {
            string query;
            query = @"SELECT Name,Surname FROM Students";
            return query;
        }
        public static string GetStudentIds( int departmentId)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Students WHERE DepartmentsId = @depid", Connection);
            command.Parameters.AddWithValue("@depid", departmentId);
            SqlCeDataReader reader = command.ExecuteReader();
            string m = "";
            while (reader.Read())
            {
                m += reader["Id"].ToString() + " ,";
            }
            return m.TrimEnd(',');
        }
        public static bool AddStudent(string StudentName, string StudentSurname, string Jmbg, string Address, string Phone_number,int departmentsId)
        {
            bool flag = false;

            try
            {
                if (Jmbg.Length != 13)
                {
                    MessageBox.Show("Jmbg mora sadrzati 13 brojeva!");
                }
                else if (Phone_number.Length > 0 && Information.IsNumeric(Phone_number) == false)
                {
                    MessageBox.Show("Broj telefona se sastoji samo od brojeva!");
                }
                else
                {
                    bool isUnique = CheckUnique(Jmbg);
                    if (isUnique == false)
                    {
                        int DepartmentId = DepartmentsRepository.GetIdByTitle(departmentsId);
                        SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Students (Name,Surname,Jmbg,Address,Phone_number,DepartmentsId)
                    VALUES (@name, @surname, @jmbg, @address, @phone, @depId)", Connection);
                        command.Parameters.AddWithValue("@name", StudentName);
                        command.Parameters.AddWithValue("@surname", StudentSurname);
                        command.Parameters.AddWithValue("@jmbg", Jmbg);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@phone", Phone_number);
                        command.Parameters.AddWithValue("@depId", DepartmentId);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            flag = true;
                            MessageBox.Show("Učenik je uspješno dodat !");
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

        public static int GetIdByJmbg(string jmbg)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Students WHERE Jmbg = @jmbg", Connection);
                command.Parameters.AddWithValue("@jmbg", jmbg);
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
        public static Student GetStudentByName(string name, string surname)
        {
            Student student = null;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Jmbg,Address,Phone_number FROM Students WHERE name = @name AND surname = @surname", Connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string jmbg = reader["Jmbg"].ToString();
                    string address = reader["Address"].ToString();
                    string phone = reader["Phone_number"].ToString();
                    student = new Student(name, surname, jmbg, address, phone);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return student;
        }
        public static int GetDepartmentIdByStudent(Student student)
        {
            int depId = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT DepartmentsId FROM Students WHERE Jmbg = @jmbg", Connection);
                command.Parameters.AddWithValue("@jmbg", student.Jmbg);
                SqlCeDataReader reader = command.ExecuteReader();

                reader.Read();
                 depId = (int)reader["DepartmentsId"];
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return depId;

        }
        public static bool CheckUnique(string jmbg)
        {
            bool flag = false;
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"SELECT Jmbg FROM Students 
                    WHERE @jmbg = Jmbg", Connection);
                command.Parameters.AddWithValue("@jmbg", jmbg);
                SqlCeDataReader reader = command.ExecuteReader();
                if (reader.Read() && reader["Jmbg"].ToString() == jmbg)
                {
                    flag = true;
                    MessageBox.Show("Jmbg   " + "'" + jmbg + "'" + "  već postoji !");
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
