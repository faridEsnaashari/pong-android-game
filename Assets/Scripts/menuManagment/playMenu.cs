using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour
{
   public GameObject onePlayerOneDev;
   public GameObject twoPlayerOneDev;
   public GameObject helpBtn;
   public GameObject backToMeniu;
    private void Start()
    {
        onePlayerOneDev.GetComponent<Button>().onClick.AddListener(() => loadInputName1Player());
        twoPlayerOneDev.GetComponent<Button>().onClick.AddListener(() => loadInputName2Player());
        helpBtn.GetComponent<Button>().onClick.AddListener(() => loadHelpScene());
        backToMeniu.GetComponent<Button>().onClick.AddListener(()=>  back());
    }
    private void back()
    {
        Application.LoadLevel("mainMenu");
    }
    private void loadInputName1Player()
    {
        currentStatus cs=new currentStatus();
        cs.sceneName="1player1device";
        saveController.saveStatus(cs);

        Application.LoadLevel("inputName1Player");
    }
    private void loadInputName2Player()
    {
        currentStatus cs=new currentStatus();
        cs.sceneName="2player1device";
        saveController.saveStatus(cs);
        
        Application.LoadLevel("inputName2Player");
    }
    private void loadHelpScene()
    {
        currentStatus cs=new currentStatus();
        cs.sceneName="help";
        saveController.saveStatus(cs);
        Application.LoadLevel("help");
    }
}
