using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TeamUtility.IO;

public class ArmAnimController : MonoBehaviour 
{
	//Player 1's CardCounter ... stackFlags
	//----===-----===----
	public static List<int> p1_CardCounter = new List<int>();
	//----===-----===----


	public GameObject throwCardObject;
	private PlayerThrowCard throwCardScript;

	private Animator anim;
	[HideInInspector] public int throwCard_Hash;
	[HideInInspector] public int getCardFromHand_Hash;
	[HideInInspector] public int askForCard_Hash;
	[HideInInspector] public int cardCatch_Hash;
	[HideInInspector] public int cardFailToCatch_Hash;
	[HideInInspector] public int CLOSER_Hash;

	private int cardEquipped_State = 1;
	private int numCardsInHand = 0;


	void Awake ()
	{
		throwCard_Hash = Animator.StringToHash ("ThrowCard");
		getCardFromHand_Hash = Animator.StringToHash ("GetCardFromHand");
		askForCard_Hash = Animator.StringToHash ("AskForCard");
		cardCatch_Hash = Animator.StringToHash ("CardCatch");
		cardFailToCatch_Hash = Animator.StringToHash ("CardFailToCatch");
		CLOSER_Hash = Animator.StringToHash ("CLOSER");
	}
	void Start () 
	{
		throwCardScript = throwCardObject.GetComponent<PlayerThrowCard>();
		anim = GetComponent<Animator>();
	//	anim.SetTrigger (CLOSER_Hash);
	}
	

	void Update ()
	{
		if(InputManager.GetButtonDown("1") && cardEquipped_State != 1)
		{
			cardEquipped_State = 1;
		}
		if(InputManager.GetButtonDown("2") && cardEquipped_State != 2)
		{
			cardEquipped_State = 2;
		}
		if(InputManager.GetButtonDown("3") && cardEquipped_State != 3)
		{
			cardEquipped_State = 3;
		}
		if(InputManager.GetButtonDown("4") && cardEquipped_State != 4)
		{
			cardEquipped_State = 4;
		}
		if(InputManager.GetButtonDown("5") && cardEquipped_State != 5)
		{
			cardEquipped_State = 5;
		}
		if(InputManager.GetButtonDown("6") && cardEquipped_State != 6)
		{
			cardEquipped_State = 6;
		}
		if(InputManager.GetButtonDown("7") && cardEquipped_State != 7)
		{
			cardEquipped_State = 7;
		}


		if(InputManager.GetButtonDown("Mouse0")) // && cardEquipped_State != 0
		{
			anim.SetTrigger (throwCard_Hash);	
	//		cardEquipped_State = 0;
		}


		if(InputManager.GetButtonDown("Action") && numCardsInHand < 5)
		{
			
		}
	}

	void ChangeHeldCard ()
	{
		switch (cardEquipped_State) 
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		default:
			break;
		}
	}

	void SpawnCard()
	{
		throwCardScript.spawnCardNow = true;								
		p1_CardCounter[0] = 0;
	}
}
