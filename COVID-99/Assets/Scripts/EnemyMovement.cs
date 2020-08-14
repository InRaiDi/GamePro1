using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public Transform[] target;
    public float speed;
    public bool toggleSpeedchange = true;
    //bool invokeOnce = false;
    public float followingDistance = 5;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 1f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;



    private Transform playerPos;
    private int current;


    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();

    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            calcuateNewMovementVector();
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position,playerPos.position) < followingDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }

         if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));


        //    else if (transform.position != target[current].position)
        //    {
        //        Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
        //        GetComponent<Rigidbody2D>().MovePosition(pos);
        //    }
        //    else
        //    {
        //        if (gameObject.tag == "Enemy")
        //        {
        //            current = (current + Random.Range(0, 4)) % target.Length;
        //        }
        //        else current = (current + 1) % target.Length;

        //    }

        //    if (toggleSpeedchange == true)
        //    {
        //        if (!invokeOnce)
        //        {
        //            StartCoroutine("cycleSpeed");
        //            invokeOnce = true;
        //        }

        //    }
        //    else
        //    {
        //        if (invokeOnce)
        //        {
        //            StopCoroutine("cycleSpeed");
        //            invokeOnce = false;
        //        }
        //    }
        //}

        //IEnumerator cycleSpeed()
        //{

        //    yield return new WaitForSeconds(3f);

        //    while (toggleSpeedchange)
        //    {
        //        speed += 2;
        //        yield return new WaitForSeconds(3f);
        //        speed -= 2;
        //        yield return new WaitForSeconds(3f);
        //    }


    }

}
