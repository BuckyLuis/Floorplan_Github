using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class Card_ReadWrite : MonoBehaviour 
{
	private string docsPath = "";
	private string path = "";
	private IO_GetDatasPath getDatasPath;

	public WWW _xml;

	public static Card_DataList Cards_DataObject;



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

	public void WriteXMLData(string writeDisplayName, string writeFileName)
	{
		Card_Base cardW = new Card_Base();
		cardW.Title = writeDisplayName;
		GetCombinedPath();
		WriteToXML(cardW);
	}

	public static Card_DataList ReadFromXML(WWW _xml)  //string path
	{
		XmlSerializer serializerR = new XmlSerializer(typeof(Card_DataList));
		StringReader reader = new StringReader(_xml.text);
		Card_DataList readCards = serializerR.Deserialize(reader) as Card_DataList;
		reader.Close();

		return readCards;
	}

	void WriteToXML(Card_Base cardW) 
	{
		XmlSerializer serializerW = new XmlSerializer(typeof(Card_Base));
		using (TextWriter writer = new StreamWriter(path))
		{
			serializerW.Serialize(writer, cardW);
		}
	}

	private void GetCombinedPath()
	{
		docsPath = getDatasPath.Pref_UserDatasPath();

		switch (IO_GetDatasPath.Pref_UserDataPath) 
		{
		case (0):
			path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "items", "Cards.xml"); 						//Data Folder next to the compiled .exe
			break;
		case (1):
			path = getDatasPath.CombinePath ("file:///", docsPath, "My Games", "HelpingHands", "ModData", "VanillaData", "Xml", "items", "Cards.xml");		//on Windows: the MyDocuments folder
			break;		

		default:
			path = getDatasPath.CombinePath ("file:///", docsPath, "ModData", "VanillaData", "Xml", "items", "Cards.xml"); 
			break;
		}									
	}

	IEnumerator ProcessWWW(string path)
	{
		WWW www = new WWW ("file:///" + path);  			//	the "file:///" here and in the path IS necessary!
		yield return www;

		if(www.error == null)
		{
			Cards_DataObject = ReadFromXML(www);
		}
		else
		{
			Debug.Log ("ERROR: Problem yielding a WWW text from Xml; is there a 'Swords.xml' file at" + path + "???");
		}
		www.Dispose();
		www = null;
	}

}
