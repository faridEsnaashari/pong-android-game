using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private void Update()
    {
        disableTutorial();
    }
    public void disableTutorial()
    {
        currentStatus cs= saveController.loadStatus();
        if(!(cs.help))
        {
            gameObject.SetActive(false);
        }
        else if(Input.touches.Length>0||Input.GetMouseButtonDown(0))
        {
            cs.help=false;
            saveController.saveStatus(cs);
            
            gameObject.SetActive(false);
        }
    }

}
