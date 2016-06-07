using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audit
{
    public class ReportWriterParam
    {
        public string filename;
        public DataTable dt_logs, dt_check, dt_units, dt_itemloginfo;
    }
}
