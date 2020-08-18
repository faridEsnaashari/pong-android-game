using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCircleActivationMnager : MonoBehaviour
{
    private float activedTime;
    private int showCount;
    private float activeDuration;

    private float deAcitveDuration;
    private float deActivedTime;

    private void Start()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().enabled=false;
    }
    private void Update()
    {
        if(Time.time>=activedTime+activeDuration)
        {
            deActivedTime=activedTime;
            transform.gameObject.GetComponent<SpriteRenderer>().enabled=false;
            if(showCount>0 && Time.time>=deActivedTime+deAcitveDuration)
            {
                showCount--;
                activedTime=Time.time;
                transform.gameObject.GetComponent<SpriteRenderer>().enabled=true;
            }
        }
    }
    public void activeRedCircle(float currentTime)
    {
        activedTime=currentTime;
        activeDuration=.5f;
        transform.gameObject.GetComponent<SpriteRenderer>().enabled=true;
    }
    public void initActiveRedCircle(float currentTime)
    {
        activedTime=currentTime;
        showCount=4;
        activeDuration=.2f;
        deAcitveDuration=activeDuration*2;
        deActivedTime=currentTime;
        transform.gameObject.GetComponent<SpriteRenderer>().enabled=true;
    }
}
