using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Cached references
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem weaponParticles;

    //Config Values
    [SerializeField] private float shootingDistance = 80f;
    [SerializeField] private float weaponDamage = 33;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerInput();
    }


    private void PlayerInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {


        InstantiateParticles();

        try
        {
            //Throws a ray forwards to the player and returns information about the the object it hit
            Physics.Raycast(this.mainCamera.transform.position, this.mainCamera.transform.forward, out RaycastHit hit, this.shootingDistance);
            EnemyLive enemyHit = hit.transform.GetComponent<EnemyLive>();//Get the script of all enemies hit
            enemyHit.HitTaken(this.weaponDamage);
        }
        catch (NullReferenceException)
        {
            Debug.Log("No object hit");
        }
       
        

        //TODO: Particles

    }

    private void InstantiateParticles()
    {
        Debug.Log("particulas");
        this.weaponParticles.Play();
    }
}
