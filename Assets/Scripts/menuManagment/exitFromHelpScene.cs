using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exitFromHelpScene : MonoBehaviour
{
    public GameObject exitBtn;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => loadMainScene());  
    }
    private void loadMainScene()
    {
        Application.LoadLevel("mainMenu");
    }
}
