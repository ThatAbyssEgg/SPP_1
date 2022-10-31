using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    public class MethodTrace
    {
        private readonly ITracer _tracer;
        private readonly CriticalRegister _criticalHit;

        internal MethodTrace(ITracer tracer)
        {
            _tracer = tracer;
            _criticalHit = new CriticalRegister(_tracer);
        }

        public void HitCounter()
        {
            _tracer.StartTrace();

            Console.WriteLine("Input the amount of d20s you'd like to roll.");
            
            
        }
    }

    public class CriticalRegister
    {
        private readonly ITracer _tracer;
        internal CriticalRegister(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void CriticalSuccess()
        {
            Console.WriteLine("Boom! You hit a twenty! What a lucky shot!");
        }

        public void CriticalFailure()
        {
            Console.WriteLine("Aww, you got -one-... Such a disappointment!");
        }
    }
}
