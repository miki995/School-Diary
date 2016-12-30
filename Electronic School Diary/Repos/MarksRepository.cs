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
    class MarksRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

       
        public static string GetMarks(int studentId, int courseId)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Mark FROM Marks WHERE StudentsId = @studId AND CoursesId = @courseId ORDER BY Date", Connection);
            command.Parameters.AddWithValue("@studId", studentId);
            command.Parameters.AddWithValue("@courseId", courseId);
            SqlCeDataReader reader = command.ExecuteReader();
            string m = "";
            while (reader.Read())
            {
                m += reader["Mark"].ToString() + " ,";
            }
            return m;
        }
        public static string GetMarks(int studentId)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Mark FROM Marks WHERE StudentsId = @studId ORDER BY Date", Connection);
            command.Parameters.AddWithValue("@studId", studentId);
            SqlCeDataReader reader = command.ExecuteReader();
            string m = "";
            while (reader.Read())
            {
                m += reader["Mark"].ToString() + " ,";
            }
            return m;
        }

        public static bool InsertMark(int mark, int studentsId, int coursesId)
        {
            bool flag = false;
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Marks (Mark, Date, StudentsId, CoursesId)
                    VALUES (@mark, @date, @studentsid, @coursesid)", Connection);
                command.Parameters.AddWithValue("@mark", mark);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@studentsid", studentsId);
                command.Parameters.AddWithValue("@coursesid", coursesId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    flag = true;
                    MessageBox.Show("Ocjena  : " + mark + " je uspješno dodata !");
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
