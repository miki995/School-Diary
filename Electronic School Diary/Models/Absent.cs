using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Absent
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public bool Justified { get; set; }
        public DateTime Date { get; set; }
        public int StudentsId { get; set; }




        public Absent(int id, int hour, bool justified,DateTime date, int studentsId )
        {
            Id = id;
            Hour = hour;
            Justified = justified;
            Date = date;
            StudentsId = studentsId;
        }
    }
}
