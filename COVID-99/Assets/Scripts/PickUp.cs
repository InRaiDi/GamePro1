using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>();


        if (inventory)
        {

            bool pickedUp = inventory.PickUpItem(gameObject);
            //inventory.PickUpItem(gameObject);
            if (pickedUp)
            {
                RemoveItem();
            }


        }
    }


    void RemoveItem()
    {
        Destroy(gameObject);
    }


}
