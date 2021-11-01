using System;

public class Dice
{
    readonly Random _rng;

    public int LastRoll { get; private set; }

    private Dice()
    {
        _rng = new Random();
    }

    public static Dice Create()
    {
        return new Dice();
    }

    public int RollDice()
    {
        var result = _rng.Next(1, 7);
        LastRoll = result;
        return result;
    }
}
