﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool DocHitPlayer;


    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            DocHitPlayer = true;
            
        }

    }
}


