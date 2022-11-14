using NUnit.Framework;
using SPP_1.DiceRolling;
using SPP_1.Tests.Utils;

namespace SPP_1.Tests
{
    [TestFixture]
    public class DiceRollerTracerTests
    {
        [Test]
        public void RollDice_OnCriticalSuccess_TracesTheMethod()
        {
            // Arrange
            const int expectedNumberOfRolls = 5;
            IDiceRoller diceRoller = new DiceRollerStab(DiceRollerTracer.MaxDiceValue);
            DiceRollerTracer tracer = new DiceRollerTracer(new MethodTracer(), diceRoller);

            // Act
            tracer.RollDice(expectedNumberOfRolls);

            // Assert
            Assert.AreEqual(expectedNumberOfRolls, tracer.TraceResult.InnerMethods.Count);
        }

        [Test]
        public void RollDice_OnCriticalFailure_TracesTheMethod()
        {
            // Arrange
            const int expectedNumberOfRolls = 5;
            IDiceRoller diceRoller = new DiceRollerStab(DiceRollerTracer.MinDiceValue);
            DiceRollerTracer tracer = new DiceRollerTracer(new MethodTracer(), diceRoller);

            // Act
            tracer.RollDice(expectedNumberOfRolls);

            // Assert
            Assert.AreEqual(expectedNumberOfRolls, tracer.TraceResult.InnerMethods.Count);
        }

        [Test]
        public void RollDice_OnNormalRoll_DoesNotTraceTheMethod()
        {
            // Arrange
            const int numberOfRolls = 5, expectedNumberOfTraces = 0;
            IDiceRoller diceRoller = new DiceRollerStab(5);
            DiceRollerTracer tracer = new DiceRollerTracer(new MethodTracer(), diceRoller);

            // Act
            tracer.RollDice(numberOfRolls);

            // Assert
            Assert.AreEqual(expectedNumberOfTraces, tracer.TraceResult.InnerMethods.Count);
        }
    }
}