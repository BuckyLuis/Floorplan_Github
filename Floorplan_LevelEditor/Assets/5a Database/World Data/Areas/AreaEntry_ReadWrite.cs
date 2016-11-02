using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class AreaEntry_ReadWrite : MonoBehaviour 
{
    AreaSaveLoadUI theAreaSaveLoadUIScript;

    private string docsPath = "";
    private string path = "";
    private IO_GetDatasPath getDatasPath;

    public WWW _xml;

    //===================================================
    public AreaEntry_DataList AreaCatalog_DataObject;
    //===================================================


    //  void Awake()
    //  {
    //      ReadXMLData();
    //  }

    void Awake()
    {
        theAreaSaveLoadUIScript = GetComponent<AreaSaveLoadUI>();
        getDatasPath = GetComponent<IO_GetDatasPath>();
    }

    /*   //~~~!!! DEBUG !!!~~~ 
    void Update()       
    {
        if(Input.GetButtonDown("Jump"))
        {
            ReadXMLData();
            Debug.Log(Cards_DataObject.cards[1].Title);
        }
    }
    */

    public void ReadXMLData() 
    {
        GetCombinedPath();
        StartCoroutine(ProcessWWW(path));
        //ProcessWWW(path);
    }

    public void WriteXMLData(AreaEntry_DataList theCatalogToWrite)
    {
        GetCombinedPath();
        WriteToXML(theCatalogToWrite);
    }

    public AreaEntry_DataList ReadFromXML(WWW _xml)  //string path
    {
        XmlSerializer serializerR = new XmlSerializer(typeof(AreaEntry_DataList));
        StringReader reader = new StringReader(_xml.text);
        AreaEntry_DataList readAreas = serializerR.Deserialize(reader) as AreaEntry_DataList;
        reader.Close();

        return readAreas;
    }

    void WriteToXML(AreaEntry_DataList areaEntryListW) 
    {
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);

        XmlSerializer serializerW = new XmlSerializer(typeof(AreaEntry_DataList));
        using (TextWriter writer = new StreamWriter(path))
        {
            serializerW.Serialize(writer, areaEntryListW, ns);
        }
    }

    public void GetCombinedPath()
    {
        docsPath = getDatasPath.Pref_UserDatasPath();

        switch (IO_GetDatasPath.Pref_UserDataPath) 
        {
            case (0):
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "Areas", "AreaCatalog.xml");                      //Data Folder next to the compiled .exe
                break;
            case (1):
                path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "FloorPlan", "Data", "Xml", "Areas", "AreaCatalog.xml");     //on Windows: the MyDocuments folder
                break;      

            default:
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "Areas", "AreaCatalog.xml"); 
                break;
        }                                   
    }

    IEnumerator ProcessWWW(string path)
    {
        WWW www = new WWW ("file:///" + path);              //  the "file:///" here and in the path IS necessary!
        yield return www;

        if(www.error == null)
        {
            AreaCatalog_DataObject = ReadFromXML(www);
            theAreaSaveLoadUIScript.PopulateCatalogNDropdowns();
        }
        else
        {
            Debug.LogError ("ERROR: Problem yielding a WWW text from Xml; is there a 'Areas.xml' file at" + path + "?");
        }
        www.Dispose();
        www = null;
    }

}
