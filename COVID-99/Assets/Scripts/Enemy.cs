using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject hitEffect;
    public GameObject bloodDrop;

    public float attackRange = 0.5f;
    public LayerMask playerLayers;


    private AudioSource audioSource;
    public AudioClip EnemyDamageDeathSound;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        audioSource.clip = EnemyDamageDeathSound;
        audioSource.Play();
        health -= damage;

        GameObject Effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 0.6f);
        if (health <= 0)
        {
            Die();
        }


        void Die()
        {
            audioSource.clip = EnemyDamageDeathSound;
            audioSource.Play();
            Instantiate(bloodDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

