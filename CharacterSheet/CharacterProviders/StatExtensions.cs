using CharacterSheet.DiceProviders;

namespace CharacterSheet.CharacterProviders;

public static class StatExtensions
{
    extension(Stat trait)
    {
        public int Roll => trait switch
        {
            Stat.D4 => Dice.D4.Roll,
            Stat.D6 => Dice.D6.Roll,
            Stat.D8 => Dice.D8.Roll,
            Stat.D10 => Dice.D10.Roll,
            Stat.D12 => Dice.D12.Roll,
            _ => throw new NotSupportedException(),
        };

        public int Half => trait switch
        {
            Stat.D4 => Dice.D4.Half,
            Stat.D6 => Dice.D6.Half,
            Stat.D8 => Dice.D8.Half,
            Stat.D10 => Dice.D10.Half,
            Stat.D12 => Dice.D12.Half,
            _ => throw new NotSupportedException(),
        };

        public Stat Next => trait switch
        {
            Stat.D4 => Stat.D6,
            Stat.D6 => Stat.D8,
            Stat.D8 => Stat.D10,
            Stat.D10 => Stat.D12,
            Stat.D12 => throw new ChangeTraitException(),
            _ => throw new NotSupportedException(),
        };

        public bool TryGetNext(out Stat next)
        {
            try
            {
                next = trait.Next;
                return true;
            }
            catch (ChangeTraitException)
            {
                next = trait;
                return false;
            }
        }

        public Stat Previous => trait switch
        {
            Stat.D4 => throw new ChangeTraitException(),
            Stat.D6 => Stat.D4,
            Stat.D8 => Stat.D6,
            Stat.D10 => Stat.D8,
            Stat.D12 => Stat.D10,
            _ => throw new NotSupportedException(),
        };

        public bool TryGetPrevious(out Stat previous)
        {
            try
            {
                previous = trait.Previous;
                return true;
            }
            catch (ChangeTraitException)
            {
                previous = trait;
                return false;
            }
        }
    }
}