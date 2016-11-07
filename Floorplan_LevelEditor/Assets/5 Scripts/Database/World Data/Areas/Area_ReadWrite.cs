using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class Area_ReadWrite : MonoBehaviour 
{
    AreaObjectRegistrar theAreaObjectRegistrarScript;

    private string docsPath = "";
    private string path = "";
    private IO_GetDatasPath getDatasPath;

    public WWW _xml;

//===================================================
    public Area_Base Area_DataObject;

//===================================================


    //  void Awake()
    //  {
    //      ReadXMLData();
    //  }

    void Start()
    {
        theAreaObjectRegistrarScript = GetComponent<AreaObjectRegistrar>();
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

    public void ReadXMLData(string theArea_Name) 
    {
        GetCombinedPath(theArea_Name);
        StartCoroutine(ProcessWWW(path));
        //ProcessWWW(path);
        //return Area_DataObject;
    }

    public void WriteXMLData(Area_Base theArea_ToWrite, string theArea_Name)
    {
        GetCombinedPath(theArea_Name);
        WriteToXML(theArea_ToWrite);
    }

    public Area_Base ReadFromXML(WWW _xml)  //string path
    {
        XmlSerializer serializerR = new XmlSerializer(typeof(Area_Base));
        StringReader reader = new StringReader(_xml.text);
        Area_Base readArea = serializerR.Deserialize(reader) as Area_Base;
        reader.Close();

        return readArea;
    }

    void WriteToXML(Area_Base areaW) 
    {
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);

        XmlSerializer serializerW = new XmlSerializer(typeof(Area_Base));
        using (TextWriter writer = new StreamWriter(path))
        {
            serializerW.Serialize(writer, areaW, ns);
        }
    }

    public void GetCombinedPath(string theArea_Name)
    {
        docsPath = getDatasPath.Pref_UserDatasPath();

        switch (IO_GetDatasPath.Pref_UserDataPath) 
        {
            case (0):
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "Areas", theArea_Name + ".xml");                      //Data Folder next to the compiled .exe
                break;
            case (1):
                path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "FloorPlan", "Data", "Xml", "Areas", theArea_Name + ".xml");     //on Windows: the MyDocuments folder
                break;      

            default:
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "Areas", theArea_Name + ".xml"); 
                break;
        }                                   
    }
    IEnumerator ProcessWWW(string path)
    {
        WWW www = new WWW ("file:///" + path);              //  the "file:///" here and in the path IS necessary!
        yield return www;

        if(www.error == null)
        {
            Area_DataObject = ReadFromXML(www);
            theAreaObjectRegistrarScript.ConstructLevelFromLoadedArea();
        }
        else
        {
            Debug.LogError ("ERROR: Problem yielding a WWW text from Xml; is there a 'Areas.xml' file at" + path + "?");
        }
        www.Dispose();
        www = null;
    }

}
