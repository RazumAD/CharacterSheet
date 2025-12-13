namespace CharacterSheet.CharacterProviders;

[Flags]
public enum Stat
{
    D4 = 1 << 0,
    D6 = 1 << 1 | D4,
    D8 = 1 << 2 | D6,
    D10 = 1 << 3 | D8,
    D12 = 1 << 4 | D10,
}