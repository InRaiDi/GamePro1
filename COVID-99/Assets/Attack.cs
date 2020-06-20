using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public bool fireArmEquipped = false;

    public bool knifeEquipped = false;
    public int numberBullets = 0;


    public Transform attackPoint;
    public GameObject bulletPrefab;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackForce = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            if (fireArmEquipped)
            {
                fireArmAttack();
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
                attackForce = 10f; 
                knife();
            }
            else
            {
                attackForce = 5f;
                punch();
            }

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)

            {
                Debug.Log("You hit " + enemy.name);
            }
        }
    }
    void knife()
    {
        animator.SetTrigger("KnifeAttack");
        
    }
    void punch()
    {
        animator.SetTrigger("Attack");
    }
    void fireArmAttack()
    {

        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(attackPoint.right * attackForce, ForceMode2D.Impulse);
    }
}
