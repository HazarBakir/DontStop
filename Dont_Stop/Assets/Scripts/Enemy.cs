using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isEnemyAlive;
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
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}
        Die();
    }
    void Die()
    {

        if (currentHealth > minHealth)
        {
            isEnemyAlive = true;
        }
        else if (currentHealth <= minHealth)
        {
            isEnemyAlive = false;
            Destroy(gameObject);
            
        }

    }

}
