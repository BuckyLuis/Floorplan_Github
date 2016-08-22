using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Tile_Base 
{
    [XmlElement("RoomID")]          public int RoomID {get; set;}

    [XmlIgnore] public Vector3 Position;
    [XmlAttribute("Position")]      public string Pos_Surrogate{ get { return "";}
                                                                 set { Position = new Vector3().FromString(value); }}
    
    [XmlElement("CategoryIndex")]   public int CategoryIndex {get; set;}
    [XmlElement("AssetIndex")]	    public int AssetIndex {get; set;}

    [XmlElement("MaterialName")]  public string MaterialName {get; set;}

    [XmlElement("TileFacingRot")]  public float TileFacingRot {get; set;}   //0-N, 1-E, 2-S, 3-W
   
    [XmlIgnore] public string editorGoName; 
    [XmlIgnore] public Color roomColor;
    [XmlIgnore] public GameObject theGameObjectPrefab;

}



