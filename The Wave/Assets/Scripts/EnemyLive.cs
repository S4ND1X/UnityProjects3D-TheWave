using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLive : MonoBehaviour
{


    //Config Values
    [SerializeField] private float maxHealt = 100f;


    public void HitTaken(float damage)
    {
        this.gameObject.GetComponent<EnemyAI>().onShootTaken();
        //BroadcastMessage("onShootTaken");
        this.maxHealt -= damage;
        if(this.maxHealt <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
