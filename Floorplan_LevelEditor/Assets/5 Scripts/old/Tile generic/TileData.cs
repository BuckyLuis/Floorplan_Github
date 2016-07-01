using UnityEngine;
using System.Collections;

public class TileData : MonoBehaviour 
{
	public int Tile_ID;

	[HideInInspector] public int IndexID;
    [HideInInspector] public int RoomIndex;
    [HideInInspector] public Vector3 Position;
	[HideInInspector] public string FloorName = null;
    [HideInInspector] public string WallsName = null;   
    [HideInInspector] public int WOrientFlag;


	void Start()
	{
		IndexID = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].IndexID;
        RoomIndex = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].RoomID;
        Position = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].Position;
		FloorName = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].FloorName;
        WallsName = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].WallsName;
        WOrientFlag = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].WOrientFlag;
    }       

}
