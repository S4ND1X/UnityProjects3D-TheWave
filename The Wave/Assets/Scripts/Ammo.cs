using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] private int ammount = 50;


    public int GetAmmount()
    {
        return this.ammount;
    }

    public void SetAmmount(int ammount)
    {
        this.ammount = ammount;
        Debug.Log("Ammo -> " + this.ammount);
    }




}
