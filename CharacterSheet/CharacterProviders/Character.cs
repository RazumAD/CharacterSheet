namespace CharacterSheet.CharacterProviders;

public class Character
{
    public string Name { get; set; } = string.Empty;
    public int Experience { get; set; } = 0;
    public Rank Rank { get; private set; } = Rank.Novice;
    public int SkillPoints { get; private set; } = 0;

    public Dictionary<string, Attribute> Attributes { get; private set; }
    public Dictionary<string, Skill> Skills { get; private set; }

    public bool InConsciousness { get; private set; }

    public int Bennies { get; set; } = 0;
    public int MaxBennies { get; set; } = 3;

    private int _wounds = 0;
    public int Wounds
    {
        get
        {
            return _wounds;
        }
        set
        {
            if (value > MaxWounds)
            {
                InConsciousness = false;
            }

            _wounds = value;
        }
    }
    public int MaxWounds { get; set; } = 3;

    private int _fatigue = 0;
    public int Fatigue
    {
        get
        {
            return _fatigue;
        }
        set
        {
            if (value >= MaxFatigue)
            {
                InConsciousness = false;
            }

            _fatigue = value;
        }
    }
    public int MaxFatigue { get; set; } = 3;

    public int PaceMode { get; set; } = 0;
    public int Pace => 6 + PaceMode;

    public int ParryMode { get; set; } = 0;
    public int Parry => 2 + Skills[Skill.Fighting].Half + ParryMode;

    public int Armour { get; set; } = 0;
    public int ToughnessMode { get; set; } = 0;
    public int Toughness => 2 + Attributes[Attribute.Vigor].Half + ToughnessMode + Armour;

    public int CharismaMode { get; set; } = 0;
    public int CharismaValue { get; set; } = 0;
    public int Charisma => CharismaMode + CharismaValue;

    public Character()
    {
        Attributes = new()
        {
            [Attribute.Agility] = new Attribute(),
            [Attribute.Smart] = new Attribute(),
            [Attribute.Spirit] = new Attribute(),
            [Attribute.Strength] = new Attribute(),
            [Attribute.Vigor] = new Attribute(),
        };

        Skills = new()
        {
            [Skill.Athletics] = new Skill { Father = Attributes[Attribute.Strength] },
            [Skill.Boating] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Driving] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Fighting] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Gambling] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Healing] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Intimidation] = new Skill { Father = Attributes[Attribute.Spirit] },
            [Skill.Investigation] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Lockpicking] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Notice] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Persuasion] = new Skill { Father = Attributes[Attribute.Spirit] },
            [Skill.Piloting] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Repair] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Riding] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Shooting] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Stealth] = new Skill { Father = Attributes[Attribute.Agility] },
            [Skill.Streetwise] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Survival] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Taunt] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Tracking] = new Skill { Father = Attributes[Attribute.Smart] },
            [Skill.Unlearned] = new Skill { Father = null }
        };
    }
}