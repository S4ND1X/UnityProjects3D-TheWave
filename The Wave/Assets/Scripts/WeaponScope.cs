using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScope : MonoBehaviour
{
    //Cached References
    [SerializeField] Camera mainCamera;

    //Config Values
    [SerializeField] float scopeOut = 60;
    [SerializeField] float scopeIn = 30;
    private bool isScope = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.isScope = !this.isScope;
            if (isScope)
            {
                this.mainCamera.fieldOfView = this.scopeIn;
            }
            else
            {
                this.mainCamera.fieldOfView = this.scopeOut;
            }
        }
    }

    private void OnDisable()
    {
        this.mainCamera.fieldOfView = this.scopeOut;
    }





}
