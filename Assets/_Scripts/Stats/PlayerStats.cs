using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged; // adding method to delegate
    }


    // this is the method to change the modifiers 
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {

        // add the new items modifiers to the list
        if(newItem!= null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);

        }
  
        // remove the old items modifiers from the list
        if(oldItem!= null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override  void Die()
    {
        base.Die();

        // Kill the player

        PlayerManager.instance.KillPlayer();
    }
}

