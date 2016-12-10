using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using ElectronicSchoolDiary.Models;
using ElectronicSchoolDiary.Repos;

namespace ElectronicSchoolDiary
{
    class Credentials
    {
        bool flag = false;

        public bool isNewFormOpened()
        {
            return flag;
        }
       
        
        public void  CheckLogin(TextBox Username, TextBox Password)
        {
           SqlCeConnection Connection = DataBaseConnection.Instance.Connection;
               if (Username.TextLength > 0 && Password.TextLength > 0)
                {
                    try
                    { 
                        SqlCeCommand logincommand = new SqlCeCommand(@"SELECT * FROM Users WHERE UserName=@uname and Password=@pass", Connection);
                        logincommand.Parameters.AddWithValue("@uname", Username.Text);
                        logincommand.Parameters.AddWithValue("@pass", Password.Text);
                        SqlCeDataReader loginReader = logincommand.ExecuteReader();
                    
                    if (loginReader.Read() &&
                            loginReader["UserName"].ToString() == Username.Text &&
                            loginReader["Password"].ToString() == Password.Text)
                        {
                        SqlCeCommand admincommand = new SqlCeCommand(@"SELECT * FROM Administration WHERE UsersId =@LoggedId", Connection);
                            admincommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader adminReader = admincommand.ExecuteReader(); //ADMIN

                            SqlCeCommand teachercommand = new SqlCeCommand(@"SELECT * FROM Teachers WHERE UsersId =@LoggedId", Connection);
                            teachercommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader teacherReader = teachercommand.ExecuteReader(); //TEACHER

                            SqlCeCommand directorcommand = new SqlCeCommand(@"SELECT * FROM Directors WHERE UsersId =@LoggedId", Connection);
                            directorcommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader directorReader = directorcommand.ExecuteReader(); //DIRECTOR

                        User user = new User((int)loginReader["Id"], (string)loginReader["UserName"], (string)loginReader["Password"]);
                       
                        if (adminReader.Read() && user.Id == (int)adminReader["UsersId"])
                            {
                                flag = true;
                            Admin admin = new Admin((int)adminReader["Id"], (string)adminReader["Name"], (string)adminReader["Surname"], (int)adminReader["UsersId"]);
                            Form newform = new AdministrationForm(user,admin);
                                 newform.Show();
                            }
                            else if (teacherReader.Read() && user.Id == (int)teacherReader["UsersId"])
                            {
                                  flag = true;
                            Teacher teacher = new Teacher((int)teacherReader["Id"], (string)teacherReader["Name"], (string)teacherReader["Surname"], (string)teacherReader["Address"], (string)teacherReader["Phone_number"], (int)teacherReader["UsersId"]);
                            Form newform = new TeacherForm(user,teacher);
                                 newform.Show();
                            }
                            else if (directorReader.Read() && user.Id == (int)directorReader["UsersId"])
                            {
                                 flag = true;
                            Director director = new Director((int)directorReader["Id"], (string)directorReader["Name"], (string)directorReader["Surname"], (int)directorReader["UsersId"]);
                            Form newform = new DirectorForm(user,director);
                                  newform.Show();
                            }
                            else
                            {
                                flag = false;
                                MessageBox.Show("Netacni podaci");
                            }
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("Netacni podaci");
                            Username.Text = "";
                            Password.Text = "";
                        
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                        MessageBox.Show("Neočekivana greška:" + ex.Message);
                    }
                }
        }
           
        }
    }                         

