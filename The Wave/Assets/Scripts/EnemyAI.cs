using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Cached References
    [SerializeField] private Transform playerToFollow;
    private NavMeshAgent navMeshAgent;

    //Config Enemy Values
    [SerializeField] private float followRadius = 4f;
    [SerializeField] private float distanceFromPlayer = Mathf.Infinity; /* We cannot leave by default because it starts at 0
                                                                        * and the enemy will start to follow right away
                                                                        */                      

    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>(); //Gets te component of this type attached to the GameObject
    }
     
    void Update()
    {
        this.distanceFromPlayer = Vector3.Distance(this.playerToFollow.position, this.transform.position);//Distance from a to b
        followPlayer();

    }

    public void followPlayer()
    {
        if (this.distanceFromPlayer <= this.followRadius)
        {
            this.navMeshAgent.SetDestination(playerToFollow.position);//Calculates a new path based on target's positon (Vector 3)
        }
    }


    //Draw a sphere in the chasing radius (Only for debugging)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0,200,0, 0.4f); 
        Gizmos.DrawSphere(this.transform.position, this.followRadius);
    }
}