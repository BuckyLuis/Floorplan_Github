using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable, XmlRoot("AreaEntry")]
public class AreaEntry_Base 
{
    [XmlElement("IndexID")]     public string IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)

    [XmlElement("AreaID")]      public string AreaEntryID {get; set;} 
    [XmlElement("AreaName")]    public string AreaEntryName {get; set;} 
}