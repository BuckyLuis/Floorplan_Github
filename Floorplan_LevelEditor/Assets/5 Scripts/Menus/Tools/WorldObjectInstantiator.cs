using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldObjectInstantiator : MonoBehaviour {

    [SerializeField] GameObject AssetsDbController;
    AssetsViewerAssetManagement theAssetManagerScript;
    TexturesViewerTexAtlasManagement theTexAtlasManagerScript;

    [SerializeField] GameObject AreaGeomParent;
    [SerializeField] GameObject AreaEntityParent;

    [SerializeField] GameObject roomBelongingMarker;
    [SerializeField] GameObject worldObjectInfo;


    //---------------- Tile_Base vars ----------------------------------
    Geom_Base tempGeomBaseObject;
    Entity_Base tempEntityBaseObject;

    public string roomID  {get; protected set;}
    public int typeIndex {get; protected set;}
    public int categoryIndex {get; protected set;}
    public int assetIndex {get; protected set;}
    public int texAtlasIndex {get; protected set;}
    public float tileFacingRot {get; protected set;}
    public Color roomColor {get; protected set;}

    //--------------- Temp Object vars ----------------------------
    GameObject tempTileObject;
    GameObject tempBelongMarker;
    GameObject tempWorldObjectInfo;

    GameObject tempWorldGOPrefab;
    Material setAsideGOMaterial;

    Vector3 belongMarkerPos = new Vector3(0, -0.2f, 0);


    void Start() {
        AssetsDbController = GameObject.FindGameObjectWithTag("AssetsDBController");
        theAssetManagerScript = AssetsDbController.GetComponent<AssetsViewerAssetManagement>();
        theTexAtlasManagerScript = AssetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
    }



    public void CreateGeoms(GameObject theObjectToPlace, Vector3 thePosition, out GameObject constructedGO, out Geom_Base constructedGeomBase) {     //! @TODO: replace with a call to a new Class and Method that handles Tile Instantiation

        tempTileObject = (GameObject)Instantiate(theObjectToPlace, thePosition, Quaternion.Euler(theObjectToPlace.transform.rotation.x, tileFacingRot, theObjectToPlace.transform.rotation.z));
        tempTileObject.name = string.Format ("G: ({0}, {1}, {2})", tempTileObject.transform.position.x, tempTileObject.transform.position.y, tempTileObject.transform.position.z );
        tempTileObject.transform.SetParent(AreaGeomParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

   //     tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
   //     tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempGeomBaseObject = new Geom_Base();
        tempGeomBaseObject.RoomID = roomID;
        tempGeomBaseObject.roomColor = roomColor;
        tempGeomBaseObject.Position = thePosition;
        tempGeomBaseObject.TypeIndex = typeIndex;
        tempGeomBaseObject.CategoryIndex = categoryIndex;
        tempGeomBaseObject.AssetIndex = assetIndex;
        tempGeomBaseObject.TexAtlasIndex = texAtlasIndex;
        tempGeomBaseObject.TileFacingRot = tileFacingRot;

        tempGeomBaseObject.editorGoName = tempTileObject.name;
        tempGeomBaseObject.theGameObjectPrefab = theObjectToPlace;

        tempTileObject.AddComponent<GeomObjectInfo>();
        tempTileObject.GetComponent<GeomObjectInfo>().geomObject = tempGeomBaseObject;

        constructedGO = tempTileObject;
        constructedGeomBase = tempGeomBaseObject;
    }

    public void CreateGeoms_UndoRedo(Geom_Base theGeomBase, out GameObject constructedGO) {  
        
        roomID = theGeomBase.RoomID;
        roomColor = theGeomBase.roomColor;
        Vector3 thePosition = theGeomBase.Position;
        typeIndex = theGeomBase.TypeIndex;
        categoryIndex = theGeomBase.CategoryIndex;
        assetIndex = theGeomBase.AssetIndex;
        texAtlasIndex = theGeomBase.TexAtlasIndex;
        tileFacingRot = theGeomBase.TileFacingRot;

        tempTileObject = (GameObject)Instantiate(theGeomBase.theGameObjectPrefab, thePosition, Quaternion.Euler(theGeomBase.theGameObjectPrefab.transform.rotation.x, tileFacingRot, theGeomBase.theGameObjectPrefab.transform.rotation.z));
        tempTileObject.name = theGeomBase.editorGoName;


        tempTileObject.transform.SetParent(AreaGeomParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

      //  tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
      //  tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileObject.AddComponent<GeomObjectInfo>();
        tempTileObject.GetComponent<GeomObjectInfo>().geomObject = theGeomBase;

        constructedGO = tempTileObject;
    }


    public void CreateGeoms_AreaLoad(Geom_Base theGeomBase) {
        roomID = theGeomBase.RoomID;
        roomColor = theGeomBase.roomColor;
        Vector3 thePosition = theGeomBase.Position;
        typeIndex = theGeomBase.TypeIndex;
        categoryIndex = theGeomBase.CategoryIndex;
        assetIndex = theGeomBase.AssetIndex;
        texAtlasIndex = theGeomBase.TexAtlasIndex;
        tileFacingRot = theGeomBase.TileFacingRot;

        tempWorldGOPrefab = RetrieveGOFromIndices(typeIndex, categoryIndex, assetIndex);

        tempTileObject = (GameObject)Instantiate(tempWorldGOPrefab, thePosition, Quaternion.Euler(tempWorldGOPrefab.transform.rotation.x, tileFacingRot, tempWorldGOPrefab.transform.rotation.z));
        tempTileObject.name = theGeomBase.editorGoName;
        tempTileObject.GetComponent<Renderer>().material = RetrieveMatFromIndices(typeIndex, texAtlasIndex);


        tempTileObject.transform.SetParent(AreaGeomParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

        //  tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
        //  tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileObject.AddComponent<GeomObjectInfo>();
        tempTileObject.GetComponent<GeomObjectInfo>().geomObject = theGeomBase;
    }





    public void CreateEntities(GameObject theObjectToPlace, Vector3 thePosition, out GameObject constructedGO, out Entity_Base constructedEntityBase) {     //! @TODO: replace with a call to a new Class and Method that handles Tile Instantiation
        tempTileObject = (GameObject)Instantiate(theObjectToPlace, thePosition, Quaternion.Euler(theObjectToPlace.transform.rotation.x, tileFacingRot, theObjectToPlace.transform.rotation.z));
        tempTileObject.name = string.Format ("E: ({0}, {1}, {2})", tempTileObject.transform.position.x, tempTileObject.transform.position.y, tempTileObject.transform.position.z );
        tempTileObject.transform.SetParent(AreaEntityParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

        //     tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
        //     tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempEntityBaseObject = new Entity_Base();
        tempEntityBaseObject.RoomID = roomID;
        tempEntityBaseObject.roomColor = roomColor;
        tempEntityBaseObject.Position = thePosition;
        tempEntityBaseObject.TypeIndex = typeIndex;
        tempEntityBaseObject.CategoryIndex = categoryIndex;
        tempEntityBaseObject.AssetIndex = assetIndex;
        tempEntityBaseObject.TexAtlasIndex = texAtlasIndex;
        tempEntityBaseObject.TileFacingRot = tileFacingRot;

        tempEntityBaseObject.editorGoName = tempTileObject.name;
        tempEntityBaseObject.theGameObjectPrefab = theObjectToPlace;

        tempTileObject.AddComponent<EntityObjectInfo>();
        tempTileObject.GetComponent<EntityObjectInfo>().entityObject = tempEntityBaseObject;

        constructedGO = tempTileObject;
        constructedEntityBase = tempEntityBaseObject;
    }

    public void CreateEntities_UndoRedo(Entity_Base theEntityBase, out GameObject constructedGO) {  
        roomID = theEntityBase.RoomID;
        roomColor = theEntityBase.roomColor;
        Vector3 thePosition = theEntityBase.Position;
        typeIndex = theEntityBase.TypeIndex;
        categoryIndex = theEntityBase.CategoryIndex;
        assetIndex = theEntityBase.AssetIndex;
        texAtlasIndex = theEntityBase.TexAtlasIndex;
        tileFacingRot = theEntityBase.TileFacingRot;

        tempTileObject = (GameObject)Instantiate(theEntityBase.theGameObjectPrefab, thePosition, Quaternion.Euler(theEntityBase.theGameObjectPrefab.transform.rotation.x, tileFacingRot, theEntityBase.theGameObjectPrefab.transform.rotation.z));
        tempTileObject.name = theEntityBase.editorGoName;

        tempTileObject.transform.SetParent(AreaEntityParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

        //  tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
        //  tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileObject.AddComponent<EntityObjectInfo>();
        tempTileObject.GetComponent<EntityObjectInfo>().entityObject = theEntityBase;

        constructedGO = tempTileObject;
    }

    public void CreateEntities_AreaLoad(Entity_Base theEntityBase) {
        roomID = theEntityBase.RoomID;
        roomColor = theEntityBase.roomColor;
        Vector3 thePosition = theEntityBase.Position;
        typeIndex = theEntityBase.TypeIndex;
        categoryIndex = theEntityBase.CategoryIndex;
        assetIndex = theEntityBase.AssetIndex;
        texAtlasIndex = theEntityBase.TexAtlasIndex;
        tileFacingRot = theEntityBase.TileFacingRot;

        tempWorldGOPrefab = RetrieveGOFromIndices(typeIndex, categoryIndex, assetIndex);

        tempTileObject = (GameObject)Instantiate(tempWorldGOPrefab, thePosition, Quaternion.Euler(tempWorldGOPrefab.transform.rotation.x, tileFacingRot, tempWorldGOPrefab.transform.rotation.z));
        tempTileObject.name = theEntityBase.editorGoName;
        setAsideGOMaterial = tempTileObject.GetComponent<Renderer>().material;      //if the Entity is a Trigger, we want it to keep its original Material.
        tempTileObject.GetComponent<Renderer>().material = RetrieveMatFromIndices(typeIndex, texAtlasIndex);


        tempTileObject.transform.SetParent(AreaEntityParent.transform, true);

        tempBelongMarker = (GameObject)Instantiate(roomBelongingMarker, belongMarkerPos, Quaternion.identity);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        tempBelongMarker.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        tempBelongMarker.transform.SetParent(tempTileObject.transform, false);

        //  tempWorldObjectInfo = (GameObject)Instantiate(worldObjectInfo, Vector3.zero, Quaternion.identity);
        //  tempWorldObjectInfo.transform.SetParent(tempTileObject.transform, false);

        tempTileObject.AddComponent<EntityObjectInfo>();
        tempTileObject.GetComponent<EntityObjectInfo>().entityObject = theEntityBase;
    }

        

    public void AssignObjectRot(float theTileFacingRot) {
        tileFacingRot = theTileFacingRot;
    }

    public void AssignRoomID(string theRoomID) {
        roomID = theRoomID;
    }

    public void AssignRoomColor(Color theRoomColor) {
        roomColor = theRoomColor;
    }

    public void AssignIndices(int theTypeIndex ,int theCategoryIndex, int theAssetIndex, int theTexAtlasIndex)
    {
        typeIndex = theTypeIndex;
        categoryIndex = theCategoryIndex;
        assetIndex = theAssetIndex;
        texAtlasIndex = theTexAtlasIndex;
    }



    GameObject RetrieveGOFromIndices(int theTypeIndex, int theCategoryIndex, int theAssetIndex) {
        string tempLookupKey = theCategoryIndex + "|" + theAssetIndex;

        switch(theTypeIndex) {
            case 1:
                foreach (KeyValuePair<string, GameObject> floorEntry in theAssetManagerScript.assetsEntriesDict_Floors) {
                    if(SplitDictKey_GetCompareKey(floorEntry) == tempLookupKey) {
                        return floorEntry.Value.GetComponent<AssetsViewerEntry_Floors>().assetWorldObject;
                    }
                }
                break;
            case 2:
                foreach (KeyValuePair<string, GameObject> wallEntry in theAssetManagerScript.assetsEntriesDict_Walls) {
                    if(SplitDictKey_GetCompareKey(wallEntry) == tempLookupKey) {
                        return wallEntry.Value.GetComponent<AssetsViewerEntry_Walls>().assetWorldObject;
                    }
                }
                break;
            case 3:
                foreach (KeyValuePair<string, GameObject> doodadEntry in theAssetManagerScript.assetsEntriesDict_Doodads) {
                    if(SplitDictKey_GetCompareKey(doodadEntry) == tempLookupKey) {
                        return doodadEntry.Value.GetComponent<AssetsViewerEntry_Doodads>().assetWorldObject;
                    }
                }
                break;
            case 4:
                foreach (KeyValuePair<string, GameObject> propEntry in theAssetManagerScript.assetsEntriesDict_Props) {
                    if(SplitDictKey_GetCompareKey(propEntry) == tempLookupKey) {
                        return propEntry.Value.GetComponent<AssetsViewerEntry_Props>().assetWorldObject;
                    }
                }
                break;
            case 5:
                foreach (KeyValuePair<string, GameObject> actorEntry in theAssetManagerScript.assetsEntriesDict_Actors) {
                    if(SplitDictKey_GetCompareKey(actorEntry) == tempLookupKey) {
                        return actorEntry.Value.GetComponent<AssetsViewerEntry_Actors>().assetWorldObject;
                    }
                }
                break;
            case 6:
                foreach (KeyValuePair<string, GameObject> triggerEntry in theAssetManagerScript.assetsEntriesDict_Triggers) {
                    if(SplitDictKey_GetCompareKey(triggerEntry) == tempLookupKey) {
                        return triggerEntry.Value.GetComponent<AssetsViewerEntry_Triggers>().assetWorldObject;
                    }
                }
                break;
        }
        DebugConsole.Log("<b>Loading of an Area Object Failed!</b> - WorldObjectInstantiator.RetrieveGOFromIndices = c: " + theCategoryIndex + " a: " + theAssetIndex, "error");
        return null;
    }

    Material RetrieveMatFromIndices(int theTypeIndex, int theTexAtlasIndex) {
        switch (theTypeIndex)
        {
            case 1:
                return theTexAtlasManagerScript.texAtlasList_Geoms[theTexAtlasIndex].texAtlasMatObject;
                break;
            case 2:
                goto case 1;
                break;
            case 3: 
                return theTexAtlasManagerScript.texAtlasList_Doodads[theTexAtlasIndex].texAtlasMatObject;
                break;
            case 4:
                return theTexAtlasManagerScript.texAtlasList_Props[theTexAtlasIndex].texAtlasMatObject;
                break;
            case 5:
                return theTexAtlasManagerScript.texAtlasList_Actors[theTexAtlasIndex].texAtlasMatObject;
                break;
            case 6:
                return setAsideGOMaterial;   //if the Entity is a Trigger, we want it to keep its original Material.
                break;
        }
        Debug.LogError("WorldObjectInstantiator.cs/RetrieveMatFromIndices failed to be supplied with a correct TypeIndex for the queried Object!");
        return null;
    }
   

    string SplitDictKey_GetCompareKey(KeyValuePair<string, GameObject> entryToSplit) {
        string[] tempStringArray = entryToSplit.Key.Split('|');
        string keyToCompare = tempStringArray[0] + "|" + tempStringArray[1];
        return keyToCompare;
    }   
  
}
