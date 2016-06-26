using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{
	public List<GameObject> neighbors = new List<GameObject>();
	public float nodeConnectRadius = 50.0f;
	public float spherecastRadius = 0.5f;
	public LayerMask nodeLayerMask;
	public LayerMask collisionLayerMask;		//add to this layerMask all layers that occlude pathfinding  (also Pathfind_Node)
	public LayerMask deleteMeLayerMask;

	public GameObject goal;

	private float nodeRadius;


	[ContextMenu ("Connect Node to Neighbors")]
	public void ConnectNeighbors()
	{
		neighbors.Clear();
		Collider[] cols = Physics.OverlapSphere (transform.position, nodeConnectRadius, nodeLayerMask);
		foreach(Collider node in cols)
		{
			if(node.gameObject != gameObject)
			{
				RaycastHit hit;
				Physics.SphereCast(transform.position, spherecastRadius, (node.transform.position - transform.position), out hit, nodeConnectRadius, collisionLayerMask);

				if(hit.transform != null)
				{
					if(hit.transform.gameObject == node.gameObject)
					{
						neighbors.Add (node.gameObject);
					}
				}
			}
		}
	}

	void OnDestory()   //ability to runtime delete node
	{
		DisconnectNeighbors();
	}
		
	[ContextMenu ("Disconnect Node from Neighbors")]
	void DisconnectNeighbors()
	{
		foreach(GameObject neighbor in neighbors)
		{
			neighbor.GetComponent<Node>().neighbors.Remove(gameObject);
		}
		neighbors.Clear();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(transform.position, Vector3.one);
		Gizmos.color = Color.green;
		nodeRadius = gameObject.GetComponent<SphereCollider>().radius;
		Gizmos.DrawWireSphere(transform.position, nodeRadius);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, nodeConnectRadius);
		Gizmos.color = Color.blue;
		foreach(GameObject neighbor in neighbors)
		{
			DrawArrow.ForDebug(transform.position, neighbor.transform.position - transform.position, Color.blue);
		}

		if(goal)
		{
			Gizmos.color = Color.green;
			GameObject current = gameObject;
			Stack<GameObject> path = DijkstrasAlgorithm.Dijkstra(gameObject, goal);
			foreach(GameObject obj in path)
			{
				Gizmos.DrawWireSphere(obj.transform.position, 0.7f);
				Gizmos.DrawLine(current.transform.position, obj.transform.position);
				current = obj;
			}
		}
	}


}
