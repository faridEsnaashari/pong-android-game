using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour {

    public string key;

    // Use this for initialization
    void Start () 
    {
        Text text = GetComponent<Text> ();
        text.text = LocalizationManager.instance.GetLocalizedValue (key);
        
        settingStatus ss = saveController.loadSetting();

        if(ss.language == "persian")
        {
            text.font=LocalizationManager.instance.persianFont;
        }
        else if(ss.language == "english")
        {
            text.font=LocalizationManager.instance.englishFont;
        }
    }

}