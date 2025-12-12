namespace CharacterSheet.DiceProviders.Exceptions;

public class NullDiceException : Exception
{
    private const string DefaultMessage = "Несуществующий тип куба";

    public NullDiceException() : base(DefaultMessage) { }

    public NullDiceException(string message) : base(message) { }

    public NullDiceException(string message, Exception innerException) : base(message, innerException) { }
}