using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UsersId { get; set; }

        public Director(int id, string name, string surname, int usersId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            UsersId = usersId;
        }
    }
}
