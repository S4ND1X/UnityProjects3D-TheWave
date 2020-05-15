using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandling : MonoBehaviour
{

    [SerializeField] private Canvas deathScreen;

    private void Start()
    {
        this.deathScreen.enabled = false;
    }


    public void onDeath()
    {
        //Unlock cursor, destroy the camera because of bug.
        this.deathScreen.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true;
        Destroy(Camera.main);
    }

}
