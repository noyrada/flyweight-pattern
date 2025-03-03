using System;
using System.Collections.Generic;

class Character
{
    public char Symbol { get; }
    public string Font { get; }

    public Character(char symbol, string font)
    {
        Symbol = symbol;
        Font = font;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Character: {Symbol}, Font: {Font}, Position: ({x}, {y})");
    }
}


class CharacterFactory
{
    private readonly Dictionary<string, Character> _characters = new();

    public Character GetCharacter(char symbol, string font)
    {
        string key = $"{symbol}-{font}";

        if (!_characters.ContainsKey(key))
        {
            _characters[key] = new Character(symbol, font);
            Console.WriteLine($"Created new Character: {key}");
        }

        return _characters[key];
    }
}


class TextEditor
{
    private readonly List<(Character character, int x, int y)> _document = new();

    private readonly CharacterFactory _factory = new();

    public void AddCharacter(char symbol, string font, int x, int y)
    {
        Character character = _factory.GetCharacter(symbol, font);
        _document.Add((character, x, y));
    }

    public void DisplayDocument()
    {
        foreach (var (character, x, y) in _document)
        {
            character.Display(x, y);
        }
    }
}


class Program
{
    static void Main()
    {
        TextEditor editor = new();

        editor.AddCharacter('A', "Arial", 10, 20);
        editor.AddCharacter('B', "Arial", 15, 20);
        editor.AddCharacter('A', "Arial", 20, 20); 
        editor.AddCharacter('C', "Times New Roman", 25, 30);
        editor.AddCharacter('A', "Arial", 30, 20); 

        editor.DisplayDocument();
    }
}
