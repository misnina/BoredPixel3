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
        }
    }

}
