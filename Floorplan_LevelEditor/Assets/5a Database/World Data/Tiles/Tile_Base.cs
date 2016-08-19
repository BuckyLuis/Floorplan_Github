using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Tile_Base 
{
//	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

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

 /*   public Tile_Base(int roomID, Vector3 position, int categoryIndex, int assetIndex, int tileFacingFlag, string materialName) {
        RoomID = roomID;
        Position = position;
        CategoryIndex = categoryIndex;
        AssetIndex = assetIndex;
        MaterialName = materialName;
        TileFacingFlag = tileFacingFlag;
    }*/
}



