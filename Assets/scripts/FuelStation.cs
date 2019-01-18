using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Inventory.instance.money > 0)
            {
                int cost = Inventory.instance.money - (Inventory.instance.fuelMax - Inventory.instance.fuel);
                if (cost <= 0)
                {
                    //Do Nothing
                }
                else
                {
                    Inventory.instance.money = cost;
                    Inventory.instance.fuel = Inventory.instance.fuelMax;


                }
            }
            else
            {
                Inventory.instance.fuel += Inventory.instance.money;
                Inventory.instance.money = 0;
            }
        }
        
    }
}
