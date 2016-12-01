using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ClassesId { get; set; }
       


        public Course(int id, string title, int classesId)
        {
            Id = id;
            Title = title;
            ClassesId = classesId;
        }
    }
}
