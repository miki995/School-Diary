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
    class AbsentsRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

      
        public static int GetAbsents(int studentId, int isjustified)
        {
            SqlCeCommand command = new SqlCeCommand(@"SELECT Hour FROM Absents WHERE StudentsId = @studId AND Justified = @just", Connection);
            command.Parameters.AddWithValue("@studId", studentId);
            command.Parameters.AddWithValue("@just", isjustified);
            SqlCeDataReader reader = command.ExecuteReader();
            int m = 0;
            while (reader.Read())
            {
                m += int.Parse(reader["Hour"].ToString());
            }
            return m;
        }
        public static bool InsertAbsent(int hours, bool justified,  int studentsId)
        {
            bool flag = false;
            try
            {

                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Absents (Hour, Justified, Date, StudentsId)
                    VALUES (@hour, @justified, @date, @studentsid)", Connection);
                command.Parameters.AddWithValue("@hour", hours);
                command.Parameters.AddWithValue("@justified", justified);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@studentsid", studentsId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    flag = true;
                    MessageBox.Show("Odsustvo sa : " + hours + " časova je uspješno dodato !");
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
