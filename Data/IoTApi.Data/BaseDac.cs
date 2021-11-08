using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace IoTApi.Data
{
    public class BaseDac
    {
        public SqlConnection ObjConnection
        {
            get
            {
                
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetTracker"].ConnectionString);
                myConn.Open();
                return myConn;
            }
        }
    }
}
