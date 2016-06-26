using UnityEngine;
using System.Collections;
using TeamUtility.IO;

public class PlayerThrowCard : MonoBehaviour 
{
	public GameObject cardToThrow;
	Rigidbody cardsRB;

	public GameObject throwForceIndicatorGO;
	MoveTFIndicator tfIndicatorScript;

	public float throwForce = 1.0f;
//	public float throwTorque = 1000.0f;
	float minThrowForce = 0.0f;
	float maxThrowForce = 100.0f;

	public bool spawnCardNow = false;



	void Start () 
	{
		tfIndicatorScript = throwForceIndicatorGO.GetComponent<MoveTFIndicator>();
	}

	void Update ()
	{
		if(spawnCardNow)
		{
			cardsRB = cardToThrow.GetComponent<Rigidbody>();
			cardsRB.GetComponent<CardProjMovement>().isFlying = true;
			Rigidbody card = Instantiate(cardsRB, transform.position, transform.rotation) as Rigidbody;
			card.AddForce((transform.forward + (transform.up * 0.2f)).normalized * throwForce); 
			spawnCardNow = false;
		}

/*
		if(InputManager.GetButtonDown("Mouse0"))
		{
			tfIndicatorScript.MovePos();
		}
		if(InputManager.GetButtonUp("Mouse0"))
		{
			tfIndicatorScript.ResetPos();
			cardsRB = cardToThrow.GetComponent<Rigidbody>();
			Rigidbody card = Instantiate(cardsRB, transform.position, transform.rotation) as Rigidbody;
			card.AddForce((transform.forward + (transform.up * 0.2f)).normalized * throwForce);  //+ transform.up).normalized 
		//	card.AddTorque(transform.up * throwTorque, ForceMode.Impulse);
			//get force of player's movement, add to cards throwForce
		}
*/
	}

}


























































