using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stats 
{
    [SerializeField]
    private int bValue;

    private List<int> modifiers = new List<int>();
    public int GetValue()
    {
        int modvalue = bValue;
        foreach(int value in modifiers)
        {
            modvalue += value;
        }
        return modvalue;
    }

    public void AddMod (int modifier)
    {
        if(modifier!=0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveMod(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
