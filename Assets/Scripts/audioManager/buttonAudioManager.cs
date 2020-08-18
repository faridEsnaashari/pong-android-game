using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonAudioManager : MonoBehaviour
{
    private AudioSource audio;
    private static buttonAudioManager instance=null;

    private void Start()
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged+=setAudioToCurrentSceneButtons;

            audio=GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        GameObject[] buttons=getCurrentSceneButtons();
        setAudioToCurrentSceneButtons(buttons);
    }
    private void setAudioToCurrentSceneButtons(Scene currentScene, Scene nextScene)
    {
        GameObject[] buttons=getCurrentSceneButtons();

        setButtonsOnClickEvents(buttons);
    }
    private void setButtonsOnClickEvents(GameObject[] buttons)
    {
        for(int i=0; i<buttons.Length ; i++)
        {
            buttons[i].GetComponent<Button>().onClick.AddListener(() => playButtonAudio());
        }
    }
    private GameObject[] getCurrentSceneButtons()
    {
        return GameObject.FindGameObjectsWithTag("button");
    }
    private void setAudioToCurrentSceneButtons(GameObject[] buttons)
    {
        setButtonsOnClickEvents(buttons);
    }
    private void playButtonAudio()
    {
        audio.Play();
    }
}
