namespace SPP_1
{
    public struct TraceResult
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

    public interface ITracer
    {
        void StartTrace();

        TraceResult StopTrace(List<TraceResult> methods, string methodName, string className);

        TraceResult GetTraceResult(TraceResult traceResult);

    }
}
