using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPaddle : MonoBehaviour
{
    public GameObject rightRingForTopPositionOfPaddle;
    public GameObject leftRingForTopPositionOfPaddle;
    public GameObject rightRingForBottomPositionOfPaddle;
    public GameObject leftRingForBottomPositionOfPaddle;
    public GameObject rightLose;
    public GameObject leftLose;
    public GameObject move;
    private GameObject leftPaddle;
    private GameObject rightPaddle;
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void activeHelpUI()
    {
        currentStatus cs=new currentStatus();

        if(cs.sceneName=="1player1device")
        {
            leftPaddle=GameObject.Find("leftPaddle(Clone)");
            if(leftPaddle.transform.position.z<=0)
            {
                leftRingForBottomPositionOfPaddle.SetActive(true);
            }
            else
            {
                leftRingForTopPositionOfPaddle.SetActive(true);
            }
            leftLose.SetActive(true);
            move.SetActive(true);
        }
        else if(cs.sceneName=="2player1device")
        {
            leftPaddle=GameObject.Find("leftPaddle(Clone)");
            rightPaddle=GameObject.Find("rightPaddle(Clone)");

            if(leftPaddle.transform.position.z<=0)
            {
                leftRingForBottomPositionOfPaddle.SetActive(true);
            }
            else
            {
                leftRingForTopPositionOfPaddle.SetActive(true);
            }

            if(rightPaddle.transform.position.z<=0)
            {
                rightRingForBottomPositionOfPaddle.SetActive(true);
            }
            else
            {
                rightRingForTopPositionOfPaddle.SetActive(true);
            }
            leftLose.SetActive(true);
            rightLose.SetActive(true);
            move.SetActive(true);
        }
    }
}
