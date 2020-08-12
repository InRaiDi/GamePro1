using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool DocHitPlayer;

    public GameObject gate;
    public GameObject inventoryObject;



    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            DocHitPlayer = true;

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        DocHitPlayer = false;
    }

    void Update()
    {
        if (DocHitPlayer && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryObject.GetComponent<Inventory>().bloodSamples >= 3)
            {
                OpenGate();
            }

            else
            {
                Debug.LogWarning("Not Enough vaccines to heal the doctor , or not close enought or not pressed E");
            }
        }
       

    }


    void OpenGate()
    {
        inventoryObject.GetComponent<Inventory>().bloodSamples -= 3;
        Destroy(gate, 0f);

    }
}


