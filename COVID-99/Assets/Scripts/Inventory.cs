using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int bloodSamples;

    public int gunSelect;
    public Animator animator;
    private AudioSource audioSource;
    public AudioClip InventorySound;

    public Text bloodSamplesText;
    public Text ammoText;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    public bool PickUpItem(GameObject obj)
    {
        audioSource.clip = InventorySound;
        audioSource.Play();

        switch (obj.tag)
            {
             case "Currency":

                 bloodSamples++;
                 bloodSamplesText.text = bloodSamples.ToString();
                 return true;

            case "Ammo":

                GetComponent<Attack>().numberBullets +=7;
                ammoText.text = GetComponent<Attack>().numberBullets.ToString();
                return true;

            case "Pistol":
                animator.SetBool("HandGunEquipped", true);
                GetComponent<Attack>().hasGun= true;
                GetComponent<Attack>().fireArmEquipped= true;
                return true;

            default:
                    Debug.Log($"No handler implemented for {obj.tag}.");
                    return false;
            }

 
    }

}
