using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour { 

    public static string playerName;
    public GameObject userName;
    public GameObject infoText;
    private int score;
    private string bestName;

    private void Start()
    {
        LoadPlayer();
        PrintInfo();
    }


    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void SaveName()
    {
        playerName = userName.GetComponent<TextMeshProUGUI>().text;
    }

    private void PrintInfo()
    {
        infoText.GetComponent<TextMeshProUGUI>().text = "Best Score: " + bestName + ": " + score;
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayerAndScore();

        score = data.score;
        bestName = data.name;
    }
}
