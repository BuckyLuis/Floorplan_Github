using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;
using UnityEngine.UI;

public class UndoRedoManager : MonoBehaviour {

    WorldObjectInstantiator objInstantiatorScript;

    [SerializeField] GameObject databaseController;
    AreaTilesRegistry areaTilesRegistryScript;

   
    public int maxSteps = 16;

    MaxStack<UndoRedoOperation> UndoStack;
    MaxStack<UndoRedoOperation> RedoStack;

    UndoRedoOperation operationAssignment;

    UndoRedoOperation currentOperation;
    List<GameObject> currentGOList;
    List<Tile_Base> currentTileBaseList;

    GameObject constructedGO;

    //---------- UI Refs --------------

    [SerializeField] GameObject ui_undoButton;
    [SerializeField] GameObject ui_redoButton;
    Button uiBtn_undoButton;
    Button uiBtn_redoButton;





    void Awake () {
        UndoStack = new MaxStack<UndoRedoOperation>(maxSteps);
        RedoStack = new MaxStack<UndoRedoOperation>(maxSteps);
    }

    void Start() {
        objInstantiatorScript = GetComponent<WorldObjectInstantiator>();

        databaseController = GameObject.FindGameObjectWithTag("DBController");
        areaTilesRegistryScript = databaseController.GetComponent<AreaTilesRegistry>();

        uiBtn_undoButton = ui_undoButton.GetComponent<Button>();
        uiBtn_redoButton = ui_redoButton.GetComponent<Button>();
    }
	

    void Update () {
        if( (InputManager.GetButton("Ctrl") && InputManager.GetButtonDown("Z")) ) {    //Undo
            Undo();    
        }

        if( (InputManager.GetButton("Ctrl") && InputManager.GetButtonDown("Y")) ) {    //Redo
            Redo();
        }
    }


    public void Undo() {
        currentOperation = UndoStack.Pop();
      
        switch (currentOperation.operationFlag)
        {
            case 0:
                RedoStack.Push(currentOperation);
                ObjectsDeletion();
                break;
            case 1:
                ObjectsRecreation();
               // Undo_Erase_ObjectsRecreation();
                RedoStack.Push(currentOperation);
                break;
        }
     


        //---- ui ---
        uiBtn_redoButton.interactable = true;
        if(UndoStack.Count > 0) {
            uiBtn_undoButton.interactable = true;
        }
        else {
            uiBtn_undoButton.interactable = false;
        }
    }

    public void Redo() {
        currentOperation = RedoStack.Pop();

        switch (currentOperation.operationFlag)
        {
            case 0:
                ObjectsRecreation();
                UndoStack.Push(currentOperation);
                break;
            case 1:
                UndoStack.Push(currentOperation);
                ObjectsDeletion();
                //Redo_Erase_ObjectsDeletion();
                break;
        }
       



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        if(RedoStack.Count > 0) {
            uiBtn_redoButton.interactable = true;
        }
        else {
            uiBtn_redoButton.interactable = false;
        }
    }



    public void AddAStep(List<GameObject> inGOList, List<Tile_Base> inTileBaseList, int theOperationFlag) {
        operationAssignment = new UndoRedoOperation(inGOList, inTileBaseList, theOperationFlag);

        UndoStack.Push(operationAssignment);
        RedoStack.Clear();



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        uiBtn_redoButton.interactable = false;
    }


    void ObjectsDeletion() {
        for (int i = 0; i < currentOperation.theOperationList_TileBase.Count; i++) {
            if(areaTilesRegistryScript.Tile_PosUnoccupied(currentOperation.theOperationList_TileBase[i]) == false) {
                string tempGoNameToErase = string.Format("({0}, {1}, {2})"
                    , currentOperation.theOperationList_TileBase[i].Position.x
                    , currentOperation.theOperationList_TileBase[i].Position.y
                    , currentOperation.theOperationList_TileBase[i].Position.z );
                GameObject tempGoToErase = GameObject.Find(tempGoNameToErase);

                areaTilesRegistryScript.Tile_RemoveFromGrid(tempGoToErase.GetComponent<WorldObjectInfo>().tileObject);
                Destroy(tempGoToErase);
            }
            else {
                areaTilesRegistryScript.Tile_RemoveFromGrid(currentOperation.theOperationList_TileBase[i]);
                Destroy( currentOperation.theOperationList_GO[i] );
            }
        }
        currentOperation.theOperationList_GO.Clear();
    }
        
    void ObjectsRecreation() {
        foreach(Tile_Base tileBaseToGen in currentOperation.theOperationList_TileBase) {
             if(areaTilesRegistryScript.Tile_PosUnoccupied(tileBaseToGen.Position) == true) {        // the check for TileRegistry occupation, isnt really necessary here, but i will keep it, for error security
                objInstantiatorScript.CreateTiles_UndoRedo(tileBaseToGen, out constructedGO);
                currentOperation.theOperationList_GO.Add(constructedGO);

                areaTilesRegistryScript.Tile_AddToGrid(tileBaseToGen);
             }
        }
    }


/*
    void Undo_Erase_ObjectsRecreation () {
        foreach(Tile_Base tileBaseToGen in currentOperation.theOperationList_TileBase) {
            if(areaTilesRegistryScript.Tile_PosUnoccupied(tileBaseToGen.Position) == true) {        
                objInstantiatorScript.CreateTiles_UndoRedo(tileBaseToGen, out constructedGO);
                currentOperation.theOperationList_GO.Add(constructedGO);

                areaTilesRegistryScript.Tile_AddToGrid(tileBaseToGen);
            }
        }
    }

    void Redo_Erase_ObjectsDeletion () {
        for (int i = 0; i < currentOperation.theOperationList_GO.Count; i++) {
            areaTilesRegistryScript.Tile_RemoveFromGrid(currentOperation.theOperationList_TileBase[i]);
            Destroy( currentOperation.theOperationList_GO[i] );
        }
        currentOperation.theOperationList_GO.Clear();
    }

*/

}
