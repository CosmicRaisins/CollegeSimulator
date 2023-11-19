using System.Collections.Generic;
public class NormalChoice : Choice
{
    
    public List<Effect> Effects { get; set; }
    
    public NormalChoice(string name, string type, string description, List<Effect> effects) : base(name, type, description)
    {
        this.Effects = effects;
    }

    public NormalChoice() : base()
    {
        this.Effects = new List<Effect>();
    }
    
    override public string toString()
    {
        string result = Name + ": " + Description;
        foreach(Effect effect in Effects)
        {
            result += "\n" + effect.toString();
        }
        return result;
    }
}