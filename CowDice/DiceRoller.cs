namespace CowDice;

public interface IDiceRoller
{
    IEnumerable<int> Roll(Die[] dice);
    IEnumerable<int> RollMdN(int numDice, int numPips);
}

public record Die(int Min, int Max);

public class RandomDiceRoller : IDiceRoller
{
    public IEnumerable<int> Roll(Die[] dice)
    {
        Random random = new();
        return dice.Select(d => random.Next(d.Min, d.Max + 1));
    }

    public IEnumerable<int> RollMdN(int numDice, int numPips)
    {
        Random random = new();
        return Enumerable.Range(1, numDice).Select(d => random.Next(1, numPips + 1));
    }
}

public class MaxDiceRoller : IDiceRoller
{
    public IEnumerable<int> Roll(Die[] dice)
    {
        return dice.Select(d => d.Max);
    }

    public IEnumerable<int> RollMdN(int numDice, int numPips)
    {
        return Enumerable.Range(1, numDice).Select(x => numPips);
    }
}

public class MinDiceRoller : IDiceRoller
{
    public IEnumerable<int> Roll(Die[] dice)
    {
        return dice.Select(d => d.Min);
    }

    public IEnumerable<int> RollMdN(int numDice, int numPips)
    {
        return Enumerable.Range(1, numDice).Select(x => 1);
    }
}
