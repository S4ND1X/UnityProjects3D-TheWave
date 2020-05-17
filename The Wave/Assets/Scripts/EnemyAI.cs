using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Cached References
    [SerializeField] private Transform playerToFollow;
    private NavMeshAgent navMeshAgent;
    private Animator enemyAnimator;
    private EnemyLive enemyLive;

    //Config Enemy Values
    [SerializeField] private float followRadius = 4f;
    [SerializeField] private float distanceFromPlayer = Mathf.Infinity; /* We cannot leave by default because it starts at 0
                                                                        * and the enemy will start to follow right away
                                                                        */
    private bool isProvoked = false;

    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>(); //Gets te component of this type attached to the GameObject
        this.enemyAnimator = GetComponent<Animator>();
        this.enemyLive = GetComponent<EnemyLive>();

        this.enemyAnimator.SetBool("Idle", true);//Set de animation idle to true
    }
     
    void Update()
    {
        EnemyStatus();
    }

    public void EnemyStatus()
    {
        if (this.enemyLive.IsDead()) {
            this.navMeshAgent.enabled = false;
            this.isProvoked = false;
        }

        this.distanceFromPlayer = Vector3.Distance(this.playerToFollow.position, this.transform.position); //Distance from a to b
        //If the player was shooted the enemy won't stop following
        if (this.isProvoked)
        {
            Chasing(); // follow
        }
        else if (this.distanceFromPlayer <= this.followRadius)
        {
            this.isProvoked = true;
        }
    }


    private void Chasing()
    {
        //If chasing then attacking is false
        this.enemyAnimator.SetBool("Chasing", true);
        this.enemyAnimator.SetBool("Attacking", false);
        if (distanceFromPlayer <= this.navMeshAgent.stoppingDistance)
        {
            Attack();
        }
        this.navMeshAgent.SetDestination(playerToFollow.position);//Calculates a new path based on target's positon (Vector 3)
    }

    private void Attack()
    {
        this.enemyAnimator.SetBool("Attacking", true);
    }


    public void onShootTaken()
    {
        this.isProvoked = true;
    }

    //Draw a sphere in the chasing radius (Only for debugging)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0,200,0, 0.4f); 
        Gizmos.DrawSphere(this.transform.position, this.followRadius);
    }
}