﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 30f;

    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Random.Range(40, 60));
            Destroy(gameObject);

        }

    }
    private void Update()
    {
        Destroy(gameObject, 2.0f);
    }

}
