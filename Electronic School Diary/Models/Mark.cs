using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Mark
    {
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public int StudentsId { get; set; }
        public int CoursesId { get; set; }
        
        public Mark(int grade, DateTime date,int studentsId, int coursesId )
        {
            Grade = grade;
            Date = date.Date;
            StudentsId = studentsId;
            CoursesId = coursesId;
        }
    }
}
