using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public static Mineral instance;

    private void Start()
    {
        instance = this;
    }

    public void Mine(Collider2D collider)
    {
        if ((Inventory.instance.jade + Inventory.instance.cobalt + Inventory.instance.ruby + Inventory.instance.diamond+ Inventory.instance.garnet + Inventory.instance.sapphire) != Inventory.instance.hold)
        {
            if (collider.gameObject.name == "Jade")
            {
                Inventory.instance.jade++;
            }
            else if (collider.gameObject.name == "Cobalt")
            {
                Inventory.instance.cobalt++;
            }
            else if (collider.gameObject.name == "Ruby")
            {
                Inventory.instance.ruby++;
            } else if (collider.gameObject.name == "Diamond")
            {
                Inventory.instance.diamond++;
            } else if (collider.gameObject.name == "Garnet")
            {
                Inventory.instance.garnet++;
            } else if (collider.gameObject.name == "Sapphire")
            {
                Inventory.instance.sapphire++;
            }
            else
            {
                Inventory.instance.jade++;
            }
        }

            


    }

}
