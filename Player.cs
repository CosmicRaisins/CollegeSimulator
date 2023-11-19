using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string playerName;
    private float currentGPA;
    private int sanity;
    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    private Course[] classes;
    
    public Player(string name, float gpa, int sanity, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, Course[] classes)
    {
        playerName = name;
        currentGPA = gpa;
        this.sanity = sanity;
        this.strength = strength;
        this.dexterity = dexterity;
        this.constitution = constitution;
        this.intelligence = intelligence;
        this.wisdom = wisdom;
        this.charisma = charisma;
        this.classes = classes;
    }
    
    public string getName()
    {
        return playerName;
    }
    
    public float getGPA()
    {
        return currentGPA;
    }
    
    public float getSanity()
    {
        return sanity;
    }
    
    public int[] getAttributes()
    {
        return new int[] {strength, dexterity, constitution, intelligence, wisdom, charisma};
    }
    
    public Course[] getClasses()
    {
        return classes;
    }
    
    public void setGPA(float gpa)
    {
        currentGPA = gpa;
    }
    
    public void setSanity(int sanity)
    {
        this.sanity = sanity;
    }
    
    public void setAttributes(int[] attributes)
    {
        strength = attributes[0];
        dexterity = attributes[1];
        constitution = attributes[2];
        intelligence = attributes[3];
        wisdom = attributes[4];
        charisma = attributes[5];
    }
}
