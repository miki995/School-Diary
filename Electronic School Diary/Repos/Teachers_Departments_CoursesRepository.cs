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
    class Teachers_Departments_CoursesRepository
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;


        public static void AddTeachers_Departments_Courses(int TeachersId, int DepartmentsId, int CoursesId)
        {
           
            try
            {
                SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Teachers_Departments_Courses (TeachersId, DepartmentsId, CoursesId)
                    VALUES (@teachersid, @depId, @coursesid)", Connection);
                command.Parameters.AddWithValue("@teachersid", TeachersId);
                command.Parameters.AddWithValue("@depId", DepartmentsId);
                command.Parameters.AddWithValue("@coursesid", CoursesId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Uspješno su povezani nastavnici,predmeti i odjeljenje !");
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }


    }
}
