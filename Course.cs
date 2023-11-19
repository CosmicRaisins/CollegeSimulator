using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course
{

    private string name;
    private int baseDC;
    private float grade;
    private string[] modifiers;
    private string[] attributes;
    
    public Course(string name, int baseDC, float grade, string[] modifiers, string[] attributes)
    {
        this.name = name;
        this.baseDC = baseDC;
        this.grade = grade;
        this.modifiers = modifiers;
        this.attributes = attributes;
    }
    
    public string getName()
    {
        return name;
    }
    
    public int getBaseDC()
    {
        return baseDC;
    }
    
    public float getGrade()
    {
        return grade;
    }
    
    public string[] getModifiers()
    {
        return modifiers;
    }
    
    public string[] getAttributes()
    {
        return attributes;
    }
    
    public void setGrade(float grade)
    {
        this.grade = grade;
    }
    
    public void setBaseDC(int baseDC)
    {
        this.baseDC = baseDC;
    }
    
    public void setModifiers(string[] modifiers)
    {
        this.modifiers = modifiers;
    }
    
    public void setAttributes(string[] attributes)
    {
        this.attributes = attributes;
    }
}
