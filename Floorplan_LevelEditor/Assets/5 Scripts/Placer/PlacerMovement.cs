using UnityEngine;
using System.Collections;

public class PlacerMovement: MonoBehaviour
{		
	public static Vector3 destinationPos;
	public int size = 1;

    public static int tilePlacerYpos;

    void Start() {
        tilePlacerYpos = 0;
    }

    void Update() {	
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			Vector3 wantedPos = hit.point;
			float xPos = Mathf.Round(wantedPos.x / size);                                                           //snap to grid
			float zPos = Mathf.Round(wantedPos.z / size);
            destinationPos = new Vector3(xPos * size, tilePlacerYpos, zPos * size);
			transform.position = destinationPos;
		}
	}
}



// works for Straight Top camera V
		//Vector3 mousePos = Input.mousePosition;															//snap object to cursor
		//Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.mainCamera.gameObject.transform.position.z));    // Z  is the distance from front of camera we want widget at Camera.mainCamera.gameObject.transform.position.z
		// float xPos = Mathf.Round(wantedPos.x);                                                           //snap to grid
		// float zPos = Mathf.Round(wantedPos.z);

		//transform.position = new Vector3(xPos, transform.position.y, zPos);


	

