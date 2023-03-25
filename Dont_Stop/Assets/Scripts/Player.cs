using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool playerAlive;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void Update()
    {
        Die();
    }
    void Die()
    {
        if (currentHealth > minHealth)
        {
            playerAlive = true;
        }
        else if (currentHealth <= minHealth)
        {
            playerAlive = false;
            Time.timeScale = 0;
        }
        
    }

}
