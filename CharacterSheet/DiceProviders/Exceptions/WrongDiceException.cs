namespace CharacterSheet.DiceProviders.Exceptions;

public class WrongDiceException : Exception
{
    private const string DefaultMessage = "Неверный тип куба";

    public WrongDiceException() : base(DefaultMessage) { }

    public WrongDiceException(string message) : base(message) { }

    public WrongDiceException(string message, Exception innerException) : base(message, innerException) { }
}