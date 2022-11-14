using System.Collections.Generic;

namespace SPP_1.Tracing
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace(List<TraceResult> methods, string methodName, string className);

        TraceResult GetTraceResult();
    }
}
