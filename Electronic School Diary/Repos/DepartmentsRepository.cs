using ElectronicSchoolDiary.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary.Repos
{
    class DepartmentsRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

    
        public static string  GetQuery()
        {
            string query;
            query =  @"SELECT Title FROM Departments";
            return query;
         
        }
        public static int GetIdByTitle(int title, int ClassesId)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE Title = @title AND ClassesId = @classid", Connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@classid", ClassesId);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            int result = (int)reader["Id"];
            reader.Close();

            return result;
        }
        public static int GetIdByTitle(int title)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE Title = @title AND ClassesId = @classid", Connection);
            command.Parameters.AddWithValue("@title", title);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            int result = (int)reader["Id"];
            reader.Close();

            return result;
        }

        public static bool AddDepartment(int Title,int TeachersId, int ClassesId)
        {
            bool flag = false;
            try
            {
                    SqlCeCommand command1 = new SqlCeCommand(@"INSERT INTO Departments (Title, TeachersId, ClassesId)
                    VALUES (@title, @teachersid, @classesid)", Connection);
                    command1.Parameters.AddWithValue("@title", Title);
                    command1.Parameters.AddWithValue("@teachersid", TeachersId);
                    command1.Parameters.AddWithValue("@classesid", ClassesId);
                    int result = command1.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                        MessageBox.Show("Odjeljenje je uspješno dodato !");

                    int departmentsId = GetIdByTitle(Title, ClassesId);
                    int coursesId = CoursesRepository.GetIdByClassesId(ClassesId);
                    
                    Teachers_Departments_CoursesRepository.AddTeachers_Departments_Courses(TeachersId, departmentsId, coursesId);

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
