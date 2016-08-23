using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldObjectInstantiator : MonoBehaviour {


    [SerializeField] GameObject AreaTileParent;
    [SerializeField] GameObject AreaEntityParent;

    [SerializeField] GameObject roomBelongingMarker;
    [SerializeField] GameObject worldObjectInfo;


    //---------------- Tile_Base vars ----------------------------------
    Tile_Base tempTileBaseObject;

    public int roomID  {get; protected set;}
    public int categoryIndex {get; protected set;}
    public int assetIndex {get; protected set;}
    public string materialName {get; protected set;}
    public float tileFacingRot {get; protected set;}
    public Color roomColor {get; protected set;}

    //--------------- Temp Object vars ----------------------------
    GameObject tempTileObject;
    GameObject tempBelongMarker;
    GameObject tempWorldObjectInfo;



    public void CreateTiles(GameObject theObjectToPlace, Vector3 thePosition, out GameObject constructedGO, out Tile_Base constructedTileBase) {     //! @TODO: replace with a call to a new Class and Method that handles Tile Instantiation

        tempTileObject = (GameObject)Instantiate(theObjectToPlace, thePosition, Quaternion.Euler(theObjectToPlace.transform.rotation.x, tileFacingRot, theObjectToPlace.transform.rotation.z));
        tempTileObject.name = string.Format ("({0}, {1}, {2})", tempTileObject.transform.position.x, tempTileObject.transform.position.y, tempTileObject.transform.position.z );
        tempTileObject.transform.SetParent(AreaTileParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, Vector3.zero, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

   //     tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
   //     tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileBaseObject = new Tile_Base();
        tempTileBaseObject.RoomID = roomID;
        tempTileBaseObject.Position = thePosition;
        tempTileBaseObject.CategoryIndex = categoryIndex;
        tempTileBaseObject.AssetIndex = assetIndex;
        tempTileBaseObject.MaterialName = materialName;
        tempTileBaseObject.TileFacingRot = tileFacingRot;

        tempTileBaseObject.editorGoName = tempTileObject.name;
        tempTileBaseObject.theGameObjectPrefab = theObjectToPlace;

        tempTileObject.AddComponent<WorldObjectInfo>();
        tempTileObject.GetComponent<WorldObjectInfo>().tileObject = tempTileBaseObject;

        constructedGO = tempTileObject;
        constructedTileBase = tempTileBaseObject;
    }

    public void CreateTiles_UndoRedo(Tile_Base theTileBase, out GameObject constructedGO) {  
        
        roomID = theTileBase.RoomID;
        Vector3 thePosition = theTileBase.Position;
        categoryIndex = theTileBase.CategoryIndex;
        assetIndex = theTileBase.AssetIndex;
        materialName = theTileBase.MaterialName;
        tileFacingRot = theTileBase.TileFacingRot;

        tempTileObject = (GameObject)Instantiate(theTileBase.theGameObjectPrefab, thePosition, Quaternion.Euler(theTileBase.theGameObjectPrefab.transform.rotation.x, tileFacingRot, theTileBase.theGameObjectPrefab.transform.rotation.z));
        tempTileObject.name = theTileBase.editorGoName;


        tempTileObject.transform.SetParent(AreaTileParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, Vector3.zero, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

      //  tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
      //  tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileObject.AddComponent<WorldObjectInfo>();
        tempTileObject.GetComponent<WorldObjectInfo>().tileObject = theTileBase;

        constructedGO = tempTileObject;
    }
        

    public void AssignObjectRot(float theTileFacingRot) {
        tileFacingRot = theTileFacingRot;
    }

    public void AssignRoomID(int theRoomID) {
        roomID = theRoomID;
    }

    public void AssignRoomColor(Color theRoomColor) {
        roomColor = theRoomColor;
    }

    public void AssignIndicesAndMatName(int theCategoryIndex, int theAssetIndex, string theMaterialName)
    {
        categoryIndex = theCategoryIndex;
        assetIndex = theAssetIndex;
        materialName = theMaterialName;
    }

  
}
