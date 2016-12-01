using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
   public  class Section
    {
        public string Description { get; set; }

        public Section( string description)
        {
            Description = description;
        }
    }
}
