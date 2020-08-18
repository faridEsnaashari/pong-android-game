using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingLoader : MonoBehaviour
{
    private void Start()
    {
        if(!(saveController.settingStatusExists()))
        {
            settingStatus ss = new settingStatus();
            saveController.saveSetting(ss);
        }
    }

}
