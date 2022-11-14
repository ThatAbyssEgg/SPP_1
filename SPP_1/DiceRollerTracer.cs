using System;
using System.Collections.Generic;
using System.Reflection;
using SPP_1.DiceRolling;
using SPP_1.Serialization;
using SPP_1.Tracing;

// All the sounds were taken from freesound.org
namespace SPP_1
{
    public class DiceRollerTracer
    {
        public const int MaxDiceValue = 20;
        public const int MinDiceValue = 1;

        private readonly ITracer _tracer;
        private readonly IDiceRoller _diceRoller;
        private readonly CriticalRegister _criticalRegister;
        private readonly List<TraceResult> _innerMethods = new List<TraceResult>();

        public DiceRollerTracer(ITracer tracer, IDiceRoller diceRoller)
        {
            _tracer = tracer;
            _diceRoller = diceRoller;
            _criticalRegister = new CriticalRegister(_tracer);
        }

        public TraceResult TraceResult => _tracer.GetTraceResult();

        public void RollDice(int numberOfRolls)
        {
            _tracer.StartTrace();

            for (int i = 0; i < numberOfRolls; i++)
            {
                int currentRoll = _diceRoller.Roll(MinDiceValue, MaxDiceValue);
                if (currentRoll == MaxDiceValue)
                {
                    _innerMethods.Add(_criticalRegister.CriticalSuccess());
                }
                else if (currentRoll == MinDiceValue)
                {
                    _innerMethods.Add(_criticalRegister.CriticalFailure());
                }
            }

            var methodName = MethodBase.GetCurrentMethod().Name;
            var className = nameof(DiceRollerTracer);

            _tracer.StopTrace(_innerMethods, methodName, className);
        }

        public void SerializeResult(ITraceSerializer traceSerializer)
        {
            if (TraceResult == null)
            {
                //
                throw new Exception("Пщшел нахуй");
            }

            traceSerializer.Serialize(TraceResult);
        }
    }
}
