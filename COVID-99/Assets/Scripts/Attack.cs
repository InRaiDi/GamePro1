using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public bool fireArmEquipped;

    public bool knifeEquipped;
    public int numberBullets;

    public Transform attackPoint;
    public GameObject bulletPrefab;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackForce = 5;

    private AudioSource audioSource;
    public AudioClip PunchSound;
    public AudioClip KnifeSound;
    public AudioClip ShotSound;
    public AudioClip EmptyGunSound;

    // Update is called once per frame

    void Start() {

      audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
       

        if (Input.GetButtonDown("Fire1"))
        {


            if (fireArmEquipped)
            {
               
                FireArmAttack();
                
                
            }
            else
            {
                MeleeAttack();
            }
        }


        void MeleeAttack()
        {
            if (knifeEquipped)
            {
                animator.SetBool("KnifeEquipped", true);
                attackForce = Random.Range(30, 40);
                Knife();

            }

            else
            {
                animator.SetBool("KnifeEquipped", false);
                attackForce = Random.Range(15, 30); ;
                Punch();
            }

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemies = enemy.GetComponent<Enemy>();
                enemies.TakeDamage(attackForce);
                enemies.isDamaged = true;
            }

        }
    }
    void Knife()
    {
       
        animator.SetTrigger("KnifeAttack");
        audioSource.clip = KnifeSound;
        audioSource.Play();

    }
    void Punch()
    {
       
        animator.SetTrigger("Attack");
        audioSource.clip = PunchSound;
        audioSource.Play();
    }

    void FireArmAttack()
    {
        if (numberBullets > 0)
        {
            animator.SetTrigger("Shoot");
            numberBullets--;
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.right * attackForce, ForceMode2D.Impulse);
            audioSource.clip = ShotSound;
            audioSource.Play();

        }
        else
        {
            audioSource.clip = EmptyGunSound;
            audioSource.Play();

        }

    }




}

