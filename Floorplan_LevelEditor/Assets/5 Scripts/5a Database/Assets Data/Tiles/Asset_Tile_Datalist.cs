using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Asset_Tiles_Database")]
public class Asset_Tile_DataList
{
	[XmlArray("Assets_Tiles")]
	[XmlArrayItem("Asset_Tile")]
    public List<Asset_Tile_Base> assetTiles = new List<Asset_Tile_Base>();
}
