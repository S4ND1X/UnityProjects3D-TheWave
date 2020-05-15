using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTake : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 10;
    [SerializeField] private AmmoWeapon ammoWeapon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Ammo tmp = FindObjectOfType<Ammo>();//Finds the component Ammo on the gameObject that collide with
            tmp.SetAmmount(tmp.GetAmmount(this.ammoWeapon) + this.ammoAmount, this.ammoWeapon);//Increase the ammount of ammo of that type 
            Destroy(gameObject);
        }
    }

}
