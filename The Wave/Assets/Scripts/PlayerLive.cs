using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{

    //Config values
    [SerializeField] private float maxHealth = 100f;
    private DeathHandling deathHandling;

     void Start()
    {
        this.deathHandling = GetComponent<DeathHandling>();
    }

    public void takeDamage(float damage)
    {
        
        this.maxHealth -= damage;

        if (this.maxHealth <= 0.0f)
        {
            this.deathHandling.onDeath();
        }
    }

}
