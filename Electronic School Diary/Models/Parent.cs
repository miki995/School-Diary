using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Parent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }


        public Parent( string name, string surname, string address,string email, string phone_number)
        {
            if (phone_number != "" || phone_number.Length == 9 )
            {
                Name = name;
                Surname = surname;
                Address = address;
                Email = email;
                Phone_number = phone_number;
            }
            else
                throw new Exception("Unesite 9 brojeva za telefon.");
        }
    }
}
