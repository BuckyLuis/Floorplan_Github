using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class Entity_ReadWrite : MonoBehaviour 
{
	private string docsPath = "";
	private string path = "";
	private IO_GetDatasPath getDatasPath;

	public WWW _xml;

	public static Tile_DataList Tiles_DataObject;



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
        Tile_Base tileW = new Tile_Base();
		GetCombinedPath();
		WriteToXML(tileW);
	}

	public static Tile_DataList ReadFromXML(WWW _xml)  //string path
	{
		XmlSerializer serializerR = new XmlSerializer(typeof(Tile_DataList));
		StringReader reader = new StringReader(_xml.text);
		Tile_DataList readTiles = serializerR.Deserialize(reader) as Tile_DataList;
		reader.Close();

        return readTiles;
	}

    void WriteToXML(Tile_Base tileW) 
	{
		XmlSerializer serializerW = new XmlSerializer(typeof(Tile_Base));
		using (TextWriter writer = new StreamWriter(path))
		{
            serializerW.Serialize(writer, tileW);
		}
	}

	private void GetCombinedPath()
	{
		docsPath = getDatasPath.Pref_UserDatasPath();

		switch (IO_GetDatasPath.Pref_UserDataPath) 
		{
		case (0):
            path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "WorldData", "Tiles.xml"); 						//Data Folder next to the compiled .exe
			break;
		case (1):
            path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "FloorPlan", "ModData", "VanillaData", "Xml", "WorldData", "Tiles.xml");		//on Windows: the MyDocuments folder
			break;		

		default:
            path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "WorldData", "Tiles.xml"); 
			break;
		}									
	}

	IEnumerator ProcessWWW(string path)
	{
		WWW www = new WWW ("file:///" + path);  			//	the "file:///" here and in the path IS necessary!
		yield return www;

		if(www.error == null)
		{
			Tiles_DataObject = ReadFromXML(www);
		}
		else
		{
			Debug.LogError ("ERROR: Problem yielding a WWW text from Xml; is there a 'Tiles.xml' file at" + path + "?");
		}
		www.Dispose();
		www = null;
	}

}
