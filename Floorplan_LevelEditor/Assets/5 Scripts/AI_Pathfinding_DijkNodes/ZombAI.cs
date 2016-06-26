using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombAI : MonoBehaviour 
{
	public float speed = 5.0f;
	public float turnSpeed = 100f;

	//sight
	public float sphereCastRadius = 1.0f;

	GameObject goalNode;
	bool initialFrame = true;

	Vector3 goalPos;
	Vector3 goalDir;
	Vector3 nrmGoalDir;

	CurrentNode myCN_Ref;
	GameObject myCurrentNode;


	GameObject player;
	GameObject player_Ref;
	GameObject playerCurrentNode;
	GameObject playerNodeLastframe;

	int fixCounter;

	void Awake()
	{
		player_Ref = GameObject.FindGameObjectWithTag("Player");
		myCN_Ref = gameObject.GetComponent<CurrentNode>();
	}

	void Update () 
	{
		myCurrentNode = myCN_Ref.currentNode;
		player = player_Ref;

		playerNodeLastframe = playerCurrentNode;
		playerCurrentNode = player.GetComponent<CurrentNode>().currentNode;



		if(myCurrentNode != playerCurrentNode) 	//traverse to next node in path towards player
		{
			if(myCurrentNode == goalNode || playerNodeLastframe != playerCurrentNode || initialFrame)
			{
				Stack<GameObject> path = DijkstrasAlgorithm.Dijkstra(gameObject.GetComponent<CurrentNode>().currentNode,
					player.GetComponent<CurrentNode>().currentNode);
				initialFrame = false;
				
				if(path != null)
				{
					goalNode = path.Pop();
					goalPos = goalNode.transform.position;
				}

			}
			goalDir = goalPos - transform.position;
			goalDir.y = 0.0f;
			nrmGoalDir = goalDir.normalized;
			transform.position += transform.forward * speed * Time.deltaTime;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nrmGoalDir), turnSpeed * Time.deltaTime);
		}

		else if(myCurrentNode == playerCurrentNode)		//if zombie is at the closest node to player
		{
			RaycastHit hit;
			Physics.SphereCast(transform.position, sphereCastRadius, player.transform.position - transform.position, out hit);  // & can see player (with margin to fit),  it then goes to player
			if(hit.collider.tag == "Player")
			{
				Vector3 playerPos = player.transform.position;
				Vector3 playerDir = playerPos - transform.position;
				playerDir.y = 0.0f;
				Vector3 nrmPlayerDir = playerDir.normalized;

				transform.position += transform.forward * speed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nrmPlayerDir), turnSpeed * Time.deltaTime);
			}
		}


	}

	void OnDrawGizmos()
	{
		player_Ref = GameObject.FindGameObjectWithTag("Player");

		Gizmos.color = Color.green;
		//Gizmos.DrawLine(transform.position, goal.transform.position);
		RaycastHit hit;
		Physics.SphereCast(transform.position, sphereCastRadius, player_Ref.transform.position - transform.position, out hit);

		if(hit.collider != null)
		{
			if(hit.collider.tag != "Player")
			{
				Gizmos.color = Color.red;
			}
		}
		Gizmos.DrawLine(transform.position, player_Ref.transform.position);
	}
}
