using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Room_Base 
{
//	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)
   
    [XmlElement("RoomID")]          public string RoomID {get; set;}
    [XmlElement("RoomAreaIndex")]   public int RoomAreaIndex {get; set;}
    [XmlElement("RoomName")]        public string RoomName { get; set; }
    [XmlElement("RoomColor")]       public Color RoomColor { get; set; }


    public Vector3 CamBoundsTLPos;
    //[XmlAttribute("CamBoundsTLPos")]     public string CamBoundsTL_Surrogate{ get { return "";}
                                                                              //set { CamBoundsTLPos = new Vector3().FromString(value); }}
    public Vector3 CamBoundsBRPos;
    //[XmlAttribute("CamBoundsBRPos")]     public string CamBoundsBR_Surrogate{ get { return "";}

    [XmlArray("GeomsInRoom")]
    [XmlArrayItem("Geom")]
    public List<Geom_Base> geomsInRoom = new List<Geom_Base>();

    [XmlArray("EntitiesInRoom")]
    [XmlArrayItem("Entity")]
    public List<Entity_Base> entitiesInRoom = new List<Entity_Base>();
   
}

