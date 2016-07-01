using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SetBlueprint : MonoBehaviour 
{
	
	//-------------- grid tiles -------------------------------------------------
	public Transform TileBlueprint;
	public Transform TileParent;
	
	public GameObject placeholder;
	private GameObject instPlaceholder;

    public int gridSize = 1;
	
	Vector3 Click_origPos;
    Vector3 Click_destPos;
	
	bool Click_init = false;
	bool xIsNeg	= false;
	bool zIsNeg	= false;
	
	int tempGridSizeX;
	int tempGridSizeZ;
	int TileGridSizeX;
	int TileGridSizeZ;
	
	int TileXPos;
	int TileZPos;
	
	int roomNum = 0;
	
	static Color tileCol;	
	//-----------------------------------------------------------------
	
	
	
	void Update()
	{
		if(Input.GetMouseButton(0)) 
		{
		//	if (EventSystemManager.currentSystem.IsPointerOverEventSystemObject())			//dont do anything if the click is on UI elements.
		//	{}
		//	else
		//	{
				Click_destPos = PlacerMovement.destinationPos;
                TileGridSizeX = Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) ) + 1;
                TileGridSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize) - (Click_origPos.z / gridSize) ) + 1;
				
				if(Click_destPos.x < Click_origPos.x)
				{
                    tempGridSizeX = Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) - 1);
					TileGridSizeX =	Mathf.Abs (tempGridSizeX);
					xIsNeg = true;
				}
				else	
					xIsNeg = false;
				
				if(Click_destPos.z < Click_origPos.z)
				{
                    tempGridSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize)- (Click_origPos.z / gridSize) - 1);	
					TileGridSizeZ = Mathf.Abs (tempGridSizeZ);
					zIsNeg = true;
				}
				else
					zIsNeg = false;
		//	}
		}
		
		
		if(Input.GetMouseButtonUp(0))
		{
		//	if (EventSystemManager.currentSystem.IsPointerOverEventSystemObject())
		//	{}
		//	else
		//	{
				Destroy(instPlaceholder);
				if(Click_init == true)
				{
					if(xIsNeg == true)
					{
						Click_origPos.x = Click_destPos.x;
					}
					if(zIsNeg == true)
					{
						Click_origPos.z = Click_destPos.z;
					}
					if(xIsNeg == true && zIsNeg == true)
					{
						Click_origPos = Click_destPos;
					}
					CreateTiles();
				}
				else
				{}	
				Click_init = false;
		//	}
		}
		
	}
	
	
	void Clicked()
	{	
		Click_init = true;
		Click_origPos = transform.position;
		instPlaceholder = (GameObject)Instantiate(placeholder, transform.position ,transform.rotation);
	}

	
	void CreateTiles()
	{
		Transform parentCell;
		parentCell = (Transform)Instantiate(TileParent, Click_origPos, transform.rotation);
        parentCell.name = "Room: " + roomNum.ToString();
		
        for(int xL = 0; xL < TileGridSizeX; xL++)                   //xL , zL are local (relative to parentCell) coords!
		{
			for(int zL = 0; zL < TileGridSizeZ; zL++)
			{
				//for(int y = 0; y < TerrainGridSize.y; y++)
				//{
				Transform kidCell;
                kidCell = (Transform)Instantiate(TileBlueprint, new Vector3((xL * gridSize)+ Click_origPos.x, 0, (zL * gridSize)+ Click_origPos.z), TileBlueprint.transform.rotation);  
                kidCell.name = string.Format ("R: ({0},0,{1}) / G: ({2},{3},{4})", xL, zL, kidCell.transform.position.x, kidCell.transform.position.y, kidCell.transform.position.z);
             //   kidCell.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color1", new Color(tileCol.r - 20, tileCol.g - 20, tileCol.b - 20));
                kidCell.GetChild(0).GetComponent<Renderer>().material.color = tileCol;
				kidCell.parent = parentCell;
				//kidCell.parent = transform;
				//}
			}
		}
		
	}
	
//--------- functions for GUI to process --------------
	public void IncrementRoomNum()
	{
		roomNum++;
	}
	
	
	
	
	
}
