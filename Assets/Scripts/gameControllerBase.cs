using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class gameControllerBase : MonoBehaviour
{
	public GameObject timerManager;
	public GameObject gameOverUI;
	public GameObject gameOverManager;
    public GameObject[] gameElements;
    public GameObject pauseBtn; 

    protected GameObject[] instedElements;
    protected bool noTouchOnScreenFlag;
	protected float timeOfTimer;
	protected float startTime;
	protected settingStatus ss;


    protected virtual void Start()
    {
		ss = saveController.loadSetting();

		startTime=Time.time;

        instedElements=new GameObject[gameElements.Length];
		for(int i=0; i< gameElements.Length;i++)
		{
			instedElements[i]=elementsInst(gameElements[i]);
		}

        assignPlayerNameToUI();

        instedElements[2].GetComponent<ball>().setRandomLook();

		loadLastStatus();
    }
    protected abstract void loadLastStatus();
    protected abstract void assignPlayerNameToUI();
    protected GameObject elementsInst(GameObject gameElement)
	{
		return Instantiate(gameElement);
	}
    protected void Update()
	{

		if(pauseButtonClicked()) 
			saveCurrentStatus();

		
		if(checkRingCatch())
		{
			computeScore("ringCatch"); 
			updateScoreUI();
		}

		if(checkLose())
		{
			computeScore("lose");
			updateScoreUI();
			gameReset();
		}

		if(checkTimer())
		{
			gameOver();
		}
		else
		{
			updateTimerUI();
		}
	}

	private void updateTimerUI()
	{
		float timePass=Time.time-startTime;
		float remainingTime=timeOfTimer-timePass;
		timerManager.GetComponent<timerManager>().updateTimerUI(remainingTime);
	}
	private bool checkTimer()
	{
		float timePass=Time.time-startTime;

		if(timePass>=timeOfTimer)
		{
			return true;
		}
		return false;
	}

	private void gameOver()
	{
		showGameOverUI();
		setUpGameOverMSGUI();
		
		instedElements[2].GetComponent<ball>().setSpeed("stop");
	}
	protected abstract void setUpGameOverMSGUI();
	private void showGameOverUI()
	{
		gameOverUI.SetActive(true); 
	}

    protected bool pauseButtonClicked()
	{
		return pauseBtn.GetComponent<pauseButton>().clicked;
	}

    protected abstract void saveCurrentStatus();

    protected bool checkRingCatch()
	{
		return instedElements[2].GetComponent<ball>().getRingCatch();
	}
    protected abstract void computeScore(string status);
    protected abstract void updateScoreUI();
    protected bool checkLose()
	{
		return instedElements[2].GetComponent<ball>().getLose();		
	}
    protected abstract void gameReset();
    protected string getBallDir()
	{
		return instedElements[2].GetComponent<ball>().getBallDir();
	}
    protected bool noTouchOnScreen()
	{
		if(!noTouchOnScreenFlag)
		{
			if(Input.touchCount==0 && !(Input.GetKey(KeyCode.Space)))
			{
				noTouchOnScreenFlag=true;
			}
		}
		return noTouchOnScreenFlag;
	}
	public void saveStatus()
	{
		saveCurrentStatus();
	}
}
