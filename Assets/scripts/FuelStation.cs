using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Inventory.instance.fuel = 100;
        }
        
    }
}
