using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //OnClick Play Button
    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    //OnClick Quit Button
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowHighscores()
    {
        SceneManager.LoadScene("HighscoreTable");
    }

}
