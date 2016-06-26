using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("Cards_Database")]
public class Card_DataList
{
	[XmlArray("Cards")]
	[XmlArrayItem("Card")]
	public List<Card_Base> cards = new List<Card_Base>();
}
