namespace CharacterSheet.CharacterProviders;

[Flags]
public enum Rank
{
    Novice = 0,
    Seasoned = 1 << 0,
    Veteran = 1 << 1,
    Heroic = 1 << 2,
    Legendary = 1 << 3,
}