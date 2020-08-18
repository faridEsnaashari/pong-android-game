using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour 
{
    public Font englishFont;
    public Font persianFont;
    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    private void Start() 
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
        {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (gameObject);


        settingStatus ss = saveController.loadSetting();
        LoadLocalizedText(ss.language);
    }

    public void LoadLocalizedText(string language)
    {
        localizedText = new Dictionary<string, string> ();

        string fileName = getFileName(language);
        TextAsset ta=Resources.Load<TextAsset>(fileName);
        string dataAsJson = ta.text;
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);
        for (int i = 0; i < loadedData.items.Length; i++) 
        {
            localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);    
        }
        Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");

        isReady = true;
    }

    private string getFileName(string language)
    {
        if(language == "persian")
        {
            return "localizedText_fa";
        }
        else
        {
            return "localizedText_en";
        }
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey (key)) 
        {
            result = localizedText [key];
        }

        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}