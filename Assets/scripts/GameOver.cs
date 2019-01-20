using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if(Inventory.instance.fuel <= 0 || Inventory.instance.health <= 0)
        {
            PlayerController.instance.dead = true;
            Invoke("Death", 0.5f);
            
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("menu");
    }
}
