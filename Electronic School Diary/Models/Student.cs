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
        public int Jmbg { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }


        public Student(string name, string surname, int jmbg, string address, string phone_number)
        {
            if (jmbg == 13)
            {
                if (phone_number != "" || phone_number.Length == 9)
                {
                    Name = name;
                    Surname = surname;
                    Jmbg = jmbg;
                    Address = address;
                    Phone_number = phone_number;
                }
                else throw new Exception("Unesite 9 brojeva za telefon.");
            }
            else if( jmbg != 13)
                throw new Exception("Jedinstveni matični broj se sastoji od 13 brojeva.");
        }
    }
}