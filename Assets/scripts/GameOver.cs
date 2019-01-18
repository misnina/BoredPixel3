using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if(Inventory.instance.fuel <= 0)
        {
            SceneManager.LoadScene("main");
        }

        if(Inventory.instance.health <= 0)
        {
            SceneManager.LoadScene("main");
        }
    }
}
