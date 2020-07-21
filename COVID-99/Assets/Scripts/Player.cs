using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float attackRange = 1.0f;
    public int playerHealth = 100;
    public int attackForce = 10;

    public GameObject hitEffect;
    public GameObject dieEffect;
    public LayerMask enemiesLayers;
    public Transform attackPoint;
    public GameObject deathAnimation;
    private AudioSource audioSource;
    public AudioClip DamageTakensSound;
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Collider2D[] enemiesHittig = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayers);
            foreach (Collider2D enemy in enemiesHittig)
            {
                TakeDamage(attackForce);
            }
        }

    }
    void TakeDamage(int damage)
    {
        audioSource.clip = DamageTakensSound;
        audioSource.Play();

        GameObject Effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 0.5f);
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            GameObject EffectDeath = Instantiate(dieEffect, transform.position, Quaternion.identity);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, 3f);
        SceneManager.LoadScene("GameOver");

    }
}
