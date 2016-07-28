using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Tiles_Database")]
public class Entity_DataList
{
	[XmlArray("Tiles")]
	[XmlArrayItem("Tile")]
	public List<Tile_Base> tiles = new List<Tile_Base>();
}
