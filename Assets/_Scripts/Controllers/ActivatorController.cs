using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : Interactable
{
    public GameObject enemy;
    public bool hasInteract = false;

    public override void Interact()
    {
        base.Interact();

        Vector3 pos = this.transform.position; // get the position of the activator
        pos.z += 3.0f;
        

        // checks if we have not already interacted yet so we dont keep spawning items.
        if(!hasInteract)
        {
            // get the position
            


            // spawns ten enemies
            for (int i = 0; i < 10; i++)
            {
                if(i%2==0) // checks if we are at an even number so we move position to the right
                {
                    pos.x += (1.0f + i);
                }
                else
                {
                    pos.x -= (1.0f+i); // change position to the left
                }
               

                Instantiate(enemy, pos, Quaternion.identity); // spawn
            }
            hasInteract = true;
        }

    }


  
}
