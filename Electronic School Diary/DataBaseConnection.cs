using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary
{
    class DataBaseConnection
    {
        private static DataBaseConnection instance;

        private SqlCeConnection connection;

        private DataBaseConnection()
        {
            LoginForm logf = new LoginForm();
            string Dir = logf.GetHomeDirectory();
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString + "Data Source ='" + @Dir + "\\DataBase.sdf'";
            
            connection = new SqlCeConnection(connectionString);
            connection.Open();
        }

        public static DataBaseConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataBaseConnection();

                return instance;
            }
        }

        public SqlCeConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}