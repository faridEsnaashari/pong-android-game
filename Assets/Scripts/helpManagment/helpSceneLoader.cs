using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class helpSceneLoader : MonoBehaviour
{
    private void Awake()
    {

        if(!(saveController.helpExists()))
        {
            HelpStatus hs=new HelpStatus();
            saveController.saveHelpStatus(hs);
            Application.LoadLevel("help");
        }
    }
}
