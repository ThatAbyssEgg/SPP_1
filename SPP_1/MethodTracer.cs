using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    public class MethodTracer : ITracer
    {
        Stopwatch sw = null;
        public TraceResult GetTraceResult(long traceTime)
        {
            TraceResult traceResult = new TraceResult();
            traceResult.MethodName = MethodBase.GetCurrentMethod().Name;
            traceResult.ClassName = this.GetType().Name;
            traceResult.ExecutionTime = traceTime;


            return traceResult;
        }

        public void StartTrace()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public long StopTrace()
        {
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
