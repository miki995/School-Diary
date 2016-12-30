using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary
{
    public class Lists
    {
        private static SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

        public static void FillDropDownList1(string Query,string column, ComboBox DropDownName )
        {
         
            try
            {
                if (DropDownName.Items.Count > 0)
                {
                    DropDownName.Items.Clear();
                    SqlCeCommand cmd = new SqlCeCommand(Query, Connection);
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        DropDownName.Items.Add(reader[column].ToString());
                        DropDownName.SelectedIndex = 0;
                        reader.Close();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message.ToString());
            }
        }
        
        public static void FillDropDownList2(string Query1,string column1,string Query2,string column2, ComboBox DropDownName)
        {

            try
            {
                if (DropDownName.Items.Count > 0)
                {
                    DropDownName.Items.Clear();
                    SqlCeCommand cmd1 = new SqlCeCommand(Query1, Connection);
                    SqlCeCommand cmd2 = new SqlCeCommand(Query2, Connection);
                    SqlCeDataReader reader1 = cmd1.ExecuteReader();
                    SqlCeDataReader reader2 = cmd2.ExecuteReader();
                    while(reader1.Read() && reader2.Read())
                        DropDownName.Items.Add(reader1[column1].ToString() + "-" + reader2[column2].ToString());
                        DropDownName.SelectedIndex = 0;
                        reader1.Close();
                        reader2.Close();
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }
      
    }
}
