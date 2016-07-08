using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Tile_Base 
{
	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("RoomID")]          public int RoomID {get; set;}

    [XmlIgnore] public Vector3 Position;
    [XmlAttribute("Position")]      public string Pos_Surrogate{ get { return "";}
                                                                      set { Position = new Vector3().FromString(value); }}

    [XmlElement("FloorIndex")]		public int FloorIndex {get; set;}
    [XmlElement("WallsIndex")]	    public int WallsIndex {get; set;}
    [XmlElement("WOrientFlag")]     public int WOrientFlag {get; set;}
}



