using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Room_Base 
{
	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)
   
    [XmlElement("RoomID")]          public int RoomID {get; set;}
    [XmlElement("RoomAreaIndex")]   public int RoomAreaIndex {get; set;}
    [XmlElement("RoomName")]        public string RoomName { get; set; }
    [XmlElement("RoomColor")]       public Color RoomColor { get; set; }


    public Vector3 CamBoundsTLPos;
    //[XmlAttribute("CamBoundsTLPos")]     public string CamBoundsTL_Surrogate{ get { return "";}
                                                                              //set { CamBoundsTLPos = new Vector3().FromString(value); }}
    public Vector3 CamBoundsBRPos;
    //[XmlAttribute("CamBoundsBRPos")]     public string CamBoundsBR_Surrogate{ get { return "";}
                                                                             // set { CamBoundsBRPos = new Vector3().FromString(value); }}
   
    [XmlArray("Tiles")]
    [XmlArrayItem("Tile")]
    public List<Geom_Base> tilesOfRoom = new List<Geom_Base>();


   
}

