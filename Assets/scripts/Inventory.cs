using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int money;
    [Range(0,50)]
    public int fuel = 30;
    public int jade;
    public int cobalt;

    public Slider fuelValue;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        fuelValue.value = fuel;
    }
}
