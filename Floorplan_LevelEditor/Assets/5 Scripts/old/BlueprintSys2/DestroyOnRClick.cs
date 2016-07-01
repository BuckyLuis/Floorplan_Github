using UnityEngine;
using System.Collections;

public class DestroyOnRClick : MonoBehaviour
{
/*	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			{
				//Transform objecthit = hit.transform;
				if (hit.transform.gameObject.tag == "BlueprintWall_tag")
				{
					Destroy(gameObject);
				}
			}
		}
	} 
*/
		
	void RightClicked()
	{
		Destroy(gameObject);
	}

	

}
