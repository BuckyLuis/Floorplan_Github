using UnityEngine;
using System.Collections;

public class TileData : MonoBehaviour 
{
	public int Tile_ID;

	[HideInInspector] public int IndexID;
    [HideInInspector] public int RoomIndex;
    [HideInInspector] public Vector3 Position;
    [HideInInspector] public int FloorIndex;
    [HideInInspector] public int WallsIndex;   
    [HideInInspector] public int WOrientFlag;


	void Start()
	{
		IndexID = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].IndexID;
        RoomIndex = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].RoomID;
        Position = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].Position;
        FloorIndex = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].FloorIndex;
        WallsIndex = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].WallsIndex;
        WOrientFlag = Tile_ReadWrite.Tiles_DataObject.tiles[Tile_ID].WOrientFlag;
    }       

}
