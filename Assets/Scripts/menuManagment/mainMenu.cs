using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public GameObject aboutUs;
   public GameObject startBtn;
   public GameObject exitBtn;
//    public GameObject onePlayerOneDev;
//    public GameObject twoPlayerOneDev;
//    public GameObject helpBtn;
   public GameObject settingBtn;

   private AudioSource audio;

   void Start ()
    {
        aboutUs.GetComponent<Button>().onClick.AddListener(() => loadAboutUsScene());
        startBtn.GetComponent<Button>().onClick.AddListener(() => loadPlayMenuScene());
        exitBtn.GetComponent<Button>().onClick.AddListener(() => CloseGame());
        // onePlayerOneDev.GetComponent<Button>().onClick.AddListener(() => loadInputName1Player());
        // twoPlayerOneDev.GetComponent<Button>().onClick.AddListener(() => loadInputName2Player());
        // helpBtn.GetComponent<Button>().onClick.AddListener(() => loadHelpScene());
        settingBtn.GetComponent<Button>().onClick.AddListener(() => loadSettingScene());
	
        audio=GetComponent<AudioSource>();

    }
    private void loadPlayMenuScene()
    {
        Application.LoadLevel("playMenu");
    }

    private void loadSettingScene()
    {
        Application.LoadLevel("setting");
    }

    private void loadAboutUsScene()
    {
        Application.LoadLevel("aboutUs");
    }
    private void CloseGame()
    {
        Application.Quit();
    }
    // private void loadInputName1Player()
    // {
    //     currentStatus cs=new currentStatus();
    //     cs.sceneName="1player1device";
    //     saveController.saveStatus(cs);

    //     Application.LoadLevel("inputName1Player");
    // }
    // private void loadInputName2Player()
    // {
    //     currentStatus cs=new currentStatus();
    //     cs.sceneName="2player1device";
    //     saveController.saveStatus(cs);
        
    //     Application.LoadLevel("inputName2Player");
    // }
    // private void loadHelpScene()
    // {
    //     currentStatus cs=new currentStatus();
    //     cs.sceneName="help";
    //     saveController.saveStatus(cs);
    //     Application.LoadLevel("help");
    // }
}
