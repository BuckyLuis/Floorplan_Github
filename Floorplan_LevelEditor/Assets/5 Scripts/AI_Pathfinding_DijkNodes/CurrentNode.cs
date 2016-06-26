using UnityEngine;
using System.Collections;

public class CurrentNode : MonoBehaviour 
{
	public GameObject currentNode;

	public bool isAI = true;

	void Awake () 
	{
		SetCurrentNode();
	}

	void SetCurrentNode()
	{
		float shortestDist = Mathf.Infinity;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Pathfind_Node"))
		{
			float dist = (obj.transform.position - transform.position).magnitude;
			if(dist < shortestDist)
			{
				shortestDist = dist;
				currentNode = obj;
			}
		}
	}

	void Update () 
	{
		if(!isAI || currentNode == null)
		{
			SetCurrentNode();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Pathfind_Node")
		{
			currentNode = col.gameObject;
		}
	}
}
