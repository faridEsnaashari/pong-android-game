using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class gameOverBase : MonoBehaviour
{
    protected string gameOverMSG;

    public GameObject restart;
    public GameObject exit;
    public Text gameOverMSGUI;
    

    private void Start()
    {
        restart.GetComponent<Button>().onClick.AddListener(() => loadInputName());
        exit.GetComponent<Button>().onClick.AddListener(() => loadMainMenu());
    }
    protected abstract void declareGameOvereMSG();
    protected void assignGameOverMSGToUI()
    {
        gameOverMSGUI.text=gameOverMSG;
    }

    public void loadInputName()
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
    public void loadMainMenu()
    {
        Application.LoadLevel("mainMenu");
    }

}