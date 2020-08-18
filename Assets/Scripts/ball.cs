using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
	public AudioClip flatPaddleAndWallAudio;
	public AudioClip loseAudio;
	public AudioClip ringAudio;
	public Animation ballSpin;
	private string dir;
	private bool lose;
	private bool scoreUpdated;
	private bool ringCatch;
	private float moveSpeed=.2f; 
	private float increaseTime=2f;
	private bool ballMoving;
	private AudioSource audio;
	private string speedStatus;
	private string triggedObject;
	private Animation ballScale;
	
	private void Start()
	{
		audio=GetComponent<AudioSource>();
		ballScale=this.GetComponent<Animation>();
	}
	private void Update()
	{
		if(getMovePermision())
		{
			move();
			increaseMoveSpeed();
		}
	}
	private bool getMovePermision()
	{
		if(!ballMoving)
		{
			if((Input.touches.Length>0||Input.GetMouseButtonDown(0)) && (speedStatus!="stop"))
			{
				ballMoving=true;
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(speedStatus=="stop")
		{
			return false;
		}
		else
		{
			return true;
		}

	}
	void OnTriggerEnter(Collider other)
	{
		checkLose(other);
		checkRingCatch(other);
		rotateBall(other);
		hitSoundPlayer(other);
		triggedObject=getTriggedObject(other);
	}
	private string getTriggedObject(Collider other)
	{
		return (other.transform.tag).ToString();
	}
	private void move()
	{
		transform.Translate(moveSpeed,0,0);
	}
	private void increaseMoveSpeed()
	{
		if(Time.time>increaseTime)
		{
			increaseTime=Time.time+1;
			moveSpeed+=.03f;
		}
	}
	public string getDir()
	{
		if(transform.position.x>0)
		{
			return "right";
		}
		else
		{
			return "left";
		}
	}
	public void checkRingCatch(Collider other)
	{
		if(other.gameObject.transform.name=="ringCollider")
		{
			ringCatch=true;
			scoreUpdated=false;
			dir=getDir();
			lose=false;
		}
	}
	public void checkLose(Collider other)
	{
		if(other.gameObject.transform.tag=="lose")
		{
			lose=true;
			scoreUpdated=false;
			dir=getDir();
			ringCatch=false;
		}
	}
	
	void rotateBall(Collider other)
	{
		float YDegree=transform.eulerAngles.y;

		if(other.gameObject.transform.tag=="border")
		{
			ballScale.Play();
			YDegree=transform.eulerAngles.y*-1;
		}

		else if(other.gameObject.transform.tag=="flatCollider")
		{
			ballScale.Play();
			YDegree=180-transform.eulerAngles.y;
		}

		else if(other.gameObject.transform.tag=="rightWall")
		{
			ballScale.Play();
			YDegree=180-transform.eulerAngles.y;
		}

		else if(other.gameObject.transform.tag=="rightRingCollider")
		{
			YDegree=Random.Range(140,220);
		}
		else if(other.gameObject.transform.tag=="leftRingCollider")
		{
			YDegree=Random.Range(-40,40);
		}
		transform.eulerAngles=new Vector3(0,YDegree,0);
	}
	public void setRandomLook()
	{
		float Ydegree;
		int random=(int)(Mathf.Round(Random.Range(0,2)));
		if(random==0)
		{
			Ydegree=Random.Range(-40,40);
		}
		else
		{
			Ydegree=Random.Range(140,220);
		}
		transform.eulerAngles=new Vector3(0,Ydegree,0);
	}
	public bool getLose()
	{
		return lose;
	}
	public bool getRingCatch()
	{
		return ringCatch;
	}
	public bool getScoreUpdated()
	{
		return scoreUpdated;
	}
	public void setScoreUpdated(bool b)
	{
		scoreUpdated=b;
	}
	public string getBallDir()
	{
		return dir;
	}
	private void hitSoundPlayer(Collider other)
	{
		audio.clip=null;
		switch (other.gameObject.name)
		{
			case "flatCollider":
				audio.clip=flatPaddleAndWallAudio;
				break;

			case "rightWall(Clone)":
				audio.clip=flatPaddleAndWallAudio;
				break;

			case "ringCollider":
				audio.clip=ringAudio;
				break;

			// case "downBorder":
			// 	audio.clip=flatPaddleAndWallAudio;
			// 	break;
			
			// case "upBorder":
			// 	audio.clip=flatPaddleAndWallAudio;
			// 	break;

			case "rightLose":
				audio.clip=loseAudio;
				break;
		
			case "leftLose":
				audio.clip=loseAudio;
				break;		
		}
		audio.Play(0);
		
	}

	public void setSpeed(string set)
	{
		if(set=="normal")
		{
			moveSpeed=.3f;
			speedStatus="normal";

			ballSpin.Play();
		}
		if(set=="stop")
		{
			moveSpeed=0;
			speedStatus="stop";

			ballSpin.Stop();
		}
	}

	public string getTrrigedObject()
	{
		return triggedObject; 
	}
}
