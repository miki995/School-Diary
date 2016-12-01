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
    class SectionsRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;


        public static string GetQuery()
        {
            string query;
            query = @"SELECT Description FROM Sections";
            return query;

        }

        public static bool InsertSection(string SectionName)
        {
            bool flag = false;
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Sections (Description)
                    VALUES (@description)", Connection);
                    command.Parameters.AddWithValue("@description", SectionName);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                        MessageBox.Show("Smjer : " + SectionName + " je uspješno dodat !");
                    }
                
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message);
            }
            return flag;
        }
        public static bool CheckUnique(string SectionName)
        {
            bool flag = false;
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"SELECT Id FROM Sections 
                    WHERE @description = Description", Connection);
                command.Parameters.AddWithValue("@description", SectionName);
                SqlCeDataReader reader = command.ExecuteReader();
                if (reader.Read() && (int)reader["Id"] > 0)
                {
                    flag = true;
                    MessageBox.Show("Smjer : " + "'" + SectionName + "'" + "  već postoji !");
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
