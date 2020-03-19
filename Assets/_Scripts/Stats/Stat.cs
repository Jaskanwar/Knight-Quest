using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]// this allows the fields in this class to show up in the inspector
public class Stat 
{

    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>(); // holds the modifiers
    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }


    // adds the modifier to the list when a new item is equiped
    public void AddModifier(int modifier)
    {
        if(modifier != 0 )
        {
            modifiers.Add(modifier);
        }
    }

    // removes the modifier from the list when an item is unquipped
    public void RemoveModifier(int modifier)
    {
        if(modifier!=0)
        {
            modifiers.Remove(modifier);
        }
    }
}
