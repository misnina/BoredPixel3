using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFuel : MonoBehaviour
{

    public int cost;
    public int newFuelMax;
    public int newOreHold;
    [TextArea]
    public string description;
    private Button button;

    public void ChangeText()
    {
        button = GetComponent<Button>();
        UIManager.instance.text.text = description;
    }

    public void Buy()
    {
        if (Inventory.instance.money >= cost)
        {
            Inventory.instance.money -= cost;
            Inventory.instance.fuelMax = newFuelMax;
            button.interactable = false;
        }
    }

    public void OreHold()
    {
        if (Inventory.instance.money >= cost)
        {
            Inventory.instance.money -= cost;
            Inventory.instance.hold = newOreHold;
            button.interactable = false;
        }
    }
}
