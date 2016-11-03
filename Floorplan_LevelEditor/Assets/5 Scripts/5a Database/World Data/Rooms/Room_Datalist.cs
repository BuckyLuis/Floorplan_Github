using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Rooms_Database")]
public class Room_DataList
{
    [XmlArray("Rooms")]
    [XmlArrayItem("Room")]
    public List<Room_Base> rooms = new List<Room_Base>();
}
