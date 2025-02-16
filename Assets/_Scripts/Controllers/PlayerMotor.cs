﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public Transform target;
 

    NavMeshAgent agent;
    // Start is called before the first frame update


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
        


    }



    void Update()
    {
        if(target!= null)
        {
            
            agent.SetDestination(target.position);
            FaceTarget();
        }


    }

    
    public void MoveToPoint(Vector3 point)
    {
        if(EquipmentManager.instance.EquipShield)
        {
            this.transform.position = point;
        }
        
        
            agent.SetDestination(point);
        
        
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        target = null;
        agent.stoppingDistance = 0.0f;
        agent.updateRotation = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
