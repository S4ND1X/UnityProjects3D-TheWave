using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Cached References
    [SerializeField] private Transform gameObjectToFollow;
    private NavMeshAgent navMeshAgent;


    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>(); //Gets te component of this type attached to the GameObject
    }

    void Update()
    {
        this.navMeshAgent.SetDestination(gameObjectToFollow.position);/*Calculates a new path based on target's
                                                                        * positon (Vector 3)
                                                                       */
    }
}