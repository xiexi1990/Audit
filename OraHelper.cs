using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;

namespace Audit
{
    public class OraHelper
    {
        public OracleConnection oracon;
        public bool feedback;
        public OraHelper(string strcon, bool feedback = false)
        {
            this.oracon = new OracleConnection(strcon);
            this.feedback = feedback;
        }
        public OraHelper(OracleConnection oracon, bool feedback = false)
        {
            this.oracon = oracon;
            this.feedback = feedback;
        }
        public int ExecuteNonQuery(string strsql)
        {
            int rtn;
            lock (this)
            {
                OracleCommand ocmd = new OracleCommand(strsql, this.oracon);
                TestConnection();
                rtn = ocmd.ExecuteNonQuery();
            }
            return rtn;
        }
        public int GetInt32(string strsql)
        {
            return Convert.ToInt32(GetSingleValue(strsql));
        }
        public decimal GetDecimal(string strsql)
        {
            return Convert.ToDecimal(GetSingleValue(strsql));
        }
        public object GetSingleValue(string strsql)
        {
            object rtn;
            lock (this)
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.Connection = oracon;
                ocmd.CommandText = strsql;
                TestConnection();
                if (feedback)
                {
                    FeedBack(strsql);
                }
                rtn = ocmd.ExecuteScalar();
            }
            return rtn;
        }
        public DataTable GetDataTable(string strsql)
        {
            DataTable dt = new DataTable();
            lock (this)
            {
                OracleDataAdapter oda = new OracleDataAdapter(strsql, oracon);
                TestConnection();
                if (feedback)
                {
                    FeedBack(strsql);
                }
                oda.Fill(dt);
            }
            return dt;
        }
        protected void TestConnection()
        {
            while(oracon.State != ConnectionState.Open)
            {
                Debug.WriteLine("OracleHelper: oracle connection is not open, try to open");
                oracon.Open();
            }
        }
        protected void FeedBack(string strsql)
        {
            int fdlen;
            if (strsql.Length <= 50)
                fdlen = strsql.Length;
            else
                fdlen = 50;
            Debug.WriteLine("doing sql: " + strsql.Substring(0, fdlen) + " ...");
        }
    }
}
