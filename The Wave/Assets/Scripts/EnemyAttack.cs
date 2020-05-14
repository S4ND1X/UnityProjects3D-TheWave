using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //Cached References
    PlayerLive player;
    //Config values
    [SerializeField] private float damage = 15f;

    void Start()
    {
        this.player = FindObjectOfType<PlayerLive>(); 
    }

    //This a function that it's been called in the event animation
    public void AttackEvent()
    {
        try{
            this.player.takeDamage(this.damage);
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("No player found");
        }
    }
}
