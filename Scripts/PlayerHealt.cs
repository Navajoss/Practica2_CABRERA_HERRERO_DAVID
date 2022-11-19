using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    public PlayerStatusUI playerStatusUI;

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    public float healthRange { get { return (float)currentHealth / (float)maxHealth; } }
    public float damageCooldown = 0f;

    public bool Take = false;
    //we put the health 
    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        damageCooldown -= Time.deltaTime;

        if (damageCooldown <= 0f)
        {
            if (Take == true)
            {
                TakeDamage(10);
                Take = false;
                damageCooldown = 1f;
            }
        }
        
    }
    //we do the damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        playerStatusUI.SetHealth(healthRange);
    }
}
