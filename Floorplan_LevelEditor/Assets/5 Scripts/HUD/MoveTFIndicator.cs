using UnityEngine;
using System.Collections;

public class MoveTFIndicator : MonoBehaviour 
{
	RectTransform myRectTrans;

	public float staticYpos = 20f;
	public float newXpos;

	float currentXpos;
	bool moveToRight = true;

	public float minXpos = -208f;
	public float maxXpos = -7f;

	void Start ()
	{
		myRectTrans = this.gameObject.GetComponent<RectTransform>();
	}


	void Update () 
	{

	}

	public void MovePos()
	{
		if(currentXpos <= minXpos || currentXpos >= maxXpos)
		{
			moveToRight = !moveToRight;
		}

		if(moveToRight)
		{
			myRectTrans.anchoredPosition = new Vector2(currentXpos + 1f * Time.deltaTime, staticYpos);
			currentXpos = currentXpos + 1f;
		}
		else if(!moveToRight)
		{
			myRectTrans.anchoredPosition = new Vector2(currentXpos - 1f * Time.deltaTime, staticYpos);
			currentXpos = currentXpos - 1f;
		}
	}

	public void ResetPos()
	{
		myRectTrans.anchoredPosition = new Vector2(minXpos, staticYpos);
		currentXpos = minXpos + 0.1f;
		moveToRight = true;
	}
}
