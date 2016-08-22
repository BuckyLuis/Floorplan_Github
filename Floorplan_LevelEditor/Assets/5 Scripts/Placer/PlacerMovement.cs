using UnityEngine;
using System.Collections;

public class PlacerMovement: MonoBehaviour
{		
    public LayerMask mask;

	public Vector3 destinationPos;

    public bool tile0_entity1;
    public int tilePlacerYpos;

    void Start() {
        tilePlacerYpos = 0;
    }

    void Update() {	
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
		{
			Vector3 wantedPos = hit.point;

            if(tile0_entity1 == false) {
                float xPos = Mathf.Round(wantedPos.x / 2);                                                          
                float zPos = Mathf.Round(wantedPos.z / 2);
                destinationPos = new Vector3(xPos * 2, tilePlacerYpos, zPos * 2);
            }
            else {
                float xPos = Mathf.Round(wantedPos.x / 1);                                                          
                float zPos = Mathf.Round(wantedPos.z / 1);
                destinationPos = new Vector3(xPos + 0.5f, tilePlacerYpos, zPos + 0.5f);
            }
           
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


	

