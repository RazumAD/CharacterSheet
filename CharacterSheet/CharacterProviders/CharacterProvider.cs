namespace CharacterSheet.CharacterProviders;

public static class CharacterProvider
{
    public static bool TryAddAttribute(Character character, string name) =>
        character.Attributes.TryAdd(name, new Attribute());

    public static bool TryAddSkill(Character character, string name, string fatherName) =>
        character.Skills.TryAdd(name, new Skill { Father = character.Attributes[fatherName] });
}