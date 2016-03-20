using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class ReloadDtParam
    {
        public bool use_file;
        public ReloadDtParamType type;
        public ReloadDtParam(bool use_file, ReloadDtParamType type) { this.use_file = use_file; this.type = type; }
    }

    public enum ReloadDtParamType
    {
        Unit = 1,
        Item = 2,
        AbType = 3,
        AbType2 = 4,
        Station = 5
    }
}
