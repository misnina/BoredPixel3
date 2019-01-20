using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject[] windows;

    public void Start()
    {
        Invoke("ShowMenu", 3f);
    }

    private void ShowMenu()
    {
        windows[0].SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("main");
    }

    public void SwapWindows(int windowNum)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNum)
            {
                windows[i].SetActive(true);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
}
