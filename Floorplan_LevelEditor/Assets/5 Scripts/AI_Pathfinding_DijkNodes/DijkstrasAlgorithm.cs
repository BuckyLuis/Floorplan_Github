using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DijkstrasAlgorithm
{
	public static Stack<GameObject> Dijkstra(GameObject source, GameObject target)
	{
		if(source != null && target != null)
		{
			Dictionary<GameObject, float> dist = new Dictionary<GameObject, float>();
			Dictionary<GameObject, GameObject> previous = new Dictionary<GameObject, GameObject>();
			List<GameObject> Q = new List<GameObject>();

			List<GameObject> nodeGraph = new List<GameObject>();
			nodeGraph.Add(source);
			for(int i = 0; i < nodeGraph.Count; i++)
			{
				foreach(GameObject node in nodeGraph[i].GetComponent<Node>().neighbors)
				{
					if (!nodeGraph.Contains(node))
					{
						nodeGraph.Add (node);
					}
				}
			}

			foreach(GameObject v in nodeGraph)
			{
				dist[v] = Mathf.Infinity;
				previous[v] = null;
				Q.Add(v);
			}
			dist[source] = 0;

			while(Q.Count > 0)
			{
				float shortestDist = Mathf.Infinity;
				GameObject shortestDistNode = null;
				foreach(GameObject obj in Q)
				{
					if(dist[obj] < shortestDist)
					{
						shortestDist = dist[obj];
						shortestDistNode = obj;
					}
				}
				GameObject u = shortestDistNode;
				Q.Remove(u);

				if(u == target)
				{
					Stack<GameObject> S = new Stack<GameObject>();

					S.Push(u);
					while (previous[u] != null)
					{
						S.Push (u);
						u = previous[u];
					}
					return S;
				}
					
				if(dist[u] == Mathf.Infinity)
				{
					break;
				}

				foreach(GameObject v in u.GetComponent<Node>().neighbors)
				{
					float alt = dist[u] + (u.transform.position - v.transform.position).magnitude;

					if(alt < dist[v])
					{
						dist[v] = alt;
						previous[v] = u;
					}
				}
			}
		}
		return null;
	}
		
}



/*			//Dijkstra's Algorithm - from wikipedia : 
 1  function Dijkstra(Graph, source):
 2      for each vertex v in Graph:                                // Initializations
 3          dist[v] := infinity ;                                  // Unknown distance function from 
 4                                                                 // source to v
 5          previous[v] := undefined ;                             // Previous node in optimal path
 6      end for                                                    // from source
 7      
 8      dist[source] := 0 ;                                        // Distance from source to source
 9      Q := the set of all nodes in Graph ;                       // All nodes in the graph are
10                                                                 // unoptimized - thus are in Q
11      while Q is not empty:                                      // The main loop
12          u := vertex in Q with smallest distance in dist[] ;    // Start node in first case
13          remove u from Q ;
14          if dist[u] = infinity:
15              break ;                                            // all remaining vertices are
16          end if                                                 // inaccessible from source
17          
18          for each neighbor v of u:                              // where v has not yet been 
19                                                                 // removed from Q.
20              alt := dist[u] + dist_between(u, v) ;
21              if alt < dist[v]:                                  // Relax (u,v,a)
22                  dist[v] := alt ;
23                  previous[v] := u ;
24                  decrease-key v in Q;                           // Reorder v in the Queue
25              end if
26          end for
27      end while
28  return dist;

If we are only interested in a shortest path between vertices source and target, we can terminate the search at line 13 if u = target.
		Now we can read the shortest path from source to target by reverse iteration:

1  S := empty sequence
2  u := target
3  while previous[u] is defined:                                   // Construct the shortest path with a stack S
4      insert u at the beginning of S                              // Push the vertex into the stack
5      u := previous[u]                                            // Traverse from target to source
6  end while ;
*/