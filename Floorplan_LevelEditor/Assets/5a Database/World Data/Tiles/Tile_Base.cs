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
    
    [XmlElement("CategoryIndex")]   public int CategoryIndex {get; set;}
    [XmlElement("TileIndex")]	    public int TileIndex {get; set;}

    [XmlElement("TileFacingFlag")]  public int TileFacingFlag {get; set;}   //0-N, 1-E, 2-S, 3-W
    [XmlElement("TextureSetName")]  public string TextureSetName {get; set;}


}



