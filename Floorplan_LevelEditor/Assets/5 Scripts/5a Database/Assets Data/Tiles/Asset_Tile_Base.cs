using UnityEngine;
using System;
using System.Collections;
using System.Xml.Serialization;

public class Asset_Tile_Base 
{
	[XmlElement("IndexID")] 		public int IndexID {get; set;}    //simply for display, otherwise youd have to count! (itd royally suck)


    [XmlElement("CategoryIndex")]   public int CategoryIndex {get; set;}
    [XmlElement("TileIndex")]	    public int TileIndex {get; set;}


    //TODO: implement AssetBundles ??? sometime?
   
}



