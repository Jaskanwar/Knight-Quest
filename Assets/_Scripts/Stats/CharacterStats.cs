
using UnityEngine;

public class ChararacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armour;

    public int maxHealth = 100;

    public int currentHealth { get; private set; } // this property is publicly accessible however the set function can only be done from within the class

    void Awake()
    {
        currentHealth = maxHealth; // starting health for player.
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // this insures that the damage value is not negative given an armour value greater than it

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + "  damage.");

        if(currentHealth<=0)
        {
            Die();
        }
     
    }

    // overridabel method for different characters who will die in different ways.
    public virtual void Die()
    {
        // Die in some unique way

        Debug.Log(transform.name + " died.");
    }
}
