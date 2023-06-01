using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;
    public UnityEvent GameFinished;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        GamePaused.Invoke();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        GameResumed.Invoke();
    }

    public void GameOver()
    {
        isPaused = true;
        Time.timeScale = 0;
        GameFinished.Invoke();
    }
}
