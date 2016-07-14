using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlaceTile : MonoBehaviour {

    //-------------- Public vars - defined In-Editor -----------------------------------
    public Transform tileToBePlaced;
   // public Transform TileParent;

    public GameObject placeholder;
    private GameObject instPlaceholder;

    public int gridSize = 1;

    //-------------- Public vars - defined via Runtime GUI --------------------------------


    public int roomNum  {get; protected set;}
    public Color roomCol {get; protected set;}




    //--------------- Temp vars ----------------------------
    Transform parentCell;
    Transform kidCell;

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
      //  parentCell = (Transform)Instantiate(TileParent, Click_origPos, transform.rotation);
      //  parentCell.name = "Room: " + roomNum.ToString();

        for(int xL = 0; xL < TileGridSizeX; xL++) {                 //xL , zL are local (relative to parentCell) coords!
            for(int zL = 0; zL < TileGridSizeZ; zL++) {
                kidCell = (Transform) Instantiate(tileToBePlaced, new Vector3((xL * gridSize)+ Click_origPos.x, 0, (zL * gridSize)+ Click_origPos.z), tileToBePlaced.transform.rotation);  
                kidCell.name = string.Format ("R: ({0},0,{1}) / G: ({2},{3},{4})", xL, zL, kidCell.transform.position.x, kidCell.transform.position.y, kidCell.transform.position.z);
                kidCell.GetChild(0).GetComponent<Renderer>().material.color = roomCol;
                kidCell.parent = parentCell;
            }
        }

    }


    //--------- Methods for GUI to process --------------



}
