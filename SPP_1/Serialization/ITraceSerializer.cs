using SPP_1.Tracing;

namespace SPP_1.Serialization
{
    public interface ITraceSerializer
    {
        void Serialize(TraceResult traceResult);
    }
}
