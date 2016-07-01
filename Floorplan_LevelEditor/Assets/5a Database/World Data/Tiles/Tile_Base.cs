using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Tile_Base 
{
	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("RoomID")]          public int RoomID {get; set;}

    [XmlIgnore] public Vector3 Position;
    [XmlAttribute("Position")]      public string OriginPos_Surrogate{ get { return "";}
                                                                      set { Position = new Vector3().FromString(value); }}

    [XmlElement("FloorName")]		public string FloorName {get; set;}
    [XmlElement("WallsName")]	    public string WallsName {get; set;}
    [XmlElement("WOrientFlag")]     public int WOrientFlag {get; set;}


    //private Elements eElements;           //how to make enum work with XML 
}

//  public string Category {get {return eCategories.ToString();}  set {eCategories = (Categories)Enum.Parse(typeof(Categories),value);} }

/*public enum Elements
{
	Z,		//zero, none
	F,		//fire
	A,		//air
	W,		//water
	E,		//earth
	S,		//spirit
	N		//neutral
}*/



