using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Inventory.instance.money += Inventory.instance.jade + Inventory.instance.cobalt + Inventory.instance.ruby;
            Inventory.instance.jade = 0;
            Inventory.instance.cobalt = 0;
            Inventory.instance.ruby = 0;
        }
    }

}
