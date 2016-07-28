using UnityEngine;
using System.Collections;

public class TileObject : MonoBehaviour {
//============= Loaded Room Data =========
    public Tile_Base ThisTile { get; protected set; }
//========================================

    public int ThisTilesRoomID { get; protected set; }

    public Vector3 ThisPosition { get; protected set; }
    public string ThisFloor { get; protected set; }
    public string ThisWalls { get; protected set; }
    public int ThisWOrientFlag { get; protected set; }
	

    public void AlterTileRoomID() {
        
    }

    public void AlterTilePos() {
        
    }

    public void AlterTileFloor() {
        
    }

    public void AlterTileWalls() {
        
    }

    public void SetTileWallOrientation() {
        
    }



    public void SaveTileDataToXml() {

    }
}
