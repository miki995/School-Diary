using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Class
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int SectionsId { get; set; }
       


        public Class(int id, string number, int sectionsId)
        {
            Id = id;
            Number = number;
            SectionsId = sectionsId;
        }
    }
}
