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
            Debug.Log("Mining Jade");
            Inventory.instance.jade++;
        }
        else if (collider.gameObject.name == "Cobalt")
        {
            Debug.Log("Mining Cobalt");
            Inventory.instance.cobalt++;
        }
    }

}
