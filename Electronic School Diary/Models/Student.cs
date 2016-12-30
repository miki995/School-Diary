using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }


        public Student(string name, string surname, string jmbg, string address, string phone_number)
        {
            if (jmbg.Length == 13)
            {
                if (phone_number.Length != 0 || phone_number.Length == 9)
                {
                    Name = name;
                    Surname = surname;
                    Jmbg = jmbg;
                    Address = address;
                    Phone_number = phone_number;
                }
                else if(phone_number.Length > 0 && phone_number.Length != 9) throw new Exception("Unesite 9 brojeva za telefon.");
            }
            else if( jmbg.Length != 13)
                throw new Exception("Jedinstveni matični broj se sastoji od 13 brojeva.");
        }
    }
}