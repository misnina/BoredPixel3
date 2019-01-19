using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            float cost = Inventory.instance.money - (Inventory.instance.fuelMax - Inventory.instance.fuel);
            if (cost > 0)
            {
                    Inventory.instance.money = (int)cost;
                    Inventory.instance.fuel = Inventory.instance.fuelMax;
                Inventory.instance.health = 5;
            }
            else
            {
                Inventory.instance.fuel += Inventory.instance.money;
                Inventory.instance.money = 0;
            }
        }
        
    }
}
