using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace Jogos_DAO_DAL
{
    public class BD_DAO_DAL
    {
        private static OleDbConnection objConnection;

        public static OleDbConnection gettObjConnection() 
        {
            if (objConnection == null)
            {
                objConnection = new OleDbConnection();
                objConnection.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            }
            return objConnection;
        }

        public static void AbreConn() 
        {
            if (gettObjConnection().State == ConnectionState.Closed)
            {
                objConnection.Open();
            }
        }

        public static void FechaConn()
        {
            if (gettObjConnection().State == ConnectionState.Open)
            {
                objConnection.Close();
                objConnection.Dispose();
                objConnection = null;
            }
        }

    }
}
