using System.Collections.Generic;

public class Outcome
{
    private string description;
    private List<Effect> effects;
    
    public Outcome(string description, List<Effect> effects)
    {
        this.description = description;
        this.effects = effects;
    }
    
    public string toString()
    {
        string result = description;
        foreach(Effect effect in effects)
        {
            result += "\n" + effect.toString();
        }
        return result;
    }
}