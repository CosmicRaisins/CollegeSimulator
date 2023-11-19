using System.Collections.Generic;
using UnityEngine;

public abstract class Choice
{
    
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    // Constructor with parameters
    protected Choice(string name, string type, string description)
    {
        Name = name;
        Type = type;
        Description = description;
    }
    
    // Default constructor
    protected Choice()
    {
        // Initialize properties with default values
        Name = "";
        Type = "";
        Description = "";
    }

    public abstract string toString();
}