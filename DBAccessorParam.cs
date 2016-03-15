using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class DBAccessorParam
    {
        public DBAccessorParamType type;
        public Rule rl;
        public GSetRule gs;
    }

    public enum DBAccessorParamType
    {
        Rule = 1,
        GSetRule = 2,
        GSetWriteDb = 3,
        GSetReadDb = 4
    }
}
