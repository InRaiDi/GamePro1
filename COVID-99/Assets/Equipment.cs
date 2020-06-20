using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Attack
{ 

    // Update is called once per frame
    void Update()
    {
        if (numberBullets>=1 && !fireArmEquipped)
        {
            fireArmEquipped = true;
        }
        else if (!knifeEquipped) //&& close to a knife && Input.GetKeyDown("f"))
        {
            getKnife();

        }
    }

    void getKnife()
    {
            System.Console.WriteLine("gets knife");
            knifeEquipped = true;
        }
    }

