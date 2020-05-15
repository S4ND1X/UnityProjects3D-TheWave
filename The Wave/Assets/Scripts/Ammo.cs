using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //Config values
    [SerializeField] AmmoMagazine[] ammoMagazines;


    [System.Serializable]
    private class AmmoMagazine
    {
        [SerializeField]private AmmoWeapon ammoWeapon; //Enum containing the types of ammo for each weapon
        [SerializeField]private int ammoAmount;//How much do we have of this weapon
        public int GetAmmount()
        {
            return this.ammoAmount;
        }
        //@return the type of ammo that this magazine is using
        public AmmoWeapon GetAmmoWeapon()
        {
            return this.ammoWeapon;
        }
        public void SetAmmoAmount(int ammoAmount)
        {
            this.ammoAmount = ammoAmount;
        }
    }

    public int GetAmmount(AmmoWeapon ammoWeapon)
    {
        return GetAmmoMagazine(ammoWeapon).GetAmmount(); //check wich magazine has this type of ammo and get the amount of it
    }

    public void SetAmmount(int ammount , AmmoWeapon ammoWeapon)
    {
       GetAmmoMagazine(ammoWeapon).SetAmmoAmount(ammount);//Check wich magazine has this type of weapon and set the amount to that magazine
    }


    private AmmoMagazine GetAmmoMagazine(AmmoWeapon ammoWeapon)
    {
        foreach(AmmoMagazine magazine in this.ammoMagazines) //Iterate trough all the magazines and check wich one has the type of ammo passed
        {
            if(magazine.GetAmmoWeapon() == ammoWeapon)
            {
                return magazine;
            }
        }
        return null;
    }



}
