using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Room_Base 
{
	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)
   
    [XmlElement("RoomID")]          public int RoomID {get; set;}
    [XmlElement("RoomName")]        public string RoomName { get; set; }
    [XmlElement("RoomColor")]       public Color RoomColor { get; set; }


    [XmlIgnore] public Vector3 OriginPos;
    [XmlAttribute("OriginPos")]     public string OriginPos_Surrogate{ get { return "";}
                                                                       set { OriginPos = new Vector3().FromString(value); }}
   
    [XmlArray("Tiles")]
    [XmlArrayItem("Tile")]
    public List<Tile_Base> tilesOfRoom = new List<Tile_Base>();



   
}

