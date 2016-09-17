using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TilePlacer : MonoBehaviour {

    [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    UndoRedoManager undoRedoManagerScript;

    [SerializeField] GameObject databaseController;
    AreaTilesRegistry areaTilesRegistryScript;

    [SerializeField] GameObject AssetsDBController;
    OptionsInfoDisplay optionsInfoScript;

    PlacerMovement placerMovementScript;



    public GameObject objToPlace_Prefab {get; protected set;}

    bool tileSlotWasEmpty;

    //------------------- comms with Instantiator ----------------------------
  
    Vector3 thePosition;

    //placing
    GameObject constructedGO;
    Geom_Base constructedGeomBase;
    Entity_Base constructedEntity;

    //erasing
    string tempGoNameToErase;
    GameObject tempGoToErase;


    //----------- undo - redo -----------------------------------------

    List<GameObject> currGOList_forUndoRedo = new List<GameObject>();  //list to send to UndoRedoManager
    List<Geom_Base> currTBList_forUndoRedo = new List<Geom_Base>();
    List<Entity_Base> currENTList_forUndoRedo = new List<Entity_Base>();

    //--------------- Placer thingys --------------------
    public GameObject placeholder_Place;
    public GameObject placeholder_Erase;
    private GameObject instPlaceholder;

 //   bool geom0_entity1;   

    float gridSize = 2;

    Vector3 geomScale = new Vector3(2, 1, 2);
    Vector3 entityScale = new Vector3(1, 1, 1);

    //-------------- Placer Workings -------------------------------------------------
    Vector3 click_origPos;
    Vector3 click_destPos;

    bool? click0_Middle1;

    bool xIsNeg = false;
    bool zIsNeg = false;
    float tempPaintSizeX;
    float tempPaintSizeZ;
    float paintSizeX;
    float paintSizeZ;
    float TileXPos;
    float TileZPos;




    void Start() {
        toolsController = GameObject.FindGameObjectWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();
        undoRedoManagerScript = toolsController.GetComponent<UndoRedoManager>();
        optionsInfoScript = AssetsDBController.GetComponent<OptionsInfoDisplay>();

        databaseController = GameObject.FindGameObjectWithTag("DBController");
        areaTilesRegistryScript = databaseController.GetComponent<AreaTilesRegistry>();

        placerMovementScript = GetComponent<PlacerMovement>();
        gameObject.SetActive(false);
    }

    void Update() {

        if(optionsInfoScript.geom0_entity1 == false) {
            gameObject.transform.localScale = geomScale;
            gridSize = 2;
        }
        else {
            gameObject.transform.localScale = entityScale;
            gridSize = 1;
        }

        if(Input.GetMouseButtonUp(0)) {
            if(click0_Middle1 == false)
                PlacerCalcs();
                PlacerWork(); 
        }
        if(Input.GetMouseButtonUp(2)) {
            if(click0_Middle1 == true)
                PlacerCalcs();
                PlacerWork(); 
        }
    }

    void Clicked() {   //called by ClickDetectMessageSender.cs
        if( optionsInfoScript.theTileToPlace != null)
            objToPlace_Prefab = optionsInfoScript.theTileToPlace;
        
        click0_Middle1 = false;
        click_origPos = transform.position;
        instPlaceholder = (GameObject)Instantiate(placeholder_Place, transform.position ,transform.rotation); 
    }
        
    void MiddleClicked() {
        click0_Middle1 = true;
        click_origPos = transform.position;
        instPlaceholder = (GameObject)Instantiate(placeholder_Erase, transform.position ,transform.rotation);
    }

    void RightClicked() {
        gameObject.SetActive(false);
    }


    void PlacerCalcs() {
        click_destPos = placerMovementScript.destinationPos;
        paintSizeX = Mathf.RoundToInt ( (click_destPos.x / gridSize) - (click_origPos.x / gridSize) ) + 1; 
        paintSizeZ = Mathf.RoundToInt ( (click_destPos.z / gridSize) - (click_origPos.z / gridSize) ) + 1;

        if(click_destPos.x < click_origPos.x) {
            tempPaintSizeX = Mathf.RoundToInt ( (click_destPos.x / gridSize) - (click_origPos.x / gridSize) - 1); 
            paintSizeX = Mathf.Abs (tempPaintSizeX);
            xIsNeg = true;
        }
        else    
            xIsNeg = false;

        if(click_destPos.z < click_origPos.z) {
            tempPaintSizeZ =  Mathf.RoundToInt ( (click_destPos.z / gridSize)- (click_origPos.z / gridSize) - 1);
            paintSizeZ = Mathf.Abs (tempPaintSizeZ);
            zIsNeg = true;
        }
        else
            zIsNeg = false;
    }


    void PlacerWork() {
        Destroy(instPlaceholder);
        if(click0_Middle1 != null) {
            if(xIsNeg == true) {
                click_origPos.x = click_destPos.x;
            }
            if(zIsNeg == true) {
                click_origPos.z = click_destPos.z;
            }
            if(xIsNeg == true && zIsNeg == true) {
                click_origPos = click_destPos;
            }
    
            if(click0_Middle1 == false) {
                if(optionsInfoScript.geom0_entity1 == false) {
                    CallGeomCreation();
                }
                else {
                    CallEntityCreation();
                }
            }
            else if(click0_Middle1 == true) {
                EraserWork();
            }
        }
        click0_Middle1 = null;
    }
        


    void CallGeomCreation() {     
        currGOList_forUndoRedo.Clear();
        currTBList_forUndoRedo.Clear();
        currENTList_forUndoRedo.Clear();

        for(int xL = 0; xL < paintSizeX; xL++) {        //xL , zL are local (relative to placerOrig) coords!
            for(int zL = 0; zL < paintSizeZ; zL++) {
                thePosition = new Vector3((xL * gridSize)+ click_origPos.x, click_origPos.y, (zL * gridSize)+ click_origPos.z );
                Debug.Log("place " + thePosition);

                if(areaTilesRegistryScript.Geom_PosUnoccupied(thePosition) == true) {
                    objInstantiatorScript.CreateGeoms(objToPlace_Prefab, thePosition, out constructedGO, out constructedGeomBase);
                    areaTilesRegistryScript.Geom_AddToGrid(constructedGeomBase);

                    currGOList_forUndoRedo.Add(constructedGO); //undoRedoList
                    currTBList_forUndoRedo.Add(constructedGeomBase);
                }
            }
        }
        if(currGOList_forUndoRedo.Count > 0) {
            undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currTBList_forUndoRedo, 10);
        }
    }

    void CallEntityCreation() {     
        currGOList_forUndoRedo.Clear();
        currTBList_forUndoRedo.Clear();
        currENTList_forUndoRedo.Clear();

        for(int xL = 0; xL < paintSizeX; xL++) {        //xL , zL are local (relative to placerOrig) coords!
            for(int zL = 0; zL < paintSizeZ; zL++) {
                thePosition = new Vector3((xL * gridSize)+ click_origPos.x, click_origPos.y, (zL * gridSize)+ click_origPos.z );
                Debug.Log("place " + thePosition);

                if(areaTilesRegistryScript.Entity_PosUnoccupied(thePosition) == true) {
                    objInstantiatorScript.CreateEntities(objToPlace_Prefab, thePosition, out constructedGO, out constructedEntity);
                    areaTilesRegistryScript.Entity_AddToGrid(constructedEntity);

                    currGOList_forUndoRedo.Add(constructedGO); //undoRedoList
                    currENTList_forUndoRedo.Add(constructedEntity);
                }
            }
        }
        if(currGOList_forUndoRedo.Count > 0) {
            undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currTBList_forUndoRedo, 20);
        }
    }


    void EraserWork() {
        currGOList_forUndoRedo.Clear();
        currTBList_forUndoRedo.Clear();
        currENTList_forUndoRedo.Clear();

        for(int xL = 0; xL < paintSizeX; xL++) {        //xL , zL are local (relative to placerOrig) coords!
            for(int zL = 0; zL < paintSizeZ; zL++) {
                thePosition = new Vector3((xL * gridSize)+ click_origPos.x, click_origPos.y, (zL * gridSize)+ click_origPos.z);
                Debug.Log("erase " + thePosition);

                if(optionsInfoScript.geom0_entity1 == false) {                                                                          //erase geom
                    if(areaTilesRegistryScript.Geom_PosUnoccupied(thePosition) == false) { 
                        tempGoNameToErase = string.Format("G: ({0}, {1}, {2})", thePosition.x, thePosition.y, thePosition.z );
                        tempGoToErase = GameObject.Find(tempGoNameToErase);

                        currGOList_forUndoRedo.Add(tempGoToErase);
                        currTBList_forUndoRedo.Add(tempGoToErase.GetComponent<GeomObjectInfo>().geomObject);
                    }

                }
                else {
                    if(areaTilesRegistryScript.Entity_PosUnoccupied(thePosition) == false) {                                             //erase entity
                        tempGoNameToErase = string.Format("E: ({0}, {1}, {2})", thePosition.x, thePosition.y, thePosition.z );
                        tempGoToErase = GameObject.Find(tempGoNameToErase);

                        currGOList_forUndoRedo.Add(tempGoToErase);
                        currENTList_forUndoRedo.Add(tempGoToErase.GetComponent<EntityObjectInfo>().entityObject);
                    }
                }
            }
        }
        if(currGOList_forUndoRedo.Count > 0) {
            if(optionsInfoScript.geom0_entity1 == false) {                                                                         //erase geom
                undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currTBList_forUndoRedo, 11);

                foreach(GameObject goToErase in currGOList_forUndoRedo) {
                    areaTilesRegistryScript.Geom_RemoveFromGrid(goToErase.GetComponent<GeomObjectInfo>().geomObject);
                    Destroy(goToErase);
                }
            }
            else {                                                                                                              //erase entity
                undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currENTList_forUndoRedo, 21);

                foreach(GameObject goToErase in currGOList_forUndoRedo) {
                    areaTilesRegistryScript.Entity_RemoveFromGrid(goToErase.GetComponent<EntityObjectInfo>().entityObject);
                    Destroy(goToErase);
                }
            }

        }
    }

       
/*
    public void GeomPlacementMode(GameObject theGeomToPlace) {
/*        
        geom0_entity1 = false;
        placerMovementScript.geom0_entity1 = false;
        gameObject.transform.localScale = tileScale;
        gridSize = 2;

        objToPlace_Prefab = theGeomToPlace;
    }

    public void EntityPlacementMode(GameObject theEntityToPlace) {
/*        
        geom0_entity1 = true;
        placerMovementScript.geom0_entity1 = true;
        gameObject.transform.localScale = entityScale;
        gridSize = 1;

        objToPlace_Prefab = theEntityToPlace;
    }
*/

}



/*
    void ReplacerWork() {     
        currGOList_forUndoRedo.Clear();
        currTBList_forUndoRedo.Clear();

        for(int xL = 0; xL < paintSizeX; xL++) {        //xL , zL are local (relative to placerOrig) coords!
            for(int zL = 0; zL < paintSizeZ; zL++) {
                thePosition = new Vector3((xL * gridSize)+ click_origPos.x, click_origPos.y, (zL * gridSize)+ click_origPos.z);
                Debug.Log("erase " + thePosition);

                if(areaTilesRegistryScript.Tile_PosUnoccupied(thePosition) == false) { 
                    tileSlotWasEmpty = false;
                    tempGoNameToErase = string.Format("({0}, {1}, {2})", thePosition.x, thePosition.y, thePosition.z );
                    tempGoToErase = GameObject.Find(tempGoNameToErase);

                    currGOList_forUndoRedo.Add(tempGoToErase);
                    currTBList_forUndoRedo.Add(tempGoToErase.GetComponent<WorldObjectInfo>().tileObject);
                }
                else {
                    tileSlotWasEmpty = true;
                }
            }
        }
        if(tileSlotWasEmpty == false) {
            undoRedoManagerScript.ReplaceOp_OldObjs(currGOList_forUndoRedo, currTBList_forUndoRedo, 2);
  
            foreach(GameObject goToErase in currGOList_forUndoRedo) {
                areaTilesRegistryScript.Tile_RemoveFromGrid(goToErase.GetComponent<WorldObjectInfo>().tileObject);        //erase
                Destroy(goToErase);

                objInstantiatorScript.CreateTiles(objToPlace_Prefab, thePosition, out constructedGO, out constructedTileBase); //create new
                areaTilesRegistryScript.Tile_AddToGrid(constructedTileBase);

                currGOList_forUndoRedo.Add(constructedGO); //undoRedoList
                currTBList_forUndoRedo.Add(constructedTileBase);
            }
            undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currTBList_forUndoRedo, 2);
        }
    }
*/


    //-- trash - refactor --

  /*      createdTilesListUR.Clear();
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


                createdTilesListUR.Add(tempTileObject); //undoRedoList
                tileBaseListUR.Add(tempTileBaseObject);
            }
        }
        undoRedoManagerScript.AddAStep(createdTilesListUR, tileBaseListUR);
*/
 //   }


    //--------- Methods for GUI to process --------------
/*
    public void AssignFacingYrot(float theTileFacingRot) {
        tileFacingRot = theTileFacingRot;
        switch (tileFacingRot)
        {
            case 0:
                objectFacingYrot = 0;
                break;
            case 1:
                objectFacingYrot = 90;
                break;
            case 2:
                objectFacingYrot = 180;
                break;
            case 3:
                objectFacingYrot = 270;
                break;
        }
    }
*/

/*    public void AssignRoomID(int theRoomID) {
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
             
    public void AssignTileToBePlaced(GameObject theTileToPlace) {
        tile0_entity1 = false;
        gridSize = tileGridSize;

        objToPlace_Prefab = theTileToPlace;
    }

    public void AssignEntityToBePlaced(GameObject theEntityToPlace) {
        tile0_entity1 = true;
        gridSize = entityGridSize;
        objToPlace_Prefab = theEntityToPlace;
    }

  */
  



