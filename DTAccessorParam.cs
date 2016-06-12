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
        public DTAccessorParam(DTAccessorParamType type, string filename, bool save_tmp = false)
        { 
            this.type = type;
            this.filename = filename;
            this.save_tmp = save_tmp;
        }
    }

    public enum DTAccessorParamType
    {
        Add = 1,
        Save = 2
    }
}
