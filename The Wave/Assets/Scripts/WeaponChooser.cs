using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChooser : MonoBehaviour
{

    // Config  values
    [SerializeField] private int currentWeapon; // Index of the current weapon
    
    void Start()
    {
        SetWeapon();
    }

    
    void Update()
    {
        int prevIndexWeapon = this.currentWeapon;
        PlayerInput();

        if(this.currentWeapon != prevIndexWeapon)
        {
            SetWeapon();
        }

    }

    private void PlayerInput()
    {
        //Keyboard
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.currentWeapon = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.currentWeapon = 1;
        }


        //Mouse Wheel
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(this.currentWeapon >= transform.childCount - 1)//If we have a value larger than the lenght of the childs count we comeback to 0
            {
                this.currentWeapon = 0;
            }

            this.currentWeapon++; 
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (this.currentWeapon <= 0)
            {
                this.currentWeapon = transform.childCount -1; // If we have a value smaller than comeback to the last weapon
            }

            this.currentWeapon--;
        }
    }


    private void SetWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            Debug.Log(weapon);
            if ( i == this.currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
            
        }
    }
}
