// See https://aka.ms/new-console-template for more information
using CharacterSheet.CharacterProviders;
using CharacterSheet.DiceProviders;

Console.WriteLine("Hello, World!");

var t = new Character { Name = "" }.Toughness;

Console.WriteLine(t);