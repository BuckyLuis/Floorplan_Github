using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Areas_Database")]
public class Area_DataList
{
    [XmlArray("Areas")]
    [XmlArrayItem("Area")]
    public List<Area_Base> areas = new List<Area_Base>();
}
