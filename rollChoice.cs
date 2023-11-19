using System.Collections.Generic;
public class RollChoice : Choice
{
    
    public int DC { get; set; }
    public Outcome Success { get; set; }
    public Outcome Failure { get; set; }
    public List<Effect> Effects { get; set; }

    public RollChoice() : base()
    {
        this.DC = 0;
        this.Type = "";
        this.Success = null;
        this.Failure = null;
    }
    public RollChoice(string name, string type, string description, Outcome success, Outcome failure, int DC) : base(name, type, description)
    {
        this.DC = DC;
        this.Type = type;
        this.Success = success;
        this.Failure = failure;
    }
    
    override public string toString()
    {
        string result = Name + ": " + Description;
        result += "\nSuccess: " + Success.toString();
        result += "\nFailure: " + Failure.toString();
        return result;
    }
}