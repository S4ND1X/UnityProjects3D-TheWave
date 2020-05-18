using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLive : MonoBehaviour
{


    //Config Values
    [SerializeField] private float maxHealt = 100f;
    private bool isDead = false;

    public void HitTaken(float damage)
    {
        
        this.gameObject.GetComponent<EnemyAI>().onShootTaken();
        //BroadcastMessage("onShootTaken");
        this.maxHealt -= damage;
        if(this.maxHealt <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (this.isDead) { return; }
        this.isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        Destroy(gameObject, 3f);
    }

    public bool IsDead()
    {
        return this.isDead;
    }

}
