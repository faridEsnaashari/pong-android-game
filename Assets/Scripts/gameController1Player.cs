using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameController1Player : gameControllerBase
{
	public Text[] scoreUI;

	private const float timerFor1Player=30;

	protected override void Start()
	{
		base.Start();

		base.timeOfTimer=timerFor1Player;
	}
	

	protected override void assignPlayerNameToUI()
	{
		currentStatus cs=saveController.loadStatus();
		scoreUI[2].text=cs.playerNames[0];
		scoreUI[0].text=(instedElements[1].GetComponent<scoreContaint>().getScore()).ToString();
	}
	protected override void saveCurrentStatus()
	{
		currentStatus cs=saveController.loadStatus();

		cs.sphere[0]=instedElements[2].transform.position.x;
		cs.sphere[1]=instedElements[2].transform.position.z;
		cs.sphere[2]=instedElements[2].transform.eulerAngles.y;

		cs.paddles[1]=instedElements[1].transform.position.z;

		cs.score[1]=instedElements[1].GetComponent<scoreContaint>().getScore();

		cs.inGame=true;

		cs.pauseTime=Time.time;
		
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
			instedElements[1].transform.position=new Vector3(instedElements[1].transform.position.x,instedElements[1].transform.position.y,cs.paddles[1]);
			instedElements[1].GetComponent<scoreContaint>().setScore(cs.score[1]);
			base.startTime=cs.startTime+(Time.time-cs.pauseTime);

			updateScoreUI();
		}
		cs.inGame=false;
	}
	
	protected override void updateScoreUI()
	{
		scoreUI[0].text=(instedElements[1].GetComponent<scoreContaint>().getScore()).ToString();
	}
	protected override void computeScore(string status)
	{
		if(!(instedElements[2].GetComponent<ball>().getScoreUpdated()))
		{
			if (status=="lose")
			{
				instedElements[1].GetComponent<scoreContaint>().decScore();
			}
			if(status=="ringCatch")
			{
				instedElements[1].GetComponent<scoreContaint>().incScore();
				instedElements[1].transform.Find(ss.theme+"/redCircle").gameObject.GetComponent<redCircleActivationMnager>().activeRedCircle(Time.time);
			}
			instedElements[2].GetComponent<ball>().setScoreUpdated(true);
		}

	}
	protected override void gameReset()
	{
		scoreUI[1].enabled = true;
		//if(Input.touchCount>0)
		if(noTouchOnScreen())
		{
			if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
			{
				Destroy(instedElements[2]);
				instedElements[2]=elementsInst(gameElements[2]);
				instedElements[2].GetComponent<ball>().setRandomLook();
				instedElements[1].GetComponent<leftPaddle>().setStartPosition();
				scoreUI[1].enabled = false;
			}
		}
	}

	protected override void setUpGameOverMSGUI()
	{
		int playerScore=getPlayerScore();
		gameOverManager.GetComponent<gameOver1Player>().setupGameOverMSGUI(playerScore);
	}
	private int getPlayerScore()
	{
		return base.instedElements[1].GetComponent<scoreContaint>().getScore();
	}

}
