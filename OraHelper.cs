using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

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
                if (oracon.State != ConnectionState.Open)
                {
                    oracon.Open();
                }
                OracleCommand ocmd = new OracleCommand(strsql, this.oracon);
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
            //       TestConnection();
            object rtn;
            lock (this)
            {
                OracleCommand ocmd = new OracleCommand();
                ocmd.Connection = oracon;
                ocmd.CommandText = strsql;
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
            if (oracon.State != ConnectionState.Open)
            {
                throw new Exception("OracleHelper: oracle connection is not open");
            }
        }
        protected void FeedBack(string strsql)
        {
            int fdlen;
            if (strsql.Length <= 50)
                fdlen = strsql.Length;
            else
                fdlen = 50;
            System.Console.WriteLine("doing sql: " + strsql.Substring(0, fdlen) + " ...");
        }
    }
}
