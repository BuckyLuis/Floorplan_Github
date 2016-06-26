using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Card_Base 
{
	private Elements eElements;
	private Categories eCategories;
	private StatTypes eStatType;



	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

	[XmlElement("Title")]			public string Title {get; set;}
	[XmlElement("Element")]			public string Element {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Category")]		public string Category {get {return eCategories.ToString();}  set {eCategories = (Categories)Enum.Parse(typeof(Categories),value);} }

	[XmlElement("PortraitID")]		public int PortraitID {get; set;}

//-----------------------------------------------------------------------------------------

	[XmlElement("StatType0")]		public string StatType0 {get {return eStatType.ToString();}  set {eStatType = (StatTypes)Enum.Parse(typeof(StatTypes),value);} }
	[XmlElement("StatValue0")]		public int StatValue0 {get; set;}

	[XmlElement("StatType1")]		public string StatType1 {get {return eStatType.ToString();}  set {eStatType = (StatTypes)Enum.Parse(typeof(StatTypes),value);} }
	[XmlElement("StatValue1")]		public int StatValue1 {get; set;}

	[XmlElement("StatType2")]		public string StatType2 {get {return eStatType.ToString();}  set {eStatType = (StatTypes)Enum.Parse(typeof(StatTypes),value);} }
	[XmlElement("StatValue2")]		public int StatValue2 {get; set;}

//-----------------------------------------------------------------------------------------

	[XmlElement("ActionsNumber")]	public int ActionsNumber {get; set;}

	[XmlElement("Cost00")]			public string Cost00 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost01")]			public string Cost01 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost02")]			public string Cost02 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost03")]			public string Cost03 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("ActText0")]		public string ActText0 {get; set;}
	[XmlElement("ActionID0")]		public int ActionID0 {get; set;}

	[XmlElement("Cost10")]			public string Cost10 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost11")]			public string Cost11 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost12")]			public string Cost12 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost13")]			public string Cost13 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("ActText1")]		public string ActText1 {get; set;}
	[XmlElement("ActionID1")]		public int ActionID1 {get; set;}

	[XmlElement("Cost20")]			public string Cost20 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost21")]			public string Cost21 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost22")]			public string Cost22 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("Cost23")]			public string Cost23 {get {return eElements.ToString();}  set {eElements = (Elements)Enum.Parse(typeof(Elements),value);} }
	[XmlElement("ActText2")]		public string ActText2 {get; set;}
	[XmlElement("ActionID2")]		public int ActionID2 {get; set;}

	[XmlElement("FlavorText")]		public string FlavorText {get; set;}

}



public enum Elements
{
	Z,		//zero, none
	F,		//fire
	A,		//air
	W,		//water
	E,		//earth
	S,		//spirit
	N		//neutral
}

public enum Categories
{
	MANA,
	RESO,
	SPEL,
	TOOL,
	STRU,
	MONS
}

public enum StatTypes
{
	ATK,
	DEF,
	RNG,
	AMMO
}


