using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;
using UnityEngine.UI;

public class UndoRedoManager : MonoBehaviour {

    WorldObjectInstantiator objInstantiatorScript;

    [SerializeField] GameObject databaseController;
    AreaTilesRegistry areaTilesRegistryScript;

   
    public int maxSteps = 30;

    MaxStack<UndoRedoOperation> UndoStack;
    MaxStack<UndoRedoOperation> RedoStack;

    UndoRedoOperation operationAssignment;

    UndoRedoOperation currentOperation;
    List<GameObject> currentGOList;
    List<Geom_Base> currentGeomBaseList;
    List<Entity_Base> currentEntityBaseList;


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



    public void AddAStep(List<GameObject> inGOList, List<Geom_Base> inGeomBaseList, int theOperationFlag) {         //geoms
        operationAssignment = new UndoRedoOperation(inGOList, inGeomBaseList, theOperationFlag);

        UndoStack.Push(operationAssignment);
        RedoStack.Clear();



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        uiBtn_redoButton.interactable = false;
    }


    public void AddAStep(List<GameObject> inGOList, List<Entity_Base> inEntityBaseList, int theOperationFlag) {       //entities
        operationAssignment = new UndoRedoOperation(inGOList, inEntityBaseList, theOperationFlag);

        UndoStack.Push(operationAssignment);
        RedoStack.Clear();



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        uiBtn_redoButton.interactable = false;
    }



    void ObjectsDeletion() {
        if(currentOperation.operationFlag == 10 || currentOperation.operationFlag == 10) {                                 //geoms
            for (int i = 0; i < currentOperation.theOperationList_GeomBase.Count; i++) {
                if(areaTilesRegistryScript.Geom_PosUnoccupied(currentOperation.theOperationList_GeomBase[i]) == false) {
                    string tempGoNameToErase = string.Format("G: ({0}, {1}, {2})"
                        , currentOperation.theOperationList_GeomBase[i].Position.x
                        , currentOperation.theOperationList_GeomBase[i].Position.y
                        , currentOperation.theOperationList_GeomBase[i].Position.z );
                    GameObject tempGoToErase = GameObject.Find(tempGoNameToErase);

                    areaTilesRegistryScript.Geom_RemoveFromGrid(tempGoToErase.GetComponent<GeomObjectInfo>().geomObject);
                    Destroy(tempGoToErase);
                }
                else {
                    areaTilesRegistryScript.Geom_RemoveFromGrid(currentOperation.theOperationList_GeomBase[i]);
                    Destroy( currentOperation.theOperationList_GO[i] );
                }
            }
            currentOperation.theOperationList_GO.Clear();
        }
        else {                                                                                                          //entities
            for (int i = 0; i < currentOperation.theOperationList_EntityBase.Count; i++) {
                if(areaTilesRegistryScript.Entity_PosUnoccupied(currentOperation.theOperationList_EntityBase[i]) == false) {
                    string tempGoNameToErase = string.Format("E: ({0}, {1}, {2})"
                        , currentOperation.theOperationList_EntityBase[i].Position.x
                        , currentOperation.theOperationList_EntityBase[i].Position.y
                        , currentOperation.theOperationList_EntityBase[i].Position.z );
                    GameObject tempGoToErase = GameObject.Find(tempGoNameToErase);

                    areaTilesRegistryScript.Entity_RemoveFromGrid(tempGoToErase.GetComponent<EntityObjectInfo>().entityObject);
                    Destroy(tempGoToErase);
                }
                else {
                    areaTilesRegistryScript.Entity_RemoveFromGrid(currentOperation.theOperationList_EntityBase[i]);
                    Destroy( currentOperation.theOperationList_GO[i] );
                }
            }
            currentOperation.theOperationList_GO.Clear();
        }
    }
        
    void ObjectsRecreation() {
        if(currentOperation.operationFlag == 10 || currentOperation.operationFlag == 10)                 //geoms
            foreach(Geom_Base geomBaseToGen in currentOperation.theOperationList_GeomBase) {
                 if(areaTilesRegistryScript.Geom_PosUnoccupied(geomBaseToGen.Position) == true) {        // the check for TileRegistry occupation, isnt really necessary here, but i will keep it, for error security
                    objInstantiatorScript.CreateGeoms_UndoRedo(geomBaseToGen, out constructedGO);
                    currentOperation.theOperationList_GO.Add(constructedGO);

                    areaTilesRegistryScript.Geom_AddToGrid(geomBaseToGen);
                 }
            }
        else {                                                                                            //entities
            foreach(Entity_Base entityBaseToGen in currentOperation.theOperationList_EntityBase) {
                if(areaTilesRegistryScript.Entity_PosUnoccupied(entityBaseToGen.Position) == true) {        
                    objInstantiatorScript.CreateEntities_UndoRedo(entityBaseToGen, out constructedGO);
                    currentOperation.theOperationList_GO.Add(constructedGO);

                    areaTilesRegistryScript.Entity_AddToGrid(entityBaseToGen);
                }
            }
            
        }
    }



/*
    UndoReplace_theOld_Stack = new MaxStack<UndoRedoOperation>(maxSteps);
    RedoReplace_theOld_Stack = new MaxStack<UndoRedoOperation>(maxSteps);


    UndoRedoOperation tempOperation;

/*
    public void ReplaceOp_OldObjs(List<GameObject> inGOList, List<Tile_Base> inTileBaseList, int theOperationFlag) {
        operationAssignment = new UndoRedoOperation(inGOList, inTileBaseList, theOperationFlag);

        UndoReplace_theOld_Stack.Push(operationAssignment);
    }
*/

/*
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
                RedoStack.Push(currentOperation);
                break;
            case 2:
                RedoStack.Push(currentOperation);
                ObjectsDeletion();
                currentOperation = UndoReplace_theOld_Stack.Pop();
                ObjectsRecreation();
                RedoReplace_theOld_Stack.Push(currentOperation);
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
                break;
            case 2:
                tempOperation = currentOperation;
                currentOperation = RedoReplace_theOld_Stack.Pop();
                ObjectsDeletion();
                RedoReplace_theOld_Stack.Push(currentOperation);
                currentOperation = tempOperation;
                ObjectsRecreation();
                UndoStack.Push(tempOperation);       
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
*/

}
