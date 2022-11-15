using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPP_1.DiceRolling;
using SPP_1.Serialization;
using SPP_1.Tracing;

namespace SPP_1
{
    public class Program
    {
        public static void Main()
        {
            ITracer tracer = new MethodTracer();
            DiceRollerTracer diceMechsRealization = new DiceRollerTracer(tracer, new DiceRoller());

            Console.WriteLine("Input the amount of d20s you'd like to roll.");
            int diceRolls = Convert.ToInt32(Console.ReadLine());

            diceMechsRealization.RollDice(diceRolls);

            diceMechsRealization.SerializeResult(GetTraceSerializer());
        }

        private static ITraceSerializer GetTraceSerializer()
        {
            Console.WriteLine("Choose input method:");
            Console.WriteLine("0: XML");
            Console.WriteLine("1: JSON");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                return new TraceToJsonSerializer();
            }
            else if (userChoice == "0")
            {
                return new TraceToXmlSerializer();
            }
            else
            {
                throw new ArgumentException("Input data does not match the requirements.");
            }
        }
    }
}
