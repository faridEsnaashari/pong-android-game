using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver1Player : gameOverBase
{
    private int score;
    public void setupGameOverMSGUI(int _score)
    {
        score=_score;

        declareGameOvereMSG();
        assignGameOverMSGToUI();
    }

    protected override void declareGameOvereMSG()
    {
        base.gameOverMSG="the game is over\r\n"+
                         "your score is : "+ score;
    }
}
