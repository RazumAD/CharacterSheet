namespace CharacterSheet.CharacterProviders;

public class Attribute
{
    #region Default Attributes
    public const string Agility = "Ловкость";
    public const string Smart = "Смекалка";
    public const string Spirit = "Характер";
    public const string Strength = "Сила";
    public const string Vigor = "Телосложение";
    #endregion

    public Stat Value { get; set; } = Stat.D4;
    public int ValueBonus { get; set; } = 0;
    public Stat Wild { get; set; } = Stat.D6;
    public int WildBonus { get; set; } = 0;

    public virtual int Roll => int.Max(Value.Roll + ValueBonus, Wild.Roll + WildBonus);
    public virtual int Half => Value.Half;
}