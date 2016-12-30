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
        public static int GetIdByTeacherId(int TeachersId)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE TeachersId = @teachid", Connection);
                command.Parameters.AddWithValue("@teachid", TeachersId);
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

        public static int GetIdByTitle(int title, int ClassesId)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE Title = @title AND ClassesId = @classid", Connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@classid", ClassesId);
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
        public static int GetIdByTitle(int title)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE Title = @title", Connection);
                command.Parameters.AddWithValue("@title", title);
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
        public static int GetTitleById(int id)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Title FROM Departments WHERE Id = @id", Connection);
                command.Parameters.AddWithValue("@id", id);
                SqlCeDataReader reader = command.ExecuteReader();

                reader.Read();

                result = (int)reader["Title"];
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        public static int GetId(int teacherId)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Departments WHERE TeachersId = @tid", Connection);
                command.Parameters.AddWithValue("@tid", teacherId);
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
