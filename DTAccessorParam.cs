using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class DTAccessorParam
    {
        public string filename;
        public DTAccessorParamType type;
        public bool save_tmp;
        public DTAccessorParam() { save_tmp = false; }
    }

    public enum DTAccessorParamType
    {
        Add = 1,
        Save = 2
    }
}
