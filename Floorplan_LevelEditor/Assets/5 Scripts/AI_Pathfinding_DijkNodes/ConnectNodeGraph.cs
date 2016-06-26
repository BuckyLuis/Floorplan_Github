using UnityEngine;
using System.Collections;

public class ConnectNodeGraph : MonoBehaviour 
{
	[ContextMenu ("Connect All Nodes in GraphList")]
	void ConnectAllNodes() 
	{
		foreach(GameObject node in NodesGraph.nodeGraph)
		{
			Node nodeScript = GetComponent<Node>();
			nodeScript.ConnectNeighbors();
		}
	}

}
