using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class IO_GetDatasPath : MonoBehaviour 
{	
	private string path = "";
	public static int Pref_UserDataPath = 2;



	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	
	
	public string Pref_UserDatasPath()
	{
		switch (Pref_UserDataPath) 
		{
		case (0):
			path = GetAppDataPath();				//Data Folder next to the compiled .exe
			return path;
		case (1):
			path = GetDocsPath();					//on Windows: the MyDocuments folder
			return path;
		case (2):
			path = GetPersistentDataPath();		//that annoying shit %appdata% (windows) LOL.. i guess i keep this here, for android/iOS compat.
			return path;
			
		default:
			path = GetAppDataPath();
			return path;
		}
	}
	
	
	public string GetAppDataPath()					
	{
		path = Application.dataPath + "/../";
		return path;
	}
	
	
	public string GetPersistentDataPath()			
	{
		path = Application.persistentDataPath;
		return path;
	}
	
	
	public string GetDocsPath()						
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) 
		{
			path = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);	//Windows
		} 
		else //if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXDashboardPlayer)
		{
			path = Environment.GetFolderPath (Environment.SpecialFolder.Personal);	//Mac
		} 		
																											
		return path;																						//Linux???
	}	
	
																					
	public string CombinePath(string first, params string[] others)
	{
		foreach (string element in others)
		{
			first = Path.Combine (first, element);
		}
		return first;
	}																				
}