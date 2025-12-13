namespace CharacterSheet.DiceProviders;

public static class DiceExtensions
{
    private static readonly Random _roller = new();

    extension(Dice dice)
    {
        private int ExplosiveRoll()
        {
            var result = _roller.Next(1, dice.Sides + 1);

            if (result == dice.Sides)
            {
                result += dice.Roll;
            }

            return result;
        }

        public int Roll => dice.ExplosiveRoll();

        public int Sides => (int)dice;

        public int Half => dice.Sides / 2;
    }
}