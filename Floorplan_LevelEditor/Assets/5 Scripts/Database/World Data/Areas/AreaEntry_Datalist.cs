using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot ("AreaCatalog_Database")]
public class AreaEntry_DataList
{
    [XmlArray("AreaCatalogEntries")]
    [XmlArrayItem("AreaEntry")]
    public List<AreaEntry_Base> areaEntries = new List<AreaEntry_Base>();
}
