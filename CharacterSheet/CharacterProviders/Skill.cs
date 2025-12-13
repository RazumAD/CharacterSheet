namespace CharacterSheet.CharacterProviders;

public class Skill : Attribute
{
    #region Default Skills
    public const string Athletics = "Атлетика";
    public const string Boating = "Судовождение";
    public const string Driving = "Вождение";
    public const string Fighting = "Драка";
    public const string Gambling = "Азартные игры";
    public const string Healing = "Лечение";
    public const string Intimidation = "Запугивание";
    public const string Investigation = "Расследование";
    public const string Lockpicking = "Взлом";
    public const string Notice = "Внимвние";
    public const string Persuasion = "Убеждение";
    public const string Piloting = "Пилотирование";
    public const string Repair = "Ремонт";
    public const string Riding = "Верховая езда";
    public const string Shooting = "Стрельба";
    public const string Stealth = "Маскировка";
    public const string Streetwise = "Уличное чутье";
    public const string Survival = "Выживание";
    public const string Taunt = "Провокация";
    public const string Tracking = "Выслеживание";
    public const string Unlearned = "Неизученный";
    #endregion

    public required Attribute Father { get; set; }

    private int _unlearned = 0;
    public bool Learned
    {
        get
        {
            return _unlearned < 1;
        }
        set
        {
            _unlearned = value ? 0 : 1;
        }
    }

    public override int Roll => base.Roll - (2 * _unlearned);
    public override int Half => base.Half - (2 * _unlearned);
}