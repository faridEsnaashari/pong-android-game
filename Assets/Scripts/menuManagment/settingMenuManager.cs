using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingMenuManager : MonoBehaviour
{
    public GameObject englishBtn;
    public GameObject persianBtn;
    public GameObject backToMeniu;
    public GameObject classicBtn;
    public GameObject graphicallBtn;

    private void Start()
    {
        englishBtn.GetComponent<Button>().onClick.AddListener(() => changeLocalization("english"));
        persianBtn.GetComponent<Button>().onClick.AddListener(() => changeLocalization("persian"));
        classicBtn.GetComponent<Button>().onClick.AddListener(() => changeTheme("classic"));
        graphicallBtn.GetComponent<Button>().onClick.AddListener(() => changeTheme("graphicall"));
        backToMeniu.GetComponent<Button>().onClick.AddListener(() => back());
    }

    private void changeTheme(string themeName)
    {
        settingStatus ss = saveController.loadSetting();
        ss.theme=themeName;
        saveController.saveSetting(ss);
        Debug.Log(ss.theme);

        Application.LoadLevel("mainMenu");
    }

    private void changeLocalization(string language)
    {
        settingStatus ss = saveController.loadSetting();
        ss.language = language;
        saveController.saveSetting(ss);

        LocalizationManager.instance.LoadLocalizedText(ss.language);

        Application.LoadLevel("mainMenu");
    }
    private void back()
    {
        Application.LoadLevel("mainMenu");
    }

}
