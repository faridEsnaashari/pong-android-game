using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{
    public Text timerUI;

    public void updateTimerUI(float remainingTime)
    {
        int minute = computeMinute(remainingTime);
        int second = computeSecond(remainingTime);

        // timerUI.text= minute + " : " + second;
        timerUI.text= second.ToString();
    }

    private int computeMinute(float remainingTime)
    {
        return (int)(remainingTime/60);
    }

    private int computeSecond(float remainingTime)
    {
        return (int)(remainingTime%60);
    }
}
