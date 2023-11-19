using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    private string type;
    private string content;

    public Effect(string type, string content)
    {
        this.type = type;
        this.content = content;
    }

    // get the type of the effect
    public string getType()
    {
        return type;
    }

    // get the content of the effect
    public string getContent()
    {
        return content;
    }

    // set the type of the effect
    public void setType(string type)
    {
        this.type = type;
    }

    // set the content of the effect
    public void setContent(string content)
    {
        this.content = content;
    }

    // apply the effect to the player
    public void apply()
    {
        // todo:
    }
    
    // return a string representation of the effect
    public string toString()
    {
        return type + ": " + content;
    }
}
