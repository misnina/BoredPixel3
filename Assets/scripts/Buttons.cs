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
        AudioManager.instance.PlaySound("upgrade");
        SceneManager.LoadScene("menu");
    }

    public void Play()
    {
        AudioManager.instance.PlaySound("upgrade");
        SceneManager.LoadScene("main");
    }

    public void SwapWindows(int windowNum)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNum)
            {
                AudioManager.instance.PlaySound("upgrade");
                windows[i].SetActive(true);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
}
