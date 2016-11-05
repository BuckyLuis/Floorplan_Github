using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Geom_Base 
{
    [XmlElement("RoomID")]          public string RoomID {get; set;}

    public Vector3 Position;
/*    [XmlAttribute("Position")]      public string Pos_Surrogate{ get { return "";}
                                                                 set { Position = new Vector3().FromString(value); }}
    */
    [XmlElement("TypeIndex")]       public int TypeIndex {get; set;}
    [XmlElement("CategoryIndex")]   public int CategoryIndex {get; set;}
    [XmlElement("AssetIndex")]	    public int AssetIndex {get; set;}

    [XmlElement("TexAtlasIndex")]  public int TexAtlasIndex {get; set;}

    [XmlElement("TileFacingRot")]  public float TileFacingRot {get; set;}   //0-N, 1-E, 2-S, 3-W
   
    public Color roomColor;
    public string editorGoName; 

    [XmlIgnore] public GameObject theGameObjectPrefab;

}



