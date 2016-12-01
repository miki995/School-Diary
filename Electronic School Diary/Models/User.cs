using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       


        public User(int id, string username, string password)
        {
            Id = id;
            UserName = username;
            Password = password;
        }
    }
}
