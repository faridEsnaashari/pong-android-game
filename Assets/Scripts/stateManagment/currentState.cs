using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class currentStatus
{
    public string[] playerNames=new string[2];
    public float[] sphere=new float[3];
    public float[] paddles=new float[2];
    public int[] score=new int[2];
    public bool inGame;
    public string sceneName;
    public bool help=false;
    public bool isBeginer=true;
    public float pauseTime;
    public float startTime;
}
