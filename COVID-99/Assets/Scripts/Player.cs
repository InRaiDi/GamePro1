using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 100;
    public GameObject hitEffect;

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

            SceneManager.LoadScene("GameOver");
        }
    }
}
