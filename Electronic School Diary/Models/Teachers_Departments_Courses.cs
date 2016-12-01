using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Teachers_Departments_Courses
    {
        public int Id { get; set; }
        public int TeachersId { get; set; }
        public int DepartmentsId { get; set; }
        public int CoursesId { get; set; }
        
        public Teachers_Departments_Courses(int id, int teachersId, int departmentsId, int coursesId)
        {
            Id = id;
            TeachersId = teachersId;
            DepartmentsId = departmentsId;
            CoursesId = coursesId;
        }
    }
}
