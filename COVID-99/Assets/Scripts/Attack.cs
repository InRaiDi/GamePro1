using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public bool fireArmEquipped;
    public bool hasGun;

    public bool knifeEquipped;
    public int numberBullets;



    public Transform attackPoint;
    public GameObject bulletPrefab;

    public float attackRange = 2f;
    public LayerMask enemyLayers;

    public int attackForce = 5;

    private AudioSource audioSource;
    public AudioClip PunchSound;
    public AudioClip KnifeSound;
    public AudioClip ShotSound;
    public AudioClip EmptyGunSound;

    public Text ammoText;

    // Update is called once per frame

    void Start()
    {
        animator.SetBool("HandGunEquipped", false);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (fireArmEquipped && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Change to knife");
            fireArmEquipped = false;
            animator.SetBool("HandGunEquipped", false);

        }

        if (hasGun && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Change to Gun");
            fireArmEquipped = true;
            animator.SetBool("HandGunEquipped", true);
        }

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

        ammoText.text = GetComponent<Attack>().numberBullets.ToString();

    }
    void MeleeAttack()
    {

        attackForce = Random.Range(20, 50);
        animator.SetTrigger("KnifeAttack");
        audioSource.clip = KnifeSound;
        audioSource.Play();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemies = enemy.GetComponent<Enemy>();
            enemies.TakeDamage(attackForce);
        }

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


