using System;
using System.Collections.Generic;
using System.IO;

public class ConfigFileInterpreter
{
    private readonly Dictionary<string, List<string>> _boxes = new Dictionary<string, List<string>>();

    public ConfigFileInterpreter(string path)
    {
        ParseConfigFile(path);
    }

    public (string box, int quantity) GetBoxAndQuantity(string item)
    {
        foreach (var (box, items) in _boxes)
        {
            int quantity = items.FindAll(x => x == item).Count;
            if (quantity > 0)
            {
                return (box, quantity);
            }
        }

        throw new InvalidDatabaseEntryException("Item not found in zicat.db!");
    }

    private void ParseConfigFile(string path)
    {
        using var reader = new StreamReader(path);

        string currentBox = null;

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine().Trim();

            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                currentBox = line.Substring(1, line.Length - 2);
                _boxes[currentBox] = new List<string>();
            }
            else if (!string.IsNullOrEmpty(line))
            {
                _boxes[currentBox].Add(line);
            }
        }
    }
}
public class InvalidDatabaseEntryException : Exception
{
    public InvalidDatabaseEntryException(string message) : base(message)
    {
        // Optionally add any additional logic you need here
    }
}
