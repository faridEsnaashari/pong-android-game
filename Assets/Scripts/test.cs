using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Text>().text="khar";
        Debug.Log(this.GetComponent<Text>().text);
    }
}
