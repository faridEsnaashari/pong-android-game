using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameControllerHelp : MonoBehaviour
{
	//to containt gameObject prefabs;
	public GameObject[] gameElements;
	//to containt gameObject instans that created from gameElements;
	public GameObject[] instedElements;
	public Text[] scoreUI;
	public GameObject pauseBtn;
	public GameObject helpManager;
	private void Start()
	{
		instedElements=new GameObject[gameElements.Length];
		for(int i=0; i< gameElements.Length;i++)
		{
			instedElements[i]=elementsInst(gameElements[i]);
		}

		scoreUI[0].text=(instedElements[1].GetComponent<scoreContaint>().getScore()).ToString();
		instedElements[2].GetComponent<ball>().setRandomLook();
		
	}
	private void Update()
	{
		if(pauseBtn.GetComponent<pauseButton>().clicked)
		{
			Application.LoadLevel("mainMenu");
		}
		string helpTurn=helpManager.GetComponent<firstHelpShow>().getTurn();
		if(checkRingCatch())
		{
			if(helpTurn!="welcom" && helpTurn!="paddleMove" && helpTurn!="reflect")
			{
				computeScore("ringCatch");
				updateScoreUI();
			}
		}

		if(checkLose())
		{
			if(helpTurn!="welcom" && helpTurn!="paddleMove" && helpTurn!="reflect" && helpTurn!="ringAndScore")
			{
				computeScore("lose");
				updateScoreUI();

				scoreUI[1].text="touch to reset!!!";
				if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
				{
					gameReset();
				}
			}
		}
	}
	private void updateScoreUI()
	{
		// currentStatus cs=saveController.loadStatus();
		scoreUI[0].text=(instedElements[1].GetComponent<scoreContaint>().getScore()).ToString();
	}
	private void computeScore(string status)
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
				instedElements[1].transform.Find("").gameObject.GetComponent<redCircleActivationMnager>().activeRedCircle(Time.time);
			}
			instedElements[2].GetComponent<ball>().setScoreUpdated(true);
		}
		// if (scoreInc)
		// {
		// 	if (instedElements[2].GetComponent<ball>().getIndex()==-1)
		// 	{
		// 		instedElements[0].GetComponent<scoreContaint>().incScore();
		// 	}
		// 	else
		// 	{
		// 		instedElements[1].GetComponent<scoreContaint>().incScore();
		// 	}
		// 	scoreInc=false;
		// }
	}
	public void gameReset()
	{
		Destroy(instedElements[2]);
		instedElements[2]=elementsInst(gameElements[2]);
		instedElements[2].GetComponent<ball>().setRandomLook();
		instedElements[1].GetComponent<leftPaddle>().setStartPosition();
		scoreUI[1].text="";
		helpManager.GetComponent<firstHelpShow>().elements[0]=instedElements[2];
	}
	private bool checkLose()
	{
		return instedElements[2].GetComponent<ball>().getLose();		
	}
	private bool checkRingCatch()
	{
		return instedElements[2].GetComponent<ball>().getRingCatch();		
	}
	private GameObject elementsInst(GameObject gameElement)
	{
		return Instantiate(gameElement);
	}



	public GameObject getElement(string orderedElement)
	{
		if(orderedElement=="ball")
		{
			return instedElements[2];
		}
		if(orderedElement=="leftPaddle")
		{
			return instedElements[1];
		}
		return instedElements[1];
	}
		
}
