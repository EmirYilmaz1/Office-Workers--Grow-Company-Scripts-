using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
   private NavMeshAgent navMeshAgent;
   private ActionScheduler actionScheduler;
   private Vector3 destinationPoint;
   private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        actionScheduler = GetComponent<ActionScheduler>();
    }

    private void Update() 
    {
        if(navMeshAgent.stoppingDistance>Vector3.Distance(transform.position,destinationPoint))
        {
            Cancel();
        }
    }

    public void Move(Vector3 position)
    {
        destinationPoint = position;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(position);
    }

    public void Cancel()
    {
        navMeshAgent.isStopped = true;
    }

}
