using UnityEngine;
using System.Collections;

public class CardProjMovement : MonoBehaviour 
{
	public bool isFlying = false;

	public int rotSpeed;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(isFlying)
			transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
	}


	void OnCollisionEnter()
	{
		isFlying = false;
	}
}
