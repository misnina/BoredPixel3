﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    public static UIManager instance;

    public GameObject shopUI;
    public GameObject gameUI;

    private void Awake()
    {
        instance = this;
    }

}
