using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


// All the sounds were taken from freesound.org
    
namespace SPP_1
{
    public class MethodTrace
    {

        private const int MAX_DICE_VALUE = 20;
        private const int MIN_DICE_VALUE = 1;
        private readonly ITracer _tracer;
        private readonly CriticalRegister _criticalRegister;

        internal MethodTrace(ITracer tracer)
        {
            _tracer = tracer;
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
                currentRoll = random.Next(MIN_DICE_VALUE, MAX_DICE_VALUE);

                if (currentRoll == MAX_DICE_VALUE)
                {
                    _criticalRegister.CriticalSuccess();
                }
                else if (currentRoll == MIN_DICE_VALUE)
                {
                    _criticalRegister.CriticalFailure();
                }
            }


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
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer("success.wav");
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }
            Console.WriteLine("Boom! You hit a twenty! What a lucky shot!");
            
        }

        public void CriticalFailure()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer("failure.wav");
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }
            Console.WriteLine("Aww, you got one... Such a disappointment!");
        }
    }

    public static class Main
    {
        MethodTrace methodTrace = new MethodTrace();
        MethodTrace.HitCounter();
    }
}
