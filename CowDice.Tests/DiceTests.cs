namespace CowDice.Tests;

using System.Linq;

public class DiceTests
{
    [Fact]
    public void TestMaxDiceRoller()
    {
        var roller = new MaxDiceRoller();
        var dice = new Die[]
        {
            new(1, 4),
            new(1, 8),
            new(1, 12),
        };

        AThousandMaxRollsAreCorrect(roller, dice);
    }

    [Fact]
    public void TestMaxDiceRollerMdN()
    {
        var roller = new MaxDiceRoller();

        AThousandMdNRollsAreCorrect(roller, 1, 6, 6, 6);
    }

    [Fact]
    public void TestMinDiceRoller()
    {
        var roller = new MinDiceRoller();
        var dice = new Die[]
        {
            new(1, 4),
            new(2, 8),
            new(3, 12),
        };

        AThousandMinRollsAreCorrect(roller, dice);
    }

    [Fact]
    public void TestMinDiceRollerMdN()
    {
        var roller = new MinDiceRoller();
        AThousandMdNRollsAreCorrect(roller, 1, 6, 1, 1);
    }

    [Fact]
    public void TestRandomDiceRoller()
    {
        var roller = new MaxDiceRoller();
        var dice = new Die[]
        {
            new(1, 4),
            new(1, 8),
            new(1, 12),
        };

        AThousandRollsAreCorrect(roller, dice);
    }

    [Fact]
    public void TestRandomDiceRollerMdN()
    {
        var roller = new RandomDiceRoller();

        AThousandMdNRollsAreCorrect(roller, 1, 6, 1, 6);
    }

    static void AThousandRollsAreCorrect(IDiceRoller roller, Die[] dice)
    {
        for (int i = 0; i < 1000; i++)
        {
            var result = roller.Roll(dice);

            foreach (var (First, Second) in result.Zip(dice))
            {
                Assert.True(First >= Second.Min, $"Expected dice roll to be >= min dice value {Second.Min} but was {First}");
                Assert.True(First <= Second.Max, $"Expected dice roll to be <= max dice value {Second.Max} but was {First}");
            }
        }
    }

    static void AThousandMaxRollsAreCorrect(IDiceRoller roller, Die[] dice)
    {
        for (int i = 0; i < 1000; i++)
        {
            var result = roller.Roll(dice);

            foreach (var (First, Second) in result.Zip(dice))
            {
                Assert.Equal(First, Second.Max);
            }
        }
    }

    static void AThousandMinRollsAreCorrect(IDiceRoller roller, Die[] dice)
    {
        for (int i = 0; i < 1000; i++)
        {
            var result = roller.Roll(dice);

            foreach (var (First, Second) in result.Zip(dice))
            {
                Assert.Equal(First, Second.Min);
            }
        }
    }

    static void AThousandMdNRollsAreCorrect(IDiceRoller roller, int m, int n, int expectedMin, int expectedMax)
    {
        for (int i = 0; i < 1000; i++)
        {
            var result = roller.RollMdN(m, n);

            Assert.True(result.All(r => r >= expectedMin), $"Expected all dice rolled to be >= {expectedMin}, but was {result.Min()}");
            Assert.True(result.All(r => r <= expectedMax), $"Expected all dice rolled to be <= {expectedMax}, but was {result.Max()}");
        }
    }
}
