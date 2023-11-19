using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<Choice> Choices { get; private set; }

    public Event(string name, string description, List<Choice> choices)
    {
        Name = name;
        Description = description;
        Choices = choices;
    }

    public string toString()
    {
        string result = $"{Name}: {Description}";
        foreach (Choice choice in Choices)
        {
            Debug.Log(choice.ToString());
            result += $"\n{choice.ToString()}";
        }
        return result;
    }
}