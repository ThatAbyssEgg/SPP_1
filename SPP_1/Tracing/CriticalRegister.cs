using System;
using System.Media;
using System.Reflection;

namespace SPP_1.Tracing
{
    public class CriticalRegister
    {
        private readonly ITracer _tracer;
        private readonly string className;

        public CriticalRegister(ITracer tracer)
        {
            _tracer = tracer;
            className = nameof(CriticalRegister);
        }

        public TraceResult CriticalSuccess()
        {
            _tracer.StartTrace();

            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer("success.wav");
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }

            Console.WriteLine("Boom! You hit a twenty! What a lucky shot!");

            var methodName = MethodBase.GetCurrentMethod().Name;

            _tracer.StopTrace(null, methodName, className);
            return _tracer.GetTraceResult();
        }

        public TraceResult CriticalFailure()
        {
            _tracer.StartTrace();

            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer("failure.wav");
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }

            Console.WriteLine("Aww, you got one... Such a disappointment!");

            var methodName = MethodBase.GetCurrentMethod().Name;

            _tracer.StopTrace(null, methodName, className);
            return _tracer.GetTraceResult();
        }
    }
}
