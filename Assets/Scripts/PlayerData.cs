using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int score;
    public string name;

    //constructor
    public PlayerData(int _bestScore, string userName )
    {
        score = _bestScore;
        name = userName;
    }
}

