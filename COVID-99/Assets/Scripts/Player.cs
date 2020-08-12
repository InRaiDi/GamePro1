using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class Player : MonoBehaviour
{
    public float attackRange = 1.0f;
    public float playerHealth = 100f;
   
    //public int attackForce = 10;

    public Text healthText;
    public Text vaccinesText;

    public GameObject Gate;
    public GameObject doc;

    public GameObject hitEffect;
    public GameObject dieEffect;
    public LayerMask enemiesLayers;
    public Transform attackPoint;
    public GameObject deathAnimation;
    private AudioSource audioSource;
    public AudioClip DamageTakensSound;

    [Range(1, 10)]
    public int damagePerSecond = 1;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        playerHealth -= damagePerSecond * Time.deltaTime;

        healthText.text = (int)playerHealth + "";
        if (playerHealth < 25)
        {

            //change text color, make bigger, different color
            //accelerate music -- semthing to let the player know that they are about to die if they dont do something about it. (haha)

            if (playerHealth < 1)
            {
                Die();
            }

        }


        if (GetComponent<Inventory>().bloodSamples > 0 && Input.GetKeyDown(KeyCode.R)) //Press R to recoop health
        {
            playerHealth = 100;
            GetComponent<Inventory>().bloodSamples--;

            vaccinesText.text = GetComponent<Inventory>().bloodSamples.ToString();


            //make healing sound
        }
        else
        {
            //display message of empty slot -- something
            //make empty sound
        }

        //if (doc.GetComponent<NextLevel>().DocHitPlayer && Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("enter");
        //    OpenGate();
        //    //make some sound
        //}


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
            Die();
        }


    }

    void Die()
    {
        //deathsound

        GameObject EffectDeath = Instantiate(dieEffect, transform.position, Quaternion.identity);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, 2f);
        SceneManager.LoadScene("GameOver");

    }


    //void OpenGate()
    //{
    //    if (gameObject.GetComponent<Inventory>().bloodSamples >= 3)
    //    {
    //        gameObject.GetComponent<Inventory>().bloodSamples -= 3;
    //        Destroy(Gate, 0f);
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Not Enough vaccines to heal the doctor");
    //    }
    //}

}
