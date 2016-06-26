using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveUIElement : MonoBehaviour 
{
	RectTransform myRectTrans;

	public float staticYpos = 20f;
	public float newXpos;

	void Start ()
	{
		myRectTrans = this.gameObject.GetComponent<RectTransform>();
	}
	

	void Update () 
	{
	
	}

	void Move()
	{
		myRectTrans.anchoredPosition = new Vector2(newXpos, staticYpos);
	}
}
