using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver2Player : gameOverBase
{
    private string winnerName;
    public void setupGameOverMSGUI(string _winnerName)
    {
        winnerName=_winnerName;

        declareGameOvereMSG();
        base.assignGameOverMSGToUI();
    }

    protected override void declareGameOvereMSG()
    {
        if(winnerName=="equal")
        {
            base.gameOverMSG="equal";    
        }
        else
        {
            base.gameOverMSG="the game is over\r\n" +
                         winnerName.ToUpper() + "WIN...";
        }
        
    }
}
