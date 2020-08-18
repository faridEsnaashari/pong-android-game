using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class inputName : MonoBehaviour
{
    public InputField input1; 
    public InputField input2;
    public GameObject submitNamesBtn;
    private bool convertAllowed1;
    private bool convertAllowed2;
    private void Start()
    {
        submitNamesBtn.GetComponent<Button>().onClick.AddListener(()=> submitClicked());
        currentStatus cs=saveController.loadStatus();
    }
    public void convertInput1()
    {
        // if(convertAllowed1)
        // {
            input1.text=Fa.faConvert(input1.text.ToString());
        // }
        // else
        // {
        //     convertAllowed1=true;
        // }
    }
    public void convertInput2()
    {
        // if(convertAllowed2)
        // {
            input2.text=Fa.faConvert(input2.text.ToString());
        // }
        // else
        // {
        //     convertAllowed2=true;
        // }
    }
    private void submitClicked()
    {
        currentStatus cs=saveController.loadStatus();
        cs.inGame=false;


        if(cs.sceneName=="1player1device")
        {
            cs.playerNames[0]=input1.text.ToString();
            saveController.saveStatus(cs);

            Application.LoadLevel("1player1device");
        }
        else if(cs.sceneName=="2player1device")
        {
            cs.playerNames[0]=input1.text.ToString();
            cs.playerNames[1]=input2.text.ToString();
            saveController.saveStatus(cs);

            Application.LoadLevel("2player1device");
        }
    }
}
