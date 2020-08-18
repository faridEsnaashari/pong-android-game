using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameController : gameControllerBase
{

	public Text[] scoreUI;

	private const float timerFor2Player=30;

	protected override void Start()
	{
		base.Start();

		base.timeOfTimer=timerFor2Player;
	}
	
	protected override void assignPlayerNameToUI()
	{
		currentStatus cs=saveController.loadStatus();
		scoreUI[3].text=cs.playerNames[0];
		scoreUI[4].text=cs.playerNames[1];
		for (int i = 0; i < 2; i++)
		{
			scoreUI[i].text=(instedElements[i].GetComponent<scoreContaint>().getScore()).ToString();
		}
	}
	protected override void saveCurrentStatus()
	{
		currentStatus cs=saveController.loadStatus();

		cs.sphere[0]=instedElements[2].transform.position.x;
		cs.sphere[1]=instedElements[2].transform.position.z;
		cs.sphere[2]=instedElements[2].transform.eulerAngles.y;

		cs.paddles[0]=instedElements[0].transform.position.z;
		cs.paddles[1]=instedElements[1].transform.position.z;

		cs.score[0]=instedElements[0].GetComponent<scoreContaint>().getScore();
		cs.score[1]=instedElements[1].GetComponent<scoreContaint>().getScore();

		cs.inGame=true;

		cs.pauseTime=Time.time;
		cs.startTime=base.startTime;
		
		saveController.saveStatus(cs);

		Application.LoadLevel("pauseMeniu");
	}
	protected override void loadLastStatus()
	{
		currentStatus cs = saveController.loadStatus();

		
		if(cs.inGame)
		{
			instedElements[2].transform.position=new Vector3(cs.sphere[0],instedElements[2].transform.position.y,cs.sphere[1]);
			instedElements[2].transform.eulerAngles=new Vector3(0,0,0);
			instedElements[2].transform.Rotate(0,cs.sphere[2],0);
			instedElements[0].transform.position=new Vector3(instedElements[0].transform.position.x,instedElements[0].transform.position.y,cs.paddles[0]);
			instedElements[1].transform.position=new Vector3(instedElements[1].transform.position.x,instedElements[1].transform.position.y,cs.paddles[1]);
			instedElements[0].GetComponent<scoreContaint>().setScore(cs.score[0]);
			instedElements[1].GetComponent<scoreContaint>().setScore(cs.score[1]);
			base.startTime=cs.startTime+(Time.time-cs.pauseTime);

			updateScoreUI();
		}
		cs.inGame=false;
	}

	protected override void updateScoreUI()
	{
		currentStatus cs=saveController.loadStatus();
		for (int i = 0; i < 2; i++)
		{
			scoreUI[i].text=(instedElements[i].GetComponent<scoreContaint>().getScore()).ToString();
		}
	}
	protected override void computeScore(string status)
	{
		if(!(instedElements[2].GetComponent<ball>().getScoreUpdated()))
		{
			if (status=="lose")
			{
				if(getBallDir()=="right")
				{
					instedElements[0].GetComponent<scoreContaint>().decScore();
				}
				else
				{
					instedElements[1].GetComponent<scoreContaint>().decScore();	
				}
			}
			if(status=="ringCatch")
			{
				if(getBallDir()=="right")
				{
					instedElements[0].GetComponent<scoreContaint>().incScore();
					instedElements[0].transform.Find(ss.theme+"/redCircle").gameObject.GetComponent<redCircleActivationMnager>().activeRedCircle(Time.time);

					// checkGameOver(instedElements[0].GetComponent<scoreContaint>().getScore());
				}
				else
				{
					instedElements[1].GetComponent<scoreContaint>().incScore();	
					instedElements[1].transform.Find(ss.theme+"/redCircle").gameObject.GetComponent<redCircleActivationMnager>().activeRedCircle(Time.time);

					// checkGameOver(instedElements[1].GetComponent<scoreContaint>().getScore());
				} 
			}
			instedElements[2].GetComponent<ball>().setScoreUpdated(true);
		}

	}
	protected override void gameReset()
	{
		scoreUI[2].enabled = true;
		if(noTouchOnScreen())
		{
			if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
			//if(Input.touchCount>0)
			{
				Destroy(instedElements[2]);
				instedElements[2]=elementsInst(gameElements[2]);
				instedElements[2].GetComponent<ball>().setRandomLook();
				instedElements[0].GetComponent<rightPaddle>().setStartPosition();
				instedElements[1].GetComponent<leftPaddle>().setStartPosition();
				scoreUI[2].enabled = false;
				noTouchOnScreenFlag=false;
			}
		}		
	}
	// private void checkGameOver(int score)
	// {
	// 	if(score>=limitGameOverScore)
	// 	{
	// 		currentStatus cs =saveController.loadStatus();

	// 		if(instedElements[0].GetComponent<scoreContaint>().getScore()>=limitGameOverScore)
	// 		{
	// 			gameOver(cs.playerNames[1]);
	// 		}
	// 		else
	// 		{
	// 			gameOver(cs.playerNames[0]);
	// 		}
	// 	}
	// }	
	// private void gameOver(string player)
	// {
	// 	gameOverUI.SetActive(true);
	// 	gameOverManager.GetComponent<gameOver>().setWinner(player);
		
	// 	instedElements[2].GetComponent<ball>().setSpeed("stop");
	// }
	protected override void setUpGameOverMSGUI()
	{
		string winnerName=getWinnerName();
		gameOverManager.GetComponent<gameOver2Player>().setupGameOverMSGUI(winnerName);
	}
	private string getWinnerName()
	{
		int leftPlayerScore=base.instedElements[1].GetComponent<scoreContaint>().getScore();
		int rightPlayerScore=base.instedElements[0].GetComponent<scoreContaint>().getScore();
		currentStatus cs=saveController.loadStatus();

		if(rightPlayerScore > leftPlayerScore)
		 {
			return cs.playerNames[1];
		 }

		 else if(rightPlayerScore < leftPlayerScore)
		 {
			return cs.playerNames[0];
		 }

		 else
		 {
			return "equal";
		 }
	}
}
