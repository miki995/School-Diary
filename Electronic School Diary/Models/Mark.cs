using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Mark
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public int StudentsId { get; set; }
        public int CoursesId { get; set; }




        public Mark(int id, int grade, DateTime date,int studentsId, int coursesId )
        {
            Id = id;
            Grade = grade;
            Date = date;
            StudentsId = studentsId;
            CoursesId = coursesId;
        }
    }
}
