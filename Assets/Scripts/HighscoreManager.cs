using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class HighScoreManager : MonoBehaviour
{
    public int currentHighscore = 0;
    public void SaveHighscore(string name)
    {
        HighscoreTable.AddHighscoreEntry(currentHighscore, name);
        //Debug.Log("TODO Highscore (name = " + name + ")");
    }
}
