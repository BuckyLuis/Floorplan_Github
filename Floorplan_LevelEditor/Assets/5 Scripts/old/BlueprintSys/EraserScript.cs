using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EraserScript : MonoBehaviour 
{
	
	//-------------- grid tiles -------------------------------------------------
	public Transform TileBlueprint;
	public Transform TileParent;
	
	public GameObject placeholder;
	private GameObject instPlaceholder;
	
	public Vector3 mClik_origPos;
	public Vector3 mClik_destPos;
	
	public bool mClik_init = false;
	public bool xIsNeg	= false;
	public bool zIsNeg	= false;
	
	public int tempGridSizeX;
	public int tempGridSizeZ;
	public int TileGridSizeX;
	public int TileGridSizeZ;
	
	public int TileXPos;
	public int TileZPos;	
	//-----------------------------------------------------------------
	
	
	
	void Update()
	{
		//=== --- Middle Clicked --- ===
		if(Input.GetMouseButton(0)) 
		{
		//	if (EventSystemManager.currentSystem.IsPointerOverEventSystemObject())		//dont do anything if the click is on UI elements.
		//	{}
		//	else
		//	{
				mClik_destPos = PlacerMovement.destinationPos;
				TileGridSizeX = Mathf.RoundToInt (mClik_destPos.x - mClik_origPos.x) + 1;
				TileGridSizeZ = Mathf.RoundToInt (mClik_destPos.z - mClik_origPos.z) + 1;
				
				if(mClik_destPos.x < mClik_origPos.x)
				{
					tempGridSizeX = Mathf.RoundToInt (mClik_destPos.x - mClik_origPos.x - 1);
					TileGridSizeX =	Mathf.Abs (tempGridSizeX);
					xIsNeg = true;
				}
				else	
					xIsNeg = false;
				
				if(mClik_destPos.z < mClik_origPos.z)
				{
					tempGridSizeZ = Mathf.RoundToInt (mClik_destPos.z - mClik_origPos.z - 1);	
					TileGridSizeZ = Mathf.Abs (tempGridSizeZ);
					zIsNeg = true;
				}
				else
					zIsNeg = false;
		//	}
		}
		
		
		//== Middle UP ==
		if(Input.GetMouseButtonUp(0))
		{
		//	if (EventSystemManager.currentSystem.IsPointerOverEventSystemObject())
		//	{}
		//	else
		//	{
				Destroy(instPlaceholder);
				if(mClik_init == true)
				{
					if(xIsNeg == true)
					{
						mClik_origPos.x = mClik_destPos.x;
					}
					if(zIsNeg == true)
					{
						mClik_origPos.z = mClik_destPos.z;
					}
					if(xIsNeg == true && zIsNeg == true)
					{
						mClik_origPos = mClik_destPos;
					}
					CreateTiles();
				}
				else
				{}	
				mClik_init = false;
		//	}
		}
		
	}
	
	
	void Clicked()
	{	
		mClik_init = true;
		mClik_origPos = transform.position;
		instPlaceholder = (GameObject)Instantiate(placeholder, transform.position ,transform.rotation);
	}
	

	void CreateTiles()
	{
		Transform parentCell;
		parentCell = (Transform)Instantiate(TileParent, mClik_origPos, transform.rotation);
		parentCell.name = "Eraser";
		
		for(int x = 0; x < TileGridSizeX; x++)
		{
			for(int z = 0; z < TileGridSizeZ; z++)
			{
				Transform kidCell;
				kidCell = (Transform)Instantiate(TileBlueprint, new Vector3(x+ mClik_origPos.x, 0, z+ mClik_origPos.z), TileBlueprint.transform.rotation);  
				kidCell.parent = parentCell;
				//kidCell.parent = transform;
			}
		}
		
	}
	

	
	
	
	
	
}
