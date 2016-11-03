using UnityEngine;
using System.Collections;

public class DatabaseGlobal : MonoBehaviour 
{
	void Awake ()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

}
