using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerController.instance.canMove = false;
            UIManager.instance.shopUI.SetActive(true);
            UIManager.instance.gameUI.SetActive(false);
        }
    }

    public void Close()
    {
        PlayerController.instance.canMove = true;
        UIManager.instance.shopUI.SetActive(false);
        UIManager.instance.gameUI.SetActive(true);
    }
}
