using System.Xml;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public TextAsset eventsXml; // Assign the XML file in the Unity Editor
    public List<Event> events;

    void Start()
    {
        LoadEventsFromXml();

        Event randomEvent = GetRandomEvent();
        Debug.Log("Random Event: " + randomEvent.Name + "\n" + randomEvent.toString());
    }

    public Effect loadEffectFromXmlNode(XmlNode effectNode)
    {
        Effect newEffect = new Effect(effectNode.InnerText, effectNode.SelectSingleNode("Content").InnerText);
        
        return newEffect;
    }
    
    public Outcome loadOutcomeFromXmlNode(XmlNode outcomeNode)
    {
        
        List<Effect> effects = new List<Effect>();
        XmlNodeList effectNodes = outcomeNode.SelectNodes("/Effects/*");
        foreach (XmlNode effectNode in effectNodes)
        {
            Effect newEffect = loadEffectFromXmlNode(effectNode);
            effects.Add(newEffect);
        }
        
        return new Outcome(outcomeNode.InnerText, effects);
    }
    
    
    Choice loadChoiceFromXmlNode(XmlNode choiceNode)
    {
        Choice newChoice = null;
        
        if (choiceNode.Name == "rollChoice")
        {
            RollChoice rollChoice = new RollChoice();
            rollChoice.Name = choiceNode.InnerText;
            rollChoice.Description = choiceNode.SelectSingleNode("Des").InnerText;
            rollChoice.DC = int.Parse(choiceNode.SelectSingleNode("DC").InnerText);
            rollChoice.Type = choiceNode.SelectSingleNode("Type").InnerText;
            rollChoice.Success = loadOutcomeFromXmlNode(choiceNode.SelectSingleNode("Success"));
            rollChoice.Failure = loadOutcomeFromXmlNode(choiceNode.SelectSingleNode("Failure"));

            newChoice = rollChoice;
        }
        else if (choiceNode.Name == "Choice")
        {
            NormalChoice normalChoice = new NormalChoice();
            normalChoice.Description = choiceNode.SelectSingleNode("Des").InnerText;
            normalChoice.Effects = new List<Effect>();
            XmlNodeList effectNodes = choiceNode.SelectNodes("/Choices/*");
            foreach (XmlNode effectNode in effectNodes)
            {
                Effect newEffect = loadEffectFromXmlNode(effectNode);
                normalChoice.Effects.Add(newEffect);
            }

            newChoice = normalChoice;
        }
        
        return newChoice;
    }
    void LoadEventsFromXml()
    {
        events = new List<Event>();

        if (eventsXml != null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(eventsXml.text);

            XmlNodeList eventNodes = xmlDoc.SelectNodes("/Events/Event");

            foreach (XmlNode eventNode in eventNodes)
            {
                string eventName = eventNode.SelectSingleNode("Name").InnerText;
                string eventDescription = eventNode.SelectSingleNode("Des").InnerText;
                // add all possible choices with the choice parser helper
                XmlNodeList choiceNodes = eventNode.SelectNodes("Choices/*");
                List<Choice> choices = new List<Choice>();
                foreach (XmlNode choiceNode in choiceNodes)
                {
                    Choice newChoice = loadChoiceFromXmlNode(choiceNode);
                    choices.Add(newChoice);
                }

                Event newEvent = new Event(eventName, eventDescription, choices);
                events.Add(newEvent);
            }
        }
        else
        {
            Debug.LogWarning("XML file not assigned.");
        }
    }

    public Event GetRandomEvent()
    {
        // Get a random event from the list
        if (events != null && events.Count > 0)
        {
            int randomIndex = Random.Range(0, events.Count);
            return events[randomIndex];
        }
        else
        {
            Debug.LogWarning("No events loaded.");
            return null;
        }
    }
}