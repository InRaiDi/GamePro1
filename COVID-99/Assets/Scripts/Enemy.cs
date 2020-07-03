using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject hitEffect;
    public GameObject bloodDrop;
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        GameObject Effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 0.6f);
        if (health <= 0)
        {           
            Die();
        }

        
        void Die()
        {
            Instantiate(bloodDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
