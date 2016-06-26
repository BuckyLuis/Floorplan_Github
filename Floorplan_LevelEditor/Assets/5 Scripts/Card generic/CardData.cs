using UnityEngine;
using System.Collections;

public class CardData : MonoBehaviour 
{
	public int Card_ID;

	[HideInInspector] public string Title = null;
	[HideInInspector] public string Element = null;
	[HideInInspector] public string Category = null;


	[HideInInspector] public int PortraitID;

	[HideInInspector] public string StatType0 = null;
	[HideInInspector] public int StatValue0;
	[HideInInspector] public string StatType1 = null;
	[HideInInspector] public int StatValue1;
	[HideInInspector] public string StatType2 = null;
	[HideInInspector] public int StatValue2;


	[HideInInspector] public int ActionsNumber; 		

	[HideInInspector] public string Cost00 = null;
	[HideInInspector] public string Cost01 = null;
	[HideInInspector] public string Cost02 = null;
	[HideInInspector] public string Cost03 = null;
	[HideInInspector] public string ActText0 = null;
	[HideInInspector] public int ActionID0; 

	[HideInInspector] public string Cost10 = null;
	[HideInInspector] public string Cost11 = null;
	[HideInInspector] public string Cost12 = null;
	[HideInInspector] public string Cost13 = null;
	[HideInInspector] public string ActText1 = null;
	[HideInInspector] public int ActionID1;

	[HideInInspector] public string Cost20 = null;
	[HideInInspector] public string Cost21 = null;
	[HideInInspector] public string Cost22 = null;
	[HideInInspector] public string Cost23 = null;
	[HideInInspector] public string ActText2 = null;
	[HideInInspector] public int ActionID2;

	[HideInInspector] public string FlavorText = null;



	void Start()
	{
		Title = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Title;
		Element = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Element;
		Category = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Category;

		PortraitID = Card_ReadWrite.Cards_DataObject.cards[Card_ID].PortraitID;

		StatType0 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatType0;
		StatValue0 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatValue0;
		StatType1 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatType1;
		StatValue1 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatValue1;
		StatType2 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatType2;
		StatValue2 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].StatValue2;


		ActionsNumber = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActionsNumber; 		

		Cost00 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost00;
		Cost01 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost01;
		Cost02 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost02;
		Cost03 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost03;
		ActText0 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActText0;
		ActionID0 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActionID0; 

		Cost10 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost10;
		Cost11 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost11;
		Cost12 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost12;
		Cost13 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost13;
		ActText1 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActText1;
		ActionID1 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActionID1;

		Cost20 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost20;
		Cost21 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost21;
		Cost22 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost22;
		Cost23 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].Cost23;
		ActText2 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActText2;
		ActionID2 = Card_ReadWrite.Cards_DataObject.cards[Card_ID].ActionID2;

		FlavorText = Card_ReadWrite.Cards_DataObject.cards[Card_ID].FlavorText;
	}
}
