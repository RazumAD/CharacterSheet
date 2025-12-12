namespace CharacterSheet;

public class Skill : Attribute
{
    public required Attribute Father { get; set; }
}