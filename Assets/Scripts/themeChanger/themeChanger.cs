using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeChanger : MonoBehaviour
{
    public GameObject classicUI;

    public GameObject graphicallUI;

    private void Start()
    {
        settingStatus ss = saveController.loadSetting();

        if(ss.theme == "graphicall")
        {
            graphicallUI.SetActive(true);

            classicUI.SetActive(false);
        }
        else
        {
            classicUI.SetActive(true);

            graphicallUI.SetActive(false);
        }
    }
}
