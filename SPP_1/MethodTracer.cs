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
        public TraceResult GetTraceResult(TraceResult traceResult)
        {
            Console.WriteLine("Class name: " + traceResult.ClassName);
            Console.WriteLine("Method name: " + traceResult.MethodName);
            Console.WriteLine("Execution time: " + traceResult.ExecutionTime + "ms");
            Console.WriteLine();

            if (traceResult.InnerMethods != null)
            {
                Console.WriteLine("Contains inner methods: {");
                for (int i = 0; i < traceResult.InnerMethods.Count; i++)
                {
                    GetTraceResult(traceResult.InnerMethods[i]);
                }
                Console.WriteLine("}");
            }


            return traceResult;
        }

        public void StartTrace()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public TraceResult StopTrace(List<TraceResult> innerMethods, string methodName, string className)
        {
            sw.Stop();
            TraceResult traceResult = new TraceResult();
            //traceResult.MethodName = MethodBase.GetCurrentMethod().Name;
            traceResult.MethodName = methodName;
            //traceResult.ClassName = this.GetType().Name;
            traceResult.ClassName = className;
            traceResult.ExecutionTime = sw.ElapsedMilliseconds;
            if (innerMethods != null)
            {
                traceResult.InnerMethods = innerMethods;
            }
            return traceResult;
        }
    }
}
