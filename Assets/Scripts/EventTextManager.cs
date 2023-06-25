using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EventTextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private AudioSource sound1;
    [SerializeField] private AudioSource sound2;
    [SerializeField] private AudioSource sound3;

    IEnumerator waitForSound(AudioSource source)
    {
        //Wait Until Sound has finished playing
        while (source.isPlaying)
        {
            yield return null;
        }

        //Auidio has finished playing
        Resume();
    }
    
    public void setTextStage1()
    {
        text.text = "Sehr gut. Sie haben bereits 25% der Strecke zurückgelegt. \nMachen sie jetzt nicht schlapp!!!";
        sound1.Play();
        Time.timeScale = 0.0f;
        StartCoroutine(waitForSound(sound1));
    }
    public void setTextStage2()
    {
        text.text = "Sie sind ein Mitarbeiter für den man sich nicht schämen muss. \nNoch 50% und ich kann meinen Plan endlich umsetzten!";
        sound2.Play();
        Time.timeScale = 0.0f;
        StartCoroutine(waitForSound(sound2));
    }
    public void setTextStage3()
    {
        text.text = "Sie befinden sich nun auf der Zielgeraden! \nNoch 25% und ich gebe ihnen eine Gehaltserhöhung!";
        sound3.Play();
        Time.timeScale = 0.0f;
        StartCoroutine(waitForSound(sound3));
    }


    private void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
