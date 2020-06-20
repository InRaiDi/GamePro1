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
    

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
        
        void Attack()
        {
            

            if (fireArmEquipped) 
            {
                GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(attackPoint.right * bulletForce, ForceMode2D.Impulse);
            }
            else
            {
                if (knifeEquipped)
                {
                    animator.SetBool("KnifeEquipped", true);
                    knife();
                }
                else
                {
                    punch();
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
    }
}
