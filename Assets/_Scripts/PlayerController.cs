using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    public PlayerMotor motor;
    public Interactable focus;
  
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                // Move our player to what we hit
                // Stop focusing any objects
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }

           
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable, if we did do something.
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable!= null)
                {
                    SetFocus(interactable);
                }

            }
        }

    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus!= focus)
        {
            if(focus != null)
                focus.OnDefocused();
            

            focus = newFocus;
            motor.FollowTarget(newFocus);
           
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        
        
        focus = null;
        motor.StopFollowingTarget();

    }
}
