using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class Area_ReadWrite : MonoBehaviour 
{
    private string docsPath = "";
    private string path = "";
    private IO_GetDatasPath getDatasPath;

    public WWW _xml;

    public static Area_DataList Areas_DataObject;



    //  void Awake()
    //  {
    //      ReadXMLData();
    //  }

    void Start()
    {
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
    }

    public void WriteXMLData(int writeDisplayName, string writeFileName)
    {
        Area_Base areaW = new Area_Base();
        areaW.IndexID = writeDisplayName;
        GetCombinedPath();
        WriteToXML(areaW);
    }

    public static Area_DataList ReadFromXML(WWW _xml)  //string path
    {
        XmlSerializer serializerR = new XmlSerializer(typeof(Area_DataList));
        StringReader reader = new StringReader(_xml.text);
        Area_DataList readAreas = serializerR.Deserialize(reader) as Area_DataList;
        reader.Close();

        return readAreas;
    }

    void WriteToXML(Area_Base areaW) 
    {
        XmlSerializer serializerW = new XmlSerializer(typeof(Area_Base));
        using (TextWriter writer = new StreamWriter(path))
        {
            serializerW.Serialize(writer, areaW);
        }
    }

    private void GetCombinedPath()
    {
        docsPath = getDatasPath.Pref_UserDatasPath();

        switch (IO_GetDatasPath.Pref_UserDataPath) 
        {
            case (0):
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "WorldData", "Areas.xml");                      //Data Folder next to the compiled .exe
                break;
            case (1):
                path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "FloorPlan", "Data", "Xml", "WorldData", "Areas.xml");     //on Windows: the MyDocuments folder
                break;      

            default:
                path = getDatasPath.CombinePath ("file:///", docsPath, "Data", "Xml", "WorldData", "Areas.xml"); 
                break;
        }                                   
    }

    IEnumerator ProcessWWW(string path)
    {
        WWW www = new WWW ("file:///" + path);              //  the "file:///" here and in the path IS necessary!
        yield return www;

        if(www.error == null)
        {
            Areas_DataObject = ReadFromXML(www);
        }
        else
        {
            Debug.LogError ("ERROR: Problem yielding a WWW text from Xml; is there a 'Areas.xml' file at" + path + "?");
        }
        www.Dispose();
        www = null;
    }

}
