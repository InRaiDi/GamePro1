using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public bool toggleSpeedchange = true;
    bool invokeOnce = false;
  


    private int current;



    // Update is called once per frame
    void Update()
    {
   

        if (transform.position != target[current].position)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else
        {
            if (gameObject.tag == "Enemy")
            {
                current = (current + Random.Range(0, 4)) % target.Length;
            }
            else current = (current + 1) % target.Length;

        }

        if (toggleSpeedchange == true)
        {
            if (!invokeOnce)
            {
                StartCoroutine("cycleSpeed");
                invokeOnce = true;
            }

        }
        else
        {
            if (invokeOnce)
            {
                StopCoroutine("cycleSpeed");
                invokeOnce = false;
            }
        }
    }

    IEnumerator cycleSpeed()
    {

        yield return new WaitForSeconds(3f);

        while (toggleSpeedchange)
        {
            speed += 2;
            yield return new WaitForSeconds(3f);
            speed -= 2;
            yield return new WaitForSeconds(3f);
        }


    }

    //class MoveToPlayer
    //{
    //public Transform player;
    //public float moveSpeed = 2f;
    //private Rigidbody2D rb;
    //private Vector2 movement;
    //float distance = Vector3.Distance(player.transform.position, transform.position);

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = this.GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (distance > 5)
    //    {

    //        Vector3 direction = player.position - transform.position;
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        rb.rotation = angle;
    //        direction.Normalize();
    //        movement = direction;
    //    }
    //}
    //private void FixedUpdate()
    //{
    //    moveCharacter(movement);
    //}
    //void moveCharacter(Vector2 direction)
    //{
    //    rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    //}
    //}

}
