using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundAudioManager : MonoBehaviour
{
    private AudioSource audio;
    private string currentSceneName;
    public AudioClip playBackgroundAudio;
    public AudioClip menuBackgroundAudio;
    private static backgroundAudioManager instance=null;
    private void Start()
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged+=changeBackgroundAudio;

            audio=GetComponent<AudioSource>();
            // audio.clip=menuBackgroundAudio;
            audio.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        currentSceneName=SceneManager.GetActiveScene().name;
    }
    private void changeBackgroundAudio(Scene currentScene,Scene nextScene)
    {
        
        if(nextScene.name=="1player1device" || nextScene.name=="2player1device")
        {
            if(currentSceneName!="pauseMeniu")
            {
                audio.clip=playBackgroundAudio;
                audio.Play();
            }
        }
        if(nextScene.name=="help")
        {
            audio.clip=playBackgroundAudio;
            audio.Play();
        }
        
        if(nextScene.name=="mainMenu")
        {
            if(currentSceneName!="aboutUs" && currentSceneName!="setting" && currentSceneName!="playMenu")
            {
                audio.clip=menuBackgroundAudio;
                audio.Play();
            }
        }
    }
}
