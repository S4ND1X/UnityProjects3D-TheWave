using System;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    //Cached references
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem weaponParticles;
    [SerializeField] private GameObject hitParticles; // Use GameObject instead of particle system to be able to instantiate and destroy
    [SerializeField] private Ammo ammountAmmoWeapon;

    //Config Values
    [SerializeField] private float shootingDistance = 80f;
    [SerializeField] private float weaponDamage = 33;
    [SerializeField] private bool avaibleShooting = true;
    [SerializeField] private float cadencyTime = 2;
    
    void Update()
    {
        PlayerInput();
    }

    private void OnEnable()
    {
        this.avaibleShooting = true;
    }


    private void PlayerInput()
    {
        if (Input.GetButtonDown("Fire1") && avaibleShooting)
        {
            
           StartCoroutine(Shoot());
        }
    }

    IEnumerator  Shoot()
    {
        if (this.ammountAmmoWeapon.GetAmmount() <= 0) { yield break; } //If run out of ammo don't shoot
        this.ammountAmmoWeapon.SetAmmount(this.ammountAmmoWeapon.GetAmmount() - 1); //Reduce ammo by 1

        this.avaibleShooting = false;
        ShootParticles();

        //Throws a ray forwards to the player and returns information about the the object it hit
        if(Physics.Raycast(this.mainCamera.transform.position, this.mainCamera.transform.forward, out RaycastHit hit, this.shootingDistance))
        {
            HitParticles(hit);
            try
            {
                EnemyLive enemyHit = hit.transform.GetComponent<EnemyLive>();//Get the script of all enemies hit
                enemyHit.HitTaken(this.weaponDamage);
            }
            catch (NullReferenceException)
            {
                Debug.Log("No EnemyLive Component");
            }
        }
        yield return new WaitForSeconds(this.cadencyTime);
        this.avaibleShooting = true;
    }

    private void HitParticles(RaycastHit hit)
    {  
        //Use LookRotation to always be lookin at the normal of the hit point, in other word always the particles goes outside
        GameObject particle =  Instantiate(this.hitParticles, hit.point,  Quaternion.LookRotation(hit.normal));
        Destroy(particle, 0.5f);
    }

    private void ShootParticles()
    {

        this.weaponParticles.Play();//Play particles inside prefab, it's better if we alwas know where is goint to happen
    }
}
