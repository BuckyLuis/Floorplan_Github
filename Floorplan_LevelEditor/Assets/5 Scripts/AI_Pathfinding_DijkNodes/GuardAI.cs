using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardAI : MonoBehaviour 
{
	public float speed = 5.0f;
	public float turnSpeed = 100f;

	public GameObject[] patrolNodes;

	private GameObject goalNode = null;
	private GameObject moveToNode = null;


	void Start () 
	{
		StartCoroutine("Patrol");
	}

	void Update () 
	{
	
	}

	IEnumerator Patrol()
	{
		while(true)
		{
			if(goalNode == null)
			{
				goalNode = patrolNodes[Random.Range(0, patrolNodes.Length)];
			}
			if(moveToNode == null)
			{
				Stack<GameObject> path = DijkstrasAlgorithm.Dijkstra(gameObject.GetComponent<CurrentNode>().currentNode, goalNode);
				moveToNode = path.Pop();
			}

			transform.position += transform.forward * speed * Time.deltaTime;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation((moveToNode.transform.position - transform.position).normalized), turnSpeed * Time.deltaTime);

			yield return null;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject == moveToNode)
		{
			moveToNode = null;
		}
		if(col.gameObject == goalNode)
		{
			goalNode = null;
		}
	}
}
