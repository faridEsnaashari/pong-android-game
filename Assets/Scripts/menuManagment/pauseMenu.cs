using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class pauseMenu : MonoBehaviour {
    public GameObject reStartBtn;
    public GameObject mainMenuBtn;
    public GameObject resumeBtn; 
    public GameObject helpBtn;
	void Start ()
    {
        mainMenuBtn.GetComponent<Button>().onClick.AddListener(() => loadMainMenu());
        reStartBtn.GetComponent<Button>().onClick.AddListener(() => loadInputName());
        resumeBtn.GetComponent<Button>().onClick.AddListener(() => loadGame());
        helpBtn.GetComponent<Button>().onClick.AddListener(() => loadGameWithHelp());
	}
    private void loadGame()
    {
        currentStatus cs=saveController.loadStatus();
        if(cs.sceneName=="1player1device")
        {
            Application.LoadLevel("1player1device");
        }
        else if(cs.sceneName=="2player1device")
        {
            Application.LoadLevel("2player1device");
        }
    }
    private void loadInputName()
    {
        currentStatus cs=saveController.loadStatus();
        if(cs.sceneName=="1player1device")
        {
            Application.LoadLevel("inputName1Player");
        }
        else if(cs.sceneName=="2player1device")
        {
            Application.LoadLevel("inputName2Player");
        }
    }
    private void loadMainMenu()
    {
        Application.LoadLevel("mainMenu");
    }
    private void loadGameWithHelp()
    {
        currentStatus cs=saveController.loadStatus();
        cs.help=true;
        saveController.saveStatus(cs);

        if(cs.sceneName=="1player1device")
        {
            Application.LoadLevel("1player1device");
        }
        else if(cs.sceneName=="2player1device")
        {
            Application.LoadLevel("2player1device");
        }
    }
}
