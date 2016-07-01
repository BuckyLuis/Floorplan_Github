using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Area_Base 
{
    [XmlElement("IndexID")]         public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("AreaID")]         public int AreaID {get; set;} 

    [XmlArray("RoomsInArea")]
    [XmlArrayItem("Room")]
    public List<Room_Base> RoomsInArea = new List<Room_Base>();


    /*[XmlIgnore] public Vector3 OriginPos;
    [XmlAttribute("OriginPos")]     public string OriginPos_Surrogate{ get { return "";}
                                                                       set { OriginPos = new Vector3().FromString(value); }}*/
}