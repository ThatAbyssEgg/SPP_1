using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SPP_1.Tracing;

namespace SPP_1
{
    public class MethodTracer : ITracer
    {
        Stopwatch sw = null;

        private TraceResult result;

        public TraceResult GetTraceResult()
        {
            return result;
        }

        public void StartTrace()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public void StopTrace(List<TraceResult> innerMethods, string methodName, string className)
        {
            sw.Stop();

            TraceResult traceResult = new TraceResult();
            traceResult.MethodName = methodName;
            traceResult.ClassName = className;
            traceResult.ExecutionTime = sw.ElapsedMilliseconds;
            if (innerMethods != null)
            {
                traceResult.InnerMethods = innerMethods;
            }

            result = traceResult;
        }
    }
}
