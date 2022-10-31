using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    public struct TraceResult
    {

    }

    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();

    }
}
