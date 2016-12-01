using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int  Title { get; set; }
        public int TeachersId { get; set; }
        public int ClassesId { get; set; }

        public Department(int id, int title, int teachersId, int classesId)
        {
            Id = id;
            Title = title;
            TeachersId = teachersId;
            ClassesId = classesId;
        }
    }
}
