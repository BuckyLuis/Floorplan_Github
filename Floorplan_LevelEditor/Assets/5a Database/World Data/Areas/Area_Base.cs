using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Area_Base 
{
    [XmlElement("IndexID")]     public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("AreaID")]      public int AreaID {get; set;} 

    [XmlArray("RoomsInArea")]
    [XmlArrayItem("Room")]
    public List<Room_Base> roomsInArea = new List<Room_Base>();

    [XmlArray("TilesInArea")]
    [XmlArrayItem("Tile")]
    public List<Tile_Base> tilesInArea = new List<Tile_Base>();
}