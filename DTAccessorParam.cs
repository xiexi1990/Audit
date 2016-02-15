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
        private bool is_read; /// abolish
        public int DTAP_mode;
        public const int DTAP_add = 1, DTAP_save = 2;
    }
}
