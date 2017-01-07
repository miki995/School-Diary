using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ElectronicSchoolDiary.Models;
using ElectronicSchoolDiary.Repos;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Security.Permissions;

namespace ElectronicSchoolDiary
{  
    public partial class TeacherForm : Form
    {
        private User CurrentUser;
        private Teacher CurrentTeacher;
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public void Warning()
        {
            MessageBox.Show("Polja ne mogu biti prazna !");
        }

        public TeacherForm(User user, Teacher teacher)
        {
            InitializeComponent();
            this.Text = "Nastavnik : " + teacher.Name + " " + teacher.Surname;
            CurrentUser = user;
            CurrentTeacher = teacher;
        }
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
            PasswordPanel.Hide();
            ControlBox = false;
            TrueFalseAbsentComboBox.SelectedIndex = 1;
            AbsentHourComboBox.SelectedIndex = 0;
            MarkComboBox.SelectedIndex = 0;
            ParentMeetingDateTimePicker.MinDate = DateTime.Now;
            TimeComboBox.SelectedIndex = 0;
            bool isStudentsAdded =  PopulateStudentsComboBox();
            if (isStudentsAdded)
            {
                FillStudentInfoLabels();
                FillParentInfoLabels();
                FillStudentAbsents();
               bool isCoursesAdded =  PopulateCoursesComboBox();
                if (isCoursesAdded)
                {
                    FillStudentMarks();
                }
            }
        }
        private bool PopulateStudentsComboBox()
        {
            bool flag = false;
            try
            {
                int TeacherId = CurrentTeacher.Id;
                int DepartmentId = DepartmentsRepository.GetIdByTeacherId(TeacherId);
                string Name = StudentRepository.GetQuery(DepartmentId);
                Lists.FillDropDownList2(Name, "Name", Name, "Surname", StudentsBox);
                flag = true;
            }
            catch(Exception e)
            {   
                MessageBox.Show(e.Message);
            }
            return flag;
        }  
        private bool PopulateCoursesComboBox()
        {
            bool flag = false;
            try
            { 
               string CoursesId = Teachers_Departments_CoursesRepository.GetCoursesId(CurrentTeacher.Id);
               string Title = CoursesRepository.GetQuery("(" + CoursesId.TrimEnd(',')+ ")");
               Lists.FillDropDownList1(Title, "Title", CoursesBox);
                flag = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return flag;
        }
        private Student CurrentStudent()
        {
            Student student = null;
            try
            {
                string currentStudentName;
                string currentStudentSurname;
         
                string[] parts = StudentsBox.Text.Split('-');
                currentStudentName = parts[0];
                currentStudentSurname = parts[1];
                student = StudentRepository.GetStudentByName(currentStudentName, currentStudentSurname);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return student;
        }
        private Parent CurrentParent()
        {
            Parent parent;
            Student student = CurrentStudent();
            int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
            parent = ParentRepository.GetParentByStudentId(studentId);
            return parent;
        }
        private int GetCurrentMark()
        {
            return MarkComboBox.SelectedIndex;
        }
        private string GetCurrentCourse()
        {
            return CoursesBox.Text;
        }
      
        private void FillStudentMarks()
        {
            try
            {
                Student student = CurrentStudent();
                int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
                int courseId = CoursesRepository.GetIdByTitle(GetCurrentCourse());
                string marks = MarksRepository.GetMarks(studentId, courseId);
                MarksLabel.Text = marks;
                string[] parts = marks.Split(',');
                if (parts.Length > 0)
                {
                    AverageMarkLabel.Text = CalculateAverageGrade(parts);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void FillStudentAbsents()
        {
            try
            {
                Student student = CurrentStudent();
                int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
                int justifiedAbsents = AbsentsRepository.GetAbsents(studentId, 1);
                int unjustifiedAbsents = AbsentsRepository.GetAbsents(studentId, 0);
                JustifiedAbsentLabel.Text = justifiedAbsents.ToString();
                UnjustifiedAbsentLabel.Text = unjustifiedAbsents.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public string CalculateAverageGrade(string[] parts)
        {
            float sum = 0;
                for (int i = 0; i < parts.Length - 1 ; i++)
                {
                    sum += float.Parse(parts[i]);
                }
            float average = sum / (parts.Length -1);

            return average.ToString("0.00");
        }
        private void FillStudentInfoLabels()
        {
            try
            {
                Student student = CurrentStudent();
                int departmentId = StudentRepository.GetDepartmentIdByStudent(student);
                int departmentTitle = DepartmentsRepository.GetTitleById(departmentId);
                StudentNameLabel.Text = student.Name;
                StudentSurnameLabel.Text = student.Surname;
                StudentJmbgLabel.Text = student.Jmbg.ToString();
                StudentAddressLabel.Text = student.Address;
                StudentPhoneLabel.Text = student.Phone_number;
                DepartmentLabel.Text = departmentTitle.ToString();
            }
            catch (Exception e )
            {

                MessageBox.Show(e.Message);
            }
        }
        private void FillParentInfoLabels()
        {
            try
            { 
            Parent parent = CurrentParent();
            ParentNameLabel.Text = parent.Name;
            ParentSurnameLabel.Text = parent.Surname;
            ParentAddressLabel.Text = parent.Address;
            ParentEmailLabel.Text = parent.Email;
            ParentPhoneLabel.Text = parent.Phone_number;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void LogOutUserButton_Click(object sender, EventArgs e)
        {
                Form form = new LoginForm();
                form.Show();
                this.Close();
        }

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            PasswordPanel.Show();
        }

        private void MarksLabel_Click(object sender, EventArgs e)
        {

        }

        private void JustifiedAbsentLabel_Click(object sender, EventArgs e)
        {

        }

        private void UnjustifiedAbsentLabel_Click(object sender, EventArgs e)
        {

        }

        private void PrintStatisticTeacherRoundedButton_Click(object sender, EventArgs e)
        {
            int columnNumber = 6;
            PdfPTable table = new PdfPTable(columnNumber)
            {
                //actual width of table in points
                TotalWidth = 400f,
                //fix the absolute width of the table
                LockedWidth = true
            };

            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 1f, 1f, 1f, 1f, 1f, 1f};
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            //leave a gap before and after the table
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell(new Phrase("Ucenici"))
            {
                Colspan = columnNumber,
                Border = 0,
                HorizontalAlignment = 1
            };
            table.AddCell(cell);

            table.AddCell("Ime");
            table.AddCell("Prezime");
            table.AddCell("Odsustva(U)");
            table.AddCell("Odsustva(O)");
            table.AddCell("Odsustva(N)");
            table.AddCell("Prosjek");



            int TeacherId = CurrentTeacher.Id;
            int DepartmentId = DepartmentsRepository.GetIdByTeacherId(TeacherId);
            string StudentsQuery = StudentRepository.GetQuery(DepartmentId);

            SqlCeCommand cmd = new SqlCeCommand(StudentsQuery, Connection);
            SqlCeDataReader reader = cmd.ExecuteReader();
         

            try
            {
                while (reader.Read())
                {
                    int justifiedAbsents = AbsentsRepository.GetAbsents((int)reader["Id"], 1);
                    int unJustifiedAbsents = AbsentsRepository.GetAbsents((int)reader["Id"], 0);
                    int sum = justifiedAbsents + unJustifiedAbsents;

                    string CoursesId = CoursesRepository.GetCoursesId();
                    string[] parts = CoursesId.Split(',');
                    int suum = 0;
                    for (int i = 0; i < parts.Length ; i++)
                    {
                        string marks = MarksRepository.GetMarks((int)reader["Id"]);
                        string[] particles = marks.Split(',');
                        double mark =  Math.Round(float.Parse(CalculateAverageGrade(particles)), MidpointRounding.AwayFromZero);
                      
                        suum += (int)mark;
                    }
                    
                    float average = suum / (parts.Length);

                    string averageMark = average.ToString("0.00") + "(" + Math.Round(average, MidpointRounding.AwayFromZero) + ")";

                    table.AddCell(reader["Name"].ToString());
                    table.AddCell(reader["Surname"].ToString());
                    table.AddCell(sum.ToString());
                    table.AddCell(justifiedAbsents.ToString());
                    table.AddCell(unJustifiedAbsents.ToString());
                    table.AddCell(averageMark);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoginForm logf = new LoginForm();
            string Dir = logf.GetHomeDirectory();
            
                    FileStream fs = new FileStream("report.pdf", FileMode.Create);
                    
                    Document doc = new Document(PageSize.A4);
                    PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    doc.Add(table);
                    while (reader.Read())
                    {
                        doc.Add(new Paragraph(reader[0].ToString() + reader[1].ToString() + reader[2].ToString()));
                    }

                    pdfWriter.CloseStream = true;
                    doc.Close();

                    
                    Process.Start("report.pdf");
        }

        private void ControlTableButton_Click(object sender, EventArgs e)
        {
            PasswordPanel.Hide();
        }

        private void AddTeacherPasswordButton_Click(object sender, EventArgs e)
        {
            if (OldPassTextBox.Text.Length == 0 ||
                 NewPassTextBox.Text.Length == 0 ||
                 ConfirmedNewPassTextBox.Text.Length == 0)
            {
                Warning();
            }
            else
            {
                if (OldPassTextBox.Text == NewPassTextBox.Text)
                {
                    MessageBox.Show("Unesite novu lozinku koja se razlikuje od stare !");
                }
                else if (Encrypt.hashPassword(OldPassTextBox.Text) == CurrentUser.Password && NewPassTextBox.Text == ConfirmedNewPassTextBox.Text)
                {
                   bool isChanged = UsersRepository.ChangePassword(CurrentUser.Id, OldPassTextBox.Text, NewPassTextBox.Text, ConfirmedNewPassTextBox.Text);
                  if(isChanged == true)
                    {
                        PasswordPanel.Hide();
                        UserSettingsButton.Hide();
                    }
                }
                else if (NewPassTextBox.Text != ConfirmedNewPassTextBox.Text)
                    MessageBox.Show("Nove lozinke se ne poklapaju !");
                else MessageBox.Show("Pogrešna lozinka !");

            }
        }

        private void AddMarkButton_Click(object sender, EventArgs e)
        {
           int mark = int.Parse(MarkComboBox.SelectedItem.ToString());
            Student student = CurrentStudent();
            int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
            int courseId = CoursesRepository.GetIdByTitle(GetCurrentCourse());
            bool isMarkAdded = MarksRepository.InsertMark(mark, studentId, courseId);
            if(isMarkAdded)
            {
                FillStudentMarks();
            }
        }

        private void StudentsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentInfoLabels();
            FillParentInfoLabels();
            FillStudentAbsents();
            PopulateCoursesComboBox();// ->> Nedded here because fillstudentmarks()  throws error No data exists for the row/column
            FillStudentMarks();
        }

        private void CoursesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentMarks();
        }

        private void AddAbsentButton_Click(object sender, EventArgs e)
        {
            Student student = CurrentStudent();
            int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
            int hours = int.Parse(AbsentHourComboBox.SelectedItem.ToString());
            bool justified = false;
            if (TrueFalseAbsentComboBox.Text == "Opravdano")
            {
                justified = true;
            }
            bool isAbsentAdded = AbsentsRepository.InsertAbsent(hours, justified, studentId);
            if (isAbsentAdded)
            {
                FillStudentAbsents();
            }
        }
        private void SendEmail(string confirmed_canceled)
        {
            string date = ParentMeetingDateTimePicker.Value.ToShortDateString();
            string time = TimeComboBox.Text;
            string SchoolMail = "ednevniik@gmail.com";
            string SchoolName = "Skola";
            string SchoolMailPassword = "ednevnikus";

            int TeacherId = CurrentTeacher.Id;
            int DepartmentId = DepartmentsRepository.GetIdByTeacherId(TeacherId);
            string StudentIds = StudentRepository.GetStudentIds(DepartmentId);
            string[] parts = StudentIds.Split(',');
            Email email = new Email();
            for (int i = 0; i < parts.Length; i++)
            {
                Parent CurrentParent = ParentRepository.GetParentByStudentId(int.Parse(parts[i]));
                string currentParentEmail = CurrentParent.Email;
                string currentParentName = CurrentParent.Name;
                string message = "Poštovani " + CurrentParent.Name + " " + CurrentParent.Surname + "\n"
                    + "Obavještavam Vas da je" + " " + confirmed_canceled + " " + "roditeljski sastanak dana " + date + " u " + time
                    + "\n" + "Nastavnik : " + CurrentTeacher.Name + " " + CurrentTeacher.Surname
                    ;
                email.SendEmailInBackground(SchoolMail, SchoolName, SchoolMailPassword, currentParentEmail, currentParentName, message);
            }
            MessageBox.Show("Roditelji su uspješno obaviješteni");
           
        }

        private void ConfirmMeetingRoundedButton_Click(object sender, EventArgs e)
        {
            SendEmail("zakazan");
            CancelMeetingRoundedButton.Show();
        }

        private void CancelMeetingRoundedButton_Click(object sender, EventArgs e)
        {
            SendEmail("otkazan");
            CancelMeetingRoundedButton.Hide();
        }
    }
}