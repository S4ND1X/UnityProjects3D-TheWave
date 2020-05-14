using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Cached references
    [SerializeField] private Camera mainCamera;

    //Config Values
    [SerializeField] float shootingDistance = 80f;
    
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
        Physics.Raycast(this.mainCamera.transform.position, this.mainCamera.transform.forward, out RaycastHit hit, this.shootingDistance);
        Debug.Log("Colision con: " +  hit.transform.name);
    }
}
