using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster
{
    public string MonName;
    public string Type;
    public int Health;

    public string Parent1Type;
    public string Parent2Type;

    public Monster(string monName, string type, int health, string parent1Type, string parent2Type)
    {
        MonName = monName;
        Type = type;
        Health = health;
        Parent1Type = parent1Type;
        Parent2Type = parent2Type;

    }

}
