using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }
        public int UsersId { get; set; }



        public Teacher(int id, string name, string surname, string address, string phone_number, int usersid)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            Phone_number = phone_number;
            UsersId = usersid;

        }
    }
}
