﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Reflection;


// All the sounds were taken from freesound.org

namespace SPP_1
{
    public class DiceMechsRealization
    {
        private long traceTime;
        private readonly ITracer _tracer;
        private readonly CriticalRegister _criticalRegister;
        private List<TraceResult> innerMethods = new List<TraceResult>();
        private string methodName;
        private string className;

        private const int MAX_DICE_VALUE = 20;
        private const int MIN_DICE_VALUE = 1;

        public bool IsJsonOutput()
        {
            Console.WriteLine("Choose input method:");
            Console.WriteLine("0: XML");
            Console.WriteLine("1: JSON");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                return true;
            }
            else if (userChoice == "0")
            {
                return false;
            }
            else
            {
                throw new Exception("Wrong input.");
            }
        }

        internal DiceMechsRealization(ITracer tracer)
        {
            _tracer = new MethodTracer();
            _criticalRegister = new CriticalRegister(_tracer);
        }

        public void HitCounter()
        {
            _tracer.StartTrace();

            Console.WriteLine("Input the amount of d20s you'd like to roll.");
            int diceRolls = Convert.ToInt32(Console.ReadLine());

            int currentRoll;
            Random random = new Random();
            for (int i = 0; i < diceRolls; i++)
            {
                currentRoll = random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE + 1);

                if (currentRoll == MAX_DICE_VALUE)
                {
                    innerMethods.Add(_criticalRegister.CriticalSuccess());
                }
                else if (currentRoll == MIN_DICE_VALUE)
                {
                    innerMethods.Add(_criticalRegister.CriticalFailure());
                }
            }

            methodName = MethodBase.GetCurrentMethod().Name;
            className = this.GetType().Name;

            TraceResult result = _tracer.GetTraceResult(_tracer.StopTrace(innerMethods, methodName, className));

            if (IsJsonOutput())
            {
                JsonSerialize jsonSerialize = new JsonSerialize();
                jsonSerialize.Serialize(result);
            }
            else
            {
                XMLSerialize xmlSerialize = new XMLSerialize();
                xmlSerialize.Serialize(result);
            }


        }
    }

    public class CriticalRegister
    {
        private readonly ITracer _tracer;
        private string methodName;
        private string className;

        internal CriticalRegister(ITracer tracer)
        {
            _tracer = new MethodTracer();
            className = this.GetType().Name;
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

            methodName = MethodBase.GetCurrentMethod().Name;

            return _tracer.StopTrace(null, methodName, className);
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

            methodName = MethodBase.GetCurrentMethod().Name;

            return _tracer.StopTrace(null, methodName, className);
        }
    }

    public class Program
    {
        public static void Main()
        {
            ITracer tracer = new MethodTracer();
            DiceMechsRealization diceMechsRealization = new DiceMechsRealization(tracer);
            diceMechsRealization.HitCounter();
        }
    }
}
