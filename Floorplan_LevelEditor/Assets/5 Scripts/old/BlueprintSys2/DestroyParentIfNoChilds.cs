﻿using UnityEngine;
using System.Collections;

public class DestroyParentIfNoChilds : MonoBehaviour 
{
	void Update()
	{
		if(transform.childCount <= 0) 
		{
			Destroy(gameObject);
		}
	}
	
}
