using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int health = 5;
    public int money;
    public float fuel;
    public int fuelMax = 100;
    public int jade;
    public int cobalt;
    public int ruby;
    public int diamond;
    public int garnet;
    public int sapphire;

    public int hold = 5;

    public Slider fuelValue;
    public Slider healthValue;
    public Text moneyAmount;
    public Text rubyAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        healthValue.value = health;
        fuelValue.value = fuel;
        fuelValue.maxValue = fuelMax;
        moneyAmount.text = money.ToString();
        rubyAmount.text = (jade + cobalt + ruby + diamond + garnet + sapphire) + "/" + hold;
    }
}
