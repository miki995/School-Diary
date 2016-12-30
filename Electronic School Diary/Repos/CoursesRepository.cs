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
    class CoursesRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;


        public static string GetQuery()
        {
            string query;
            query = @"SELECT Title FROM Courses";
            return query;
        }
      
        public static string GetQuery(string CoursesIds)
        {
            string query;
            query = @"SELECT Title FROM Courses WHERE Id IN" + CoursesIds;
            return query;
        }

        public static string GetCoursesId()
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Courses", Connection);
            SqlCeDataReader reader = command.ExecuteReader();
            string coursesid = "";
            while (reader.Read())
            {
                coursesid += reader["Id"].ToString() + " ,";
            }
            return coursesid;
        }
        public static int GetIdByClassesId(int classesId)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Courses WHERE ClassesId = @classesid", Connection);
                command.Parameters.AddWithValue("@classesid", classesId);
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
        public static int GetIdByTitle(string title)
        {
            int result = -1;
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Courses WHERE Title = @title", Connection);
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
        public static bool AddCourse(string Title, int ClassesId)
        {
            bool flag = false;
            try
            {
                int classesId = ClassesRepository.GetIdByNumber(ClassesId);
                SqlCeCommand command1 = new SqlCeCommand(@"INSERT INTO Courses (Title, ClassesId)
                    VALUES (@title, @classesid)", Connection);
                command1.Parameters.AddWithValue("@title", Title);
                command1.Parameters.AddWithValue("@classesid", classesId);
                int result = command1.ExecuteNonQuery();
                if (result > 0)
                {
                    flag = true;
                    MessageBox.Show("Predmet je uspješno dodat !");

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
