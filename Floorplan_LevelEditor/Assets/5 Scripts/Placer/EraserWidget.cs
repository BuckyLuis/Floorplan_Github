using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EraserWidget : MonoBehaviour {

    [SerializeField] GameObject toolsController;
    UndoRedoManager undoRedoManagerScript;

    [SerializeField] GameObject databaseController;
    AreaTilesRegistry areaTilesRegistryScript;


    PlacerMovement placerMovementScript;



    bool tileSlotWasEmpty;

    Vector3 thePosition;
    string tempGoNameToErase;
    GameObject tempGoToErase;

    //----------- undo - redo -----------------------------------------

    List<GameObject> currGOList_forUndoRedo = new List<GameObject>();  //list to send to UndoRedoManager
    List<Geom_Base> currTBList_forUndoRedo = new List<Geom_Base>();

    //--------------- Placer thingys --------------------
    public GameObject placeholder;
    private GameObject instPlaceholder;

    bool tile0_entity1;   

    float gridSize = 2;

    Vector3 tileScale = new Vector3(2, 1, 2);
    Vector3 entityScale = new Vector3(1, 1, 1);


    //-------------- Placer Workings -------------------------------------------------
    Vector3 Click_origPos;
    int origPosX, origPosZ;
    Vector3 Click_destPos;
    bool Click_init = false;
    bool xIsNeg = false;
    bool zIsNeg = false;
    float tempPaintSizeX;
    float tempPaintSizeZ;
    float paintSizeX;
    float paintSizeZ;
    float TileXPos;
    float TileZPos;
    //----------- UI Ref ---------------
    [SerializeField]GameObject ui_tglShowEraserWidget;
    Toggle uiTgl_showEraserWidget;



    void Start() {
        toolsController = GameObject.FindGameObjectWithTag("ToolsController");
        undoRedoManagerScript = toolsController.GetComponent<UndoRedoManager>();

        databaseController = GameObject.FindGameObjectWithTag("DBController");
        areaTilesRegistryScript = databaseController.GetComponent<AreaTilesRegistry>();

        placerMovementScript = gameObject.GetComponent<PlacerMovement>();

        uiTgl_showEraserWidget = ui_tglShowEraserWidget.GetComponent<Toggle>();
        uiTgl_showEraserWidget.isOn = false;
        gameObject.SetActive(false);
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
      //  origPosX = Mathf.FloorToInt(Click_origPos.x);
      //  origPosZ = Mathf.FloorToInt(Click_origPos.z);
        instPlaceholder = (GameObject)Instantiate(placeholder, transform.position ,transform.rotation);
    }


    void PlacerCalcs() {
        Click_destPos = placerMovementScript.destinationPos;
        paintSizeX = Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) ) + 1;
        paintSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize) - (Click_origPos.z / gridSize) ) + 1;

        if(Click_destPos.x < Click_origPos.x) {
            tempPaintSizeX =  Mathf.RoundToInt ( (Click_destPos.x / gridSize) - (Click_origPos.x / gridSize) - 1);
            paintSizeX = Mathf.Abs (tempPaintSizeX);
            xIsNeg = true;
        }
        else    
            xIsNeg = false;

        if(Click_destPos.z < Click_origPos.z) {
            tempPaintSizeZ = Mathf.RoundToInt ( (Click_destPos.z / gridSize)- (Click_origPos.z / gridSize) - 1); 
            paintSizeZ = Mathf.Abs (tempPaintSizeZ);
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
            EraserWork();
        }
        Click_init = false;
    }

   

	void EraserWork () {
        currGOList_forUndoRedo.Clear();
        currTBList_forUndoRedo.Clear();

        for(int xL = 0; xL < paintSizeX; xL++) {        //xL , zL are local (relative to placerOrig) coords!
            for(int zL = 0; zL < paintSizeZ; zL++) {
                thePosition = new Vector3((xL * gridSize)+ Click_origPos.x, Click_origPos.y, (zL * gridSize)+ Click_origPos.z);
                Debug.Log("erase " + thePosition);

                if(areaTilesRegistryScript.Geom_PosUnoccupied(thePosition) == false) { 
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
        if(tileSlotWasEmpty = false) {
            undoRedoManagerScript.AddAStep(currGOList_forUndoRedo, currTBList_forUndoRedo, 1);

            foreach(GameObject goToErase in currGOList_forUndoRedo) {
                areaTilesRegistryScript.Geom_RemoveFromGrid(goToErase.GetComponent<WorldObjectInfo>().tileObject);
                Destroy(goToErase);
            }
        }
    }

}
