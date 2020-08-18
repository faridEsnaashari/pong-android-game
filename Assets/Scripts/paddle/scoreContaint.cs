using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreContaint : MonoBehaviour
{
    int score=0;
    public void incScore()
	{
		score++;
	}
    public void decScore()
    {
        if(score>0)
        {

            score--;
        }
    }
	public int getScore()
    {
        return score;
    }
    public void setScore(int s)
    {
        score=s;
    }
   
}