namespace CowDice;

public interface IDiceRoller
{
    IEnumerable<int> Roll();
}

public record Die(int Min, int Max);

public class RandomDiceRoller(Die[] dice) : IDiceRoller
{
    public IEnumerable<int> Roll()
    {
        Random random = new();
        return dice.Select(d => random.Next(d.Min, d.Max + 1));
    }
}

public class FixedDiceRoller(int[] vs) : IDiceRoller
{
    public IEnumerable<int> Roll()
    {
        return vs;
    }
}
