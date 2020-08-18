using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftPaddle : MonoBehaviour 
{
	private Touch touch;
	private Touch[] leftSideTouch;
	private Vector3 touchPosition;
	private bool moveLock;
	private void Start()
	{
		leftSideTouch=new Touch[20];
	}
	void Update()
	{
		getTouch();
		move();
	}	
	
	// private bool upSectionTouchedCheck()
	// {
		
	// 	for(int i=0; i<touch.Length; i++)
	// 	{
	// 		Vector3 far=touch[i].position;
	// 		far.z=Camera.main.farClipPlane;
	// 		Vector3 near=touch[i].position;
	// 		near.z=Camera.main.nearClipPlane;

	// 		far=Camera.main.ScreenToWorldPoint(far);
	// 		near=Camera.main.ScreenToWorldPoint(near);

	// 		Vector3 touchInWorld=far-near;

	// 		if(touchInWorld.x<-13&&touchInWorld.z>-233)
	// 			return true;
	// 	}
	// 	return false;
	//  }
	// private bool downSectionTouchedCheck()
	// {
	// 	for(int i=0; i<touch.Length; i++)
	// 	{
			
	// 		Vector3 far=touch[i].position;
	// 		far.z=Camera.main.farClipPlane;
	// 		Vector3 near=touch[i].position;
	// 		near.z=Camera.main.nearClipPlane;

	// 		far=Camera.main.ScreenToWorldPoint(far);
	// 		near=Camera.main.ScreenToWorldPoint(near);

	// 		Vector3 touchInWorld=far-near;

	// 		if(touchInWorld.x<-13&&touchInWorld.z<-233)
	// 			return true;
	// 	}
	// 	return false;
	// }
	private void getTouch()
	{
		if(leftSideTouchesCount()>0)
		{
			touch=leftSideTouch[0];
		}
	}

	private int leftSideTouchesCount()
	{
		int touchCount=0;
		for(int i=0 , j=0 ; i<Input.touchCount ; i++)
		{
			Touch currentTouch=Input.GetTouch(i);
			Vector3 currentTouchPosition=currentTouch.position;
			currentTouchPosition.z=21;
			currentTouchPosition=Camera.main.ScreenToWorldPoint(currentTouchPosition);

			if(currentTouchPosition.x<-7)
			{
				touchCount++;
				leftSideTouch[j]=currentTouch;
				j++;
			}
		}
		return touchCount;
	}
	// public void incScore()
	// {
	// 	score++;
	// }
	// public int getScore()
	// {
	// 	return score;
	// }
	public void setStartPosition()
	{
		transform.position=new Vector3(transform.position.x,transform.position.y,0);
	}
	private Vector3 getTouchPosition()
	{
		if(leftSideTouchesCount()>0)
		{
			touchPosition=touch.position;
			//touchPosition=Input.mousePosition;
			touchPosition.z=21;
			touchPosition=Camera.main.ScreenToWorldPoint(touchPosition);
		}
		else
		{
			touchPosition.z=transform.position.z;
		}

		touchPosition.x=transform.position.x;
		touchPosition.y=transform.position.y;

		return touchPosition;
	}
	private void move()
	{
		touchPosition=getTouchPosition();
		if(touchPosition.z<9.6 && touchPosition.z>-9.6 && !moveLock)	
		{
			transform.position=touchPosition;
		}
		else
		{
			if(touchPosition.z>=9.6)
			{
				transform.position=new Vector3(transform.position.x,transform.position.y,9.6f);
			}
			if(touchPosition.z<=-9.6)
			{
				transform.position=new Vector3(transform.position.x,transform.position.y,-9.5f);
			}
		}
	    // bool up=upSectionTouchedCheck();
		// bool down=downSectionTouchedCheck();
		// if(transform.position.z<9.6)
		// {
		// 	if(Input.GetKey(KeyCode.W))
		// 	//if(Input.GetKey(KeyCode.W))
		// 	{
		// 		transform.Translate(0,0,moveSpeed);
		// 	}
		// 	//transform.position=touchPosition;
	    // }
		// else
		// {
		// 	transform.position=new Vector3(transform.position.x,transform.position.y,9.7f);
		// }






		// if(transform.position.z>-9.6)
		// {
		// 	if(Input.GetKey(KeyCode.S))
		// 	//if(Input.GetKey(KeyCode.S))
		// 	{
		// 		transform.Translate(0,0,-moveSpeed);
		// 	}
		// 	//transform.position=touchPosition;
		// }
		// else
		// {
		// 	transform.position=new Vector3(transform.position.x,transform.position.y,-9.7f);
		// }
	}

	public void lcokMovement(bool mvlock)
	{
		moveLock=mvlock;
	}
}
