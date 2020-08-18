using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localizedInputFeild : MonoBehaviour
{
   public string key;
   public Text text;

    // Use this for initialization
    private void Start () 
    {
        this.GetComponent<InputField>().text=LocalizationManager.instance.GetLocalizedValue (key);

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
