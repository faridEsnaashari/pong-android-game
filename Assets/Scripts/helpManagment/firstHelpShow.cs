using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstHelpShow : MonoBehaviour
{
    public GameObject gameController;
    public GameObject[] elements;
    public GameObject[] helpUI;

//  turn flags////////////////////////////
    private bool welcomeFinishFlag;
    private bool paddleMoveFinishFlag;
    private bool reflectFinishFlag;
    private bool ringAndScoreFinishFlag;
    private bool loseAndScoreFinishFlag;

    private bool welcomeStartFlag=true;
    private bool paddleMoveStartFlag;
    private bool reflectStartFlag;
    private bool ringAndScoreStartFlag;
    private bool loseAndScoreStartFlag;
    private bool finishStartFlag;
// //////////////////////////////////////////

//  for paddleMove////////////////////////
    private bool top=false;
    private bool button=false;
// ///////////////////////////////////////////

//  for reflect////////////////////////////
    private bool flatColliderTrigged=false;
    private bool wallTrigged=false;
// ///////////////////////////////////////////

    private Touch touch;

    private void Start()
    {
        elements=new GameObject[2];
        elements[0]=gameController.GetComponent<gameControllerHelp>().getElement("ball");
        elements[1]=gameController.GetComponent<gameControllerHelp>().getElement("leftPaddle");
    }
    private void Update()
    {
        string helpTurn=helpTurnGenerator();
        bool permision=getPermisionToStartTurn(helpTurn);
        Debug.Log(permision);

        if(helpTurn=="welcome" && permision)
        {
            showWelcome();
        }
        if(helpTurn=="paddleMove" && permision)
        {
            showPaddleMove();
        }
        if(helpTurn=="reflect" && permision)
        {
            showReflect();
        }
        if(helpTurn=="ringAndScore" && permision)
        {
            showRingAndScore();
        }
        if(helpTurn=="loseAndScore" && permision)
        {
            showLoseAndScore();
        }
        if(helpTurn=="finish" && permision)
        {
            finish();
        }
    }


    private bool getPermisionToStartTurn(string helpTurn)
    {
        if(Input.touchCount==0 && !(Input.GetKey(KeyCode.Space)))
        {
            return true;
        }
        return false;
        // if(helpTurn=="welcome")
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         welcomeStartFlag=true;
        //     }
        //     return welcomeStartFlag;
        // }
        // else if(helpTurn=="paddleMove")
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         paddleMoveStartFlag=true;
        //     }
        //     return paddleMoveStartFlag;
        // }
        // else if(helpTurn=="reflect")
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         reflectStartFlag=true;
        //     }
        //     return reflectStartFlag;
        // }
        // else if(helpTurn=="ringAndScore")
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         ringAndScoreStartFlag=true;
        //     }
        //     return ringAndScoreStartFlag;
        // }
        // else if(helpTurn=="loseAndScore")
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         loseAndScoreStartFlag=true;
        //     }
        //     return loseAndScoreStartFlag;
        // }
        // else
        // {
        //     if(Input.touchCount==0 || Input.GetKey(KeyCode.Space))
        //     {
        //         finishStartFlag=true;
        //     }
        //     return finishStartFlag;
        // }
    }

    private string helpTurnGenerator()
    {
        if(!welcomeFinishFlag && !paddleMoveFinishFlag && !reflectFinishFlag && !ringAndScoreFinishFlag && !loseAndScoreFinishFlag)
        {
            return "welcome";
        }
        if(welcomeFinishFlag && !paddleMoveFinishFlag && !reflectFinishFlag && !ringAndScoreFinishFlag && !loseAndScoreFinishFlag)
        {
            return "paddleMove";
        }
        if(welcomeFinishFlag && paddleMoveFinishFlag && !reflectFinishFlag && !ringAndScoreFinishFlag && !loseAndScoreFinishFlag)
        {
            return "reflect";
        }
        if(welcomeFinishFlag && paddleMoveFinishFlag && reflectFinishFlag && !ringAndScoreFinishFlag)
        {
            return "ringAndScore";
        }
        if(welcomeFinishFlag && paddleMoveFinishFlag && reflectFinishFlag && ringAndScoreFinishFlag && !loseAndScoreFinishFlag)
        {
            return "loseAndScore";
        }
        if(welcomeFinishFlag && paddleMoveFinishFlag && reflectFinishFlag && ringAndScoreFinishFlag && loseAndScoreFinishFlag)
        {
            return "finish";
        }
        return "";
    }

    private void showWelcome()
    {
        helpUIManager("showWelcome");

        elements[0].GetComponent<ball>().setSpeed("stop");
        elements[1].GetComponent<leftPaddle>().lcokMovement(true);

        if(Input.GetKey(KeyCode.S)||Input.touchCount>0)
        {
            helpUIManager("hideWelcome");
            helpUIManager("showPaddleMove");
            welcomeFinishFlag=true;
        }
    }

    private void showPaddleMove()
    {
        //paddleMove's UI active in last Turn...  sorry for that  :'(
        elements[1].GetComponent<leftPaddle>().lcokMovement(false);
        if(Input.GetKey(KeyCode.S)||Input.touchCount>0)
        {
            helpUIManager("hidePaddleMove");
        }
        if((didPaddleMoved() || Input.GetKey(KeyCode.Space)))
        {
            helpUIManager("hidePaddleMove");
            helpUIManager("showReflect");
            gameController.GetComponent<gameControllerHelp>().gameReset();
            elements[0].GetComponent<ball>().setSpeed("stop");
            elements[1].GetComponent<leftPaddle>().lcokMovement(true);
            paddleMoveFinishFlag=true;
        }
    }

    private void showReflect()
    {
        //reflect's UI active in last Turn...  sorry for that  :'(

        if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
        {
            helpUIManager("hideReflect");
            elements[1].GetComponent<leftPaddle>().lcokMovement(false);
            elements[0].GetComponent<ball>().setSpeed("normal");
        }
       
        if(elements[0].GetComponent<ball>().getTrrigedObject()=="lose")
        {
            flatColliderTrigged=false;
            wallTrigged=false;
            helpUIManager("showReflect");
            gameController.GetComponent<gameControllerHelp>().gameReset();
            elements[1].GetComponent<leftPaddle>().lcokMovement(true);
            elements[0].GetComponent<ball>().setSpeed("stop");
        }
        
        
        if(didFlatAndwallReflected())
        {
            helpUIManager("hideReflect");
            gameController.GetComponent<gameControllerHelp>().gameReset();
            elements[1].GetComponent<leftPaddle>().lcokMovement(true);
            elements[0].GetComponent<ball>().setSpeed("stop");
            helpUIManager("showRingAndScore");
            elements[1].transform.Find("redCircle").gameObject.GetComponent<redCircleActivationMnager>().initActiveRedCircle(Time.time);
            reflectFinishFlag=true;
        }
    }

    private void showRingAndScore()
    {
        //ringAndScore's UI active in last Turn...  sorry for that  :'(
        if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
        {
            elements[1].GetComponent<leftPaddle>().lcokMovement(false);
            helpUIManager("hideRingAndScore");
            elements[0].GetComponent<ball>().setSpeed("normal");
        }

        if(elements[0].GetComponent<ball>().getTrrigedObject()=="lose")
        {
            helpUIManager("showRingAndScore");
            gameController.GetComponent<gameControllerHelp>().gameReset();
            elements[1].GetComponent<leftPaddle>().lcokMovement(true);
            elements[0].GetComponent<ball>().setSpeed("stop");
            elements[1].transform.Find("redCircle").gameObject.GetComponent<redCircleActivationMnager>().initActiveRedCircle(Time.time);
        }

        if(didRingTrigged())
        {
            helpUIManager("hideRingAndScore");
            gameController.GetComponent<gameControllerHelp>().gameReset();
            elements[0].GetComponent<ball>().setSpeed("stop");
            helpUIManager("showLoseAndScore");
            ringAndScoreFinishFlag=true;
        }
      }

    private void showLoseAndScore()
    {
        //loseAndScore's UI active in last Turn...  sorry for that  :'(
        if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
        {
            helpUIManager("showFinish");
            helpUIManager("hideLoseAndScore");
            loseAndScoreFinishFlag=true;
        }
    }

    private void finish()
    {
        if(Input.GetKey(KeyCode.Space)||Input.touchCount>0)
        {
            helpUIManager("hideEverything");
            elements[0].GetComponent<ball>().setSpeed("normal");
        }
    }


    private void helpUIManager(string helpTurn)
    {
        switch (helpTurn)
        {
            case "showWelcome":
                helpUI[0].SetActive(true);
                break;

            case "hideWelcome":
                helpUI[0].SetActive(false);
                break;

            case "showPaddleMove":
                helpUI[1].SetActive(true);
                break;
              
            case "hidePaddleMove":
                helpUI[1].SetActive(false);
                break;
            
            case "showReflect":
                helpUI[2].SetActive(true);
                break;

            case "hideReflect":
                helpUI[2].SetActive(false);
                break;

            case "showRingAndScore":
                helpUI[3].SetActive(true);
                break;

            case "hideRingAndScore":
                helpUI[3].SetActive(false);
                break;

            case "showLoseAndScore":
                helpUI[4].SetActive(true);
                break;
        
            case "hideLoseAndScore":
                helpUI[4].SetActive(false);
                break;

            case "showFinish":
                helpUI[5].SetActive(true);
                break;

            case "hideFinish":
                helpUI[5].SetActive(false);
                break;
        }
        // if(helpTurn=="showWelcome")
        // {
        //     helpUI[0].SetActive(true);
        // }
        // if(helpTurn=="hideWelcome")
        // {
        //     helpUI[0].SetActive(false);
        // }
        // if(helpTurn=="showPaddleMove")
        // {
        //     helpUI[1].SetActive(true);
        // }
        // if(helpTurn=="hidePaddleMove")
        // {
        //     helpUI[1].SetActive(false);
        // }
        // if(helpTurn=="showReflect")
        // {
        //     helpUI[2].SetActive(true);
        // }
        // if(helpTurn=="hideReflect")
        // {
        //     helpUI[2].SetActive(false);
        // }
        // if(helpTurn=="showRingAndScore")
        // {
        //     helpUI[3].SetActive(true);
        // }
        // if(helpTurn=="hideRingAndScore")
        // {
        //     helpUI[3].SetActive(false);
        // }
        // if(helpTurn=="showLoseAndScore")
        // {
        //     helpUI[4].SetActive(true);
        // }
        // if(helpTurn=="hideLoseAndScore")
        // {
        //     helpUI[4].SetActive(false);
        // }
        // if(helpTurn=="showFinish")
        // {
        //     helpUI[5].SetActive(true);
        // }
        // if(helpTurn=="hideEverything")
        // {
        //     helpUI[5].SetActive(false);
        // }
    }

    private bool didPaddleMoved()
    {
        if(elements[1].transform.position.z>6)
        {
            top=true;
        }
        if(elements[1].transform.position.z<-6)
        {
            button=true;
        }
        if(top && button)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool didFlatAndwallReflected()
    {
         if(elements[0].GetComponent<ball>().getTrrigedObject()=="flatCollider")
        {
            flatColliderTrigged=true;
        }
        if(elements[0].GetComponent<ball>().getTrrigedObject()=="rightWall")
        {
            wallTrigged=true;
        }
        if(flatColliderTrigged && wallTrigged)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool didRingTrigged()
    {
        if(elements[0].GetComponent<ball>().getTrrigedObject()=="leftRingCollider")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public string getTurn()
    {
        return helpTurnGenerator();
    }
}
