using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int bloodSamples;

    public int gunSelect;
    public Animator animator;

    public bool pistolEquipped;

    

    public bool PickUpItem(GameObject obj)
    {
        
            switch (obj.tag)
            {
             case "Currency":

                 bloodSamples=+1;
                 return true;

            case "Ammo":

                GetComponent<Attack>().numberBullets +=15;
                return true;

            case "Pistol":
                animator.SetBool("HandGunEquipped", true);
                GetComponent<Attack>().fireArmEquipped = true;
                return true;

            default:
                    Debug.Log($"No handler implemented for {obj.tag}.");
                    return false;
            }

 
    }

}
