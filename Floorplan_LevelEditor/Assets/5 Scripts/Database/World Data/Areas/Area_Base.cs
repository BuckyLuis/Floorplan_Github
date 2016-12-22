﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable, XmlRoot("Area")]
public class Area_Base 
{
    [XmlElement("IndexID")]     public string IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("AreaID")]      public string AreaID {get; set;} 
    [XmlElement("AreaName")]    public string AreaName {get; set;} 


    [XmlArray("RoomsInArea")]
    [XmlArrayItem("Room")]
    public List<Room_Base> roomsInArea = new List<Room_Base>();

}








      