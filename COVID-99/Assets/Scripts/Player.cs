using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float attackRange = 1.0f;
    public int playerHealth = 100;
    //public int attackForce = 10;

    public Text healthText;
    

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
                TakeDamage(Random.Range(5, 10));
            }
        }
        if (collision.collider.CompareTag("Enemy2"))
        {
            Collider2D[] enemiesHittig = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayers);
            foreach (Collider2D enemy in enemiesHittig)
            {
                TakeDamage(Random.Range(10, 20));
            }
        }
        if (collision.collider.CompareTag("Enemy3"))
        {
            Collider2D[] enemiesHittig = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayers);
            foreach (Collider2D enemy in enemiesHittig)
            {
                TakeDamage(Random.Range(20, 30));
            }
        }
        if (collision.collider.CompareTag("EnemyBoss"))
        {
            Collider2D[] enemiesHittig = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayers);
            foreach (Collider2D enemy in enemiesHittig)
            {
                TakeDamage(Random.Range(40, 70));
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
        healthText.text = playerHealth.ToString();
       
    }

    void Die()
    {
        Destroy(gameObject, 3f);
        SceneManager.LoadScene("GameOver");

    }
}
