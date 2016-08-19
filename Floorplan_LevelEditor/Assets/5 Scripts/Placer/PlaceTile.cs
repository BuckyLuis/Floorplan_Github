﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlaceTile : MonoBehaviour {

    [SerializeField] GameObject AreaTileParent;
    [SerializeField] GameObject AreaEntityParent;

 
    //---------------- Tile_Base vars ----------------------------------
    Tile_Base tempTileBaseObject;
    public int roomID  {get; protected set;}
    int categoryIndex;
    int assetIndex;
    string materialName;
    float tileFacingRot;
  

    //----------- undo - redo -----------------------------------------
    [SerializeField] GameObject ToolsController;
    UndoRedoManager undoRedoManagerScript;

    List<GameObject> createdTilesListUR = new List<GameObject>();  //list to send to UndoRedoManager
    List<Tile_Base> tileBaseListUR = new List<Tile_Base>();


    //-------------- Public vars - defined In-Editor ----------------------------------

    public bool tile0_entity1;

    public GameObject placeholder;
    private GameObject instPlaceholder;

    [SerializeField] GameObject roomBelongingMarker;
    [SerializeField] GameObject worldObjectInfo;

    int tileGridSize = 2;
    int entityGridSize = 1;
    public int gridSize = 2;

    //-------------- Public vars - defined via Runtime GUI --------------------------------

    public float objectFacingYrot {get; protected set;}

    public Color roomColor {get; protected set;}
    public GameObject objToPlace_Prefab {get; protected set;}

    //--------------- Temp vars ----------------------------
    GameObject tempTileObject;
    GameObject tempBelongMarker;
    GameObject tempWorldObjectInfo;

    //-------------- Placer Workings -------------------------------------------------
    Vector3 Click_origPos;
    Vector3 Click_destPos;
    bool Click_init = false;
    bool xIsNeg = false;
    bool zIsNeg = false;
    int tempGridSizeX;
    int tempGridSizeZ;
    int TileGridSizeX;
    int TileGridSizeZ;
    int TileXPos;
    int TileZPos;
    //-----------------------------------------------------------------




    void Start() {
        undoRedoManagerScript = ToolsController.GetComponent<UndoRedoManager>();
    }


    void Update() {
        if(Input.GetMouseButton(0)) {
            PlacerCalcs();
        }
            
        if(Input.GetMouseButtonUp(0)) {
            PlacerWork(); 
        }
    }


    void Clicked() {   //called by ClickDetectMessageSender.cs
        Click_init = true;
        Click_origPos = transform.position;
        instPlaceholder = (GameObject)Instantiate(placeholder, transform.position ,transform.rotation);
    }


    void PlacerCalcs() {
        Click_destPos = PlacerMovement.destinationPos;
        TileGridSizeX = Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) ) + 1;
        TileGridSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize) - (Click_origPos.z / gridSize) ) + 1;

        if(Click_destPos.x < Click_origPos.x) {
            tempGridSizeX = Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) - 1);
            TileGridSizeX = Mathf.Abs (tempGridSizeX);
            xIsNeg = true;
        }
        else    
            xIsNeg = false;

        if(Click_destPos.z < Click_origPos.z) {
            tempGridSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize)- (Click_origPos.z / gridSize) - 1); 
            TileGridSizeZ = Mathf.Abs (tempGridSizeZ);
            zIsNeg = true;
        }
        else
            zIsNeg = false;
    }


    void PlacerWork() {
        Destroy(instPlaceholder);
        if(Click_init == true) {
            if(xIsNeg == true) {
                Click_origPos.x = Click_destPos.x;
            }
            if(zIsNeg == true) {
                Click_origPos.z = Click_destPos.z;
            }
            if(xIsNeg == true && zIsNeg == true) {
                Click_origPos = Click_destPos;
            }
            CreateTiles();
        }
        else {}  
        Click_init = false;
    }
        

    void CreateTiles() {
        createdTilesListUR.Clear();
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

    }


    //--------- Methods for GUI to process --------------

    public void AssignFacingYrot(float theTileFacingRot) {
        tileFacingRot = theTileFacingRot;
     /*   switch (tileFacingRot)
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
        }*/
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

  
  


}
