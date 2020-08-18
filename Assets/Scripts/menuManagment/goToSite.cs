using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goToSite : MonoBehaviour
{
    public GameObject goToSiteBtn;
    public GameObject backToMeniu;
    // Start is called before the first frame update
    void Start()
    {
        backToMeniu.GetComponent<Button>().onClick.AddListener(()=>  back());
        goToSiteBtn.GetComponent<Button>().onClick.AddListener(()=> openUrl());
    }

    private void openUrl()
    {
        Application.OpenURL("http://google.com/");
    }
    private void back()
    {
        Application.LoadLevel("mainMenu");
    }
}
