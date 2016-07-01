using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class Room_ReadWrite : MonoBehaviour 
{
	private string docsPath = "";
	private string path = "";
	private IO_GetDatasPath getDatasPath;

	public WWW _xml;

    public static Room_DataList Rooms_DataObject;



//	void Awake()
//	{
//		ReadXMLData();
//	}

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
        Room_Base roomW = new Room_Base();
        roomW.IndexID = writeDisplayName;
		GetCombinedPath();
		WriteToXML(roomW);
	}

	public static Room_DataList ReadFromXML(WWW _xml)  //string path
	{
        XmlSerializer serializerR = new XmlSerializer(typeof(Room_DataList));
		StringReader reader = new StringReader(_xml.text);
        Room_DataList readRooms = serializerR.Deserialize(reader) as Room_DataList;
		reader.Close();

        return readRooms;
	}

    void WriteToXML(Room_Base roomW) 
	{
        XmlSerializer serializerW = new XmlSerializer(typeof(Room_Base));
		using (TextWriter writer = new StreamWriter(path))
		{
            serializerW.Serialize(writer, roomW);
		}
	}

	private void GetCombinedPath()
	{
		docsPath = getDatasPath.Pref_UserDatasPath();

		switch (IO_GetDatasPath.Pref_UserDataPath) 
		{
		case (0):
			path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "WorldData", "Rooms.xml"); 						//Data Folder next to the compiled .exe
			break;
		case (1):
            path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "FloorPlan", "ModData", "VanillaData", "Xml", "WorldData", "Rooms.xml");		//on Windows: the MyDocuments folder
			break;		

		default:
            path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "WorldData", "Rooms.xml"); 
			break;
		}									
	}

	IEnumerator ProcessWWW(string path)
	{
		WWW www = new WWW ("file:///" + path);  			//	the "file:///" here and in the path IS necessary!
		yield return www;

		if(www.error == null)
		{
			Rooms_DataObject = ReadFromXML(www);
		}
		else
		{
			Debug.LogError ("ERROR: Problem yielding a WWW text from Xml; is there a 'Rooms.xml' file at" + path + "?");
		}
		www.Dispose();
		www = null;
	}

}
