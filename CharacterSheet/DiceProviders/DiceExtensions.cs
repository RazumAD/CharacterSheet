using System.Numerics;
using CharacterSheet.DiceProviders.Exceptions;

namespace CharacterSheet.DiceProviders;

public static class DiceExtensions
{
    private static readonly Random _roller = new();

    extension(Dice dice)
    {
        public int Roll => dice switch
        {
            Dice.None => _roller.Next(1, 5) - 2,
            Dice.D4 => _roller.Next(1, 5),
            Dice.D6 => _roller.Next(1, 7),
            Dice.D8 => _roller.Next(1, 9),
            Dice.D10 => _roller.Next(1, 11),
            Dice.D12 => _roller.Next(1, 13),
            Dice.D20 => _roller.Next(1, 21),
            Dice.D100 => _roller.Next(1, 101),
            _ => throw new NullDiceException(),
        };

        public Dice Next => dice switch
        {
            Dice.None => Dice.D4,
            Dice.D4 => Dice.D6,
            Dice.D6 => Dice.D8,
            Dice.D8 => Dice.D10,
            Dice.D10 => Dice.D12,
            Dice.D12 or Dice.D20 or Dice.D100 => throw new WrongDiceException(),
            _ => throw new NullDiceException(),
        };

        public bool TryGetNext(out Dice next)
        {
            try
            {
                next = dice.Next;
                return true;
            }
            catch (WrongDiceException)
            {
                next = dice;
                return false;
            }
        }

        public Dice Previous => dice switch
        {
            Dice.D4 => Dice.None,
            Dice.D6 => Dice.D4,
            Dice.D8 => Dice.D6,
            Dice.D10 => Dice.D8,
            Dice.D12 => Dice.D10,
            Dice.None or Dice.D20 or Dice.D100 => throw new WrongDiceException(),
            _ => throw new NullDiceException(),
        };

        public bool TryGetPrevious(out Dice previous)
        {
            try
            {
                previous = dice.Previous;
                return true;
            }
            catch (WrongDiceException)
            {
                previous = dice;
                return false;
            }
        }

        public int Half => dice switch
        {
            Dice.None or Dice.D4 or Dice.D6 or Dice.D8 or Dice.D10 or Dice.D12 =>
                BitOperations.TrailingZeroCount((int)dice + 1) + 1,
            Dice.D20 or Dice.D100 => throw new WrongDiceException(),
            _ => throw new NullDiceException(),
        };
    }
}