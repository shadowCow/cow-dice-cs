namespace CowDice.Tests;

public class DiceTests
{
    [Fact]
    public void TestFixedDiceRoller()
    {
        var value = 1;
        var roller = new FixedDiceRoller([value]);

        AThousandFixedRollsAreCorrect(roller, value, value);
    }

    [Fact]
    public void TestRandomDiceRoller()
    {
        var roller = new RandomDiceRoller([new Die(1, 6), new Die(1, 6)]);

        AThousandFixedRollsAreCorrect(roller, 1, 6);
    }

    static void AThousandFixedRollsAreCorrect(IDiceRoller roller, int expectedMin, int expectedMax)
    {
        for (int i = 0; i < 1000; i++)
        {
            var result = roller.Roll();

            Assert.True(result.All(r => r >= expectedMin), $"Expected all dice rolled to be >= {expectedMin}, but was {result.Min()}");
            Assert.True(result.All(r => r <= expectedMax), $"Expected all dice rolled to be <= {expectedMax}, but was {result.Max()}");
        }
    }
}
