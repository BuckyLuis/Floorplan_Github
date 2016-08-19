using UnityEngine;
using System.Collections;

public class GenerateTiles : MonoBehaviour {
/*
	void CreateTiles () {
        for(int xL = 0; xL < TileGridSizeX; xL++) {                 //xL , zL are local (relative to parentCell) coords!
            for(int zL = 0; zL < TileGridSizeZ; zL++) {
                Vector3 thePosition = new Vector3((xL * gridSize)+ Click_origPos.x, 0, (zL * gridSize)+ Click_origPos.z);
                tempTileObject = (GameObject)Instantiate(objToPlace_Prefab, thePosition, Quaternion.Euler(objToPlace_Prefab.transform.rotation.x, objectFacingYrot, objToPlace_Prefab.transform.rotation.z));

                tempTileObject.name = string.Format ("Rm: {0} / G: ({1},{2},{3}) {4}°", roomID, tempTileObject.transform.position.x, tempTileObject.transform.position.y, tempTileObject.transform.position.z, objectFacingYrot);

                tempTileObject.transform.SetParent(AreaTileParent.transform, true);

                tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, Vector3.zero, Quaternion.identity);
                tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
                tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
                tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

                tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
                tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

                tempTileBaseObject = new Tile_Base();
                tempTileBaseObject.RoomID = roomID;
                tempTileBaseObject.Position = thePosition;
                tempTileBaseObject.CategoryIndex = categoryIndex;
                tempTileBaseObject.AssetIndex = assetIndex;
                tempTileBaseObject.MaterialName = materialName;
                tempTileBaseObject.TileFacingRot = tileFacingRot;

                tempTileBaseObject.editorGoName = tempTileObject.name;
                tempTileBaseObject.theGameObjectPrefab = objToPlace_Prefab;

                tempWorldObjectInfo.GetComponent<WorldObjectInfo>().tileObject = tempTileBaseObject;
            }
        }
	}
*/
}
