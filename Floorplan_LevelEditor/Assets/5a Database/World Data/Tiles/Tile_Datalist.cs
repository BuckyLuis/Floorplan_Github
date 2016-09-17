using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Tiles_Database")]
public class Tile_DataList
{
	[XmlArray("Tiles")]
	[XmlArrayItem("Tile")]
	public List<Geom_Base> tiles = new List<Geom_Base>();
}
