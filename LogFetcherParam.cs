using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class LogFetcherParam
    {
        public LogFetcherParamType type;
        public Rule rl;
        public GSetRule gs;
    }

    public enum LogFetcherParamType
    {
        Rule = 1,
        GSetRule = 2
    }
}
