using CharacterSheet.DiceProviders;

namespace CharacterSheet;

public class Attribute
{
    public required string Name { get; set; }
    public List<Dice> Value { get; set; } = [Dice.None];
    public int ValueBonus { get; set; } = 0;
    public Dice Wild { get; set; } = Dice.None;
    public int WildBonus { get; set; } = 0;

    public int Roll => int.Max(Value.Max(dice => dice.Roll) + ValueBonus,
                                 Wild.Roll + WildBonus);

    public Dice Range => Value.Max();
}