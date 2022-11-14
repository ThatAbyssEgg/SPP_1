using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1.Tracing
{
    public class TraceResult
    {
        private string methodName;
        private string className;
        private long executionTime;
        private List<TraceResult> innerMethods;

        public string MethodName { get => methodName; set => methodName = value; }
        public string ClassName { get => className; set => className = value; }
        public long ExecutionTime { get => executionTime; set => executionTime = value; }
        public List<TraceResult> InnerMethods { get => innerMethods; set => innerMethods = value; }
    }
}
