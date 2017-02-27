using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.IO;

namespace Audit
{
    public class OraHelper
    {
        public OracleConnection oracon;
        public string oraparam;
        public bool feedback;
        public string cache_dt_store = GDef.store_qztemp;
        public DateTime cache_dt_datebegin, cache_dt_dateend;
        public DataTable GetOrCacheTab(string tabname, string strsql, string store = null, DateTime? datebegin = null, DateTime? dateend = null)
        {
            string _store = store ?? this.cache_dt_store;
            DateTime _begin = datebegin ?? this.cache_dt_datebegin;
            DateTime _end = dateend ?? this.cache_dt_dateend;

            string filename = _store + GDef.store_dtprefix + tabname + _begin.ToString(GDef.date_tostring_format) + _end.ToString(GDef.date_tostring_format);
            DataTable dt;
            if (File.Exists(filename + "dt"))
            {
                dt = new DataTable();
                dt.ReadXmlSchema(filename + "sch");
                dt.ReadXml(filename + "dt");
            }
            else
            {
                dt = this.GetDataTable(strsql);
                dt.TableName = tabname;
                dt.WriteXmlSchema(filename + "sch");
                dt.WriteXml(filename + "dt");
            }
            return dt;
        }
        public OraHelper(string oraparam, bool feedback = false)
        {
            this.oraparam = oraparam;
            this.feedback = feedback;
        }
        //public OraHelper(string strcon, bool feedback = false)
        //{
        //    this.oracon = new OracleConnection(strcon);
        //    this.feedback = feedback;
        //}
        public OraHelper(OracleConnection oracon, bool feedback = false)
        {
            this.oracon = oracon;
            this.feedback = feedback;
        }

        public void Set_pdbqz_qzdata()
        {
            this.oracon = new OracleConnection("server = 10.5.67.11/pdbqz; user id = qzdata; password = qz9401tw");
        }

        public void Set_orcx_qzdata()
        {
            this.oracon = new OracleConnection("server = 127.0.0.1/pdbqz; user id = qzdata; password = xiexi51");
        }

        public void Set_pdbqz_dxtj()
        {
            this.oracon = new OracleConnection("server = 10.5.67.11/pdbqz; user id = dxtj; password = dxtjqztw");
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
            SqlGenerator sg = new SqlGenerator();
            DataTable dt = new DataTable();
            lock (this)
            {
                OracleDataAdapter oda = new OracleDataAdapter(sg.GenParamSql(ref this.oraparam, strsql), oracon);
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
