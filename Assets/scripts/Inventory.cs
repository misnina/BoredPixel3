using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int money;
    [Range(0,100)]
    public int fuel = 50;
    public int jade;
    public int cobalt;
    public int ruby;

    public int jadeHold = 10;
    public int cobaltHold = 10;
    public int rubyHold = 5;

    public Slider fuelValue;
    public Text jadeAmount;
    public Text cobaltAmount;
    public Text rubyAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(jade > jadeHold)
        {
            jade = jadeHold;
        }

        if (cobalt > cobaltHold)
        {
            cobalt = cobaltHold;
        }

        if (ruby > rubyHold)
        {
            ruby = rubyHold;
        }

        fuelValue.value = fuel;
        jadeAmount.text = jade + "/" + jadeHold;
        cobaltAmount.text = cobalt + "/" + cobaltHold;
        rubyAmount.text = ruby + "/" + rubyHold;
    }
}
