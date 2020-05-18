using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{

    //Config values
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private TextMeshProUGUI healthText;
    private DeathHandling deathHandling;

     void Start()
    {
        UpdateUI();
        this.deathHandling = GetComponent<DeathHandling>();
    }

    public void takeDamage(float damage)
    {
        
        this.maxHealth -= damage;
        UpdateUI();
        if (this.maxHealth <= 0.0f)
        {
            this.deathHandling.onDeath();
        }
    }


    private void UpdateUI()
    {
        if(this.maxHealth <= 0)
        {
            this.healthText.SetText("0");
        }
        else
        {
            this.healthText.SetText(this.maxHealth.ToString());
        }
    }
}
