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
        public static int GetIdByClassesId(int classesId)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Courses WHERE ClassesId = @classesid", Connection);
            command.Parameters.AddWithValue("@classesid", classesId);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            int result = (int)reader["Id"];
            reader.Close();

            return result;
        }


    }
}
