using UnityEngine;
using System.Collections.Generic;
using TeamUtility.IO;
using UnityEngine.UI;

public class UndoRedoManager : MonoBehaviour {

    public int maxSteps;

    MaxStack<List<GameObject>> UndoStack_GOs;
   // MaxStack<List<GameObject>> RedoStack_GOs;

    MaxStack<List<Tile_Base>> UndoStack_TileBases;
    MaxStack<List<Tile_Base>> RedoStack_TileBases;


    List<GameObject> currentGOList = new List<GameObject>();
    List<Tile_Base> currentTileBaseList = new List<Tile_Base>();


    //---------- Scene Refs -----------------
    [SerializeField] GameObject AreaTileParent;
    [SerializeField] GameObject AreaEntityParent;
    //---------- UI Refs --------------

    [SerializeField] GameObject ui_undoButton;
    [SerializeField] GameObject ui_redoButton;
    Button uiBtn_undoButton;
    Button uiBtn_redoButton;

  



	void Awake () {
        UndoStack_GOs = new MaxStack<List<GameObject>>(maxSteps);
    //    RedoStack_GOs = new MaxStack<List<GameObject>>(maxSteps);

        UndoStack_TileBases = new MaxStack<List<Tile_Base>>(maxSteps);
        RedoStack_TileBases = new MaxStack<List<Tile_Base>>(maxSteps);
	}

    void Start() {
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
        currentGOList = UndoStack_GOs.Pop();
        currentTileBaseList = UndoStack_TileBases.Pop();

        RedoStack_TileBases.Push(currentTileBaseList);


        foreach(GameObject goToUndo in currentGOList) {
            Destroy(goToUndo);
        }
        currentGOList.Clear();



        //---- ui ---
        uiBtn_redoButton.interactable = true;
        if(UndoStack_TileBases.Count > 0) {
            uiBtn_undoButton.interactable = true;
        }
        else {
            uiBtn_undoButton.interactable = false;
        }

        Debug.Log("Undo!");
    }


    public void Redo() {
        currentTileBaseList = RedoStack_TileBases.Pop();

        Debug.Log(currentTileBaseList);
        foreach(Tile_Base tileToGen in currentTileBaseList) {
            GameObject gameObjectToGen = (GameObject)Instantiate(tileToGen.theGameObjectPrefab, tileToGen.Position, Quaternion.Euler( new Vector3 (0,  tileToGen.TileFacingRot, 0)) );

            gameObjectToGen.transform.SetParent(AreaTileParent.transform, true);
            gameObjectToGen.name = tileToGen.editorGoName;

            currentGOList.Add(gameObjectToGen);
        }
        List<GameObject> tempGOList = new List<GameObject>();
        List<Tile_Base> tempTBList = new List<Tile_Base>();
        UndoStack_GOs.Push(tempGOList);
        UndoStack_TileBases.Push(tempTBList);

        currentGOList.Clear();
        currentTileBaseList.Clear();



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        if(RedoStack_TileBases.Count > 0) {
            uiBtn_redoButton.interactable = true;
        }
        else {
            uiBtn_redoButton.interactable = false;
        }

        Debug.Log("Redo!");
    }


    public void AddAStep(List<GameObject> inGOList, List<Tile_Base> inTileBaseList) {
        UndoStack_GOs.Push(inGOList);
        UndoStack_TileBases.Push(inTileBaseList);

        RedoStack_TileBases.Clear();



        //---- ui ---
        uiBtn_undoButton.interactable = true;
        uiBtn_redoButton.interactable = false;
    }

}

/*foreach(List<Tile_Base> tbList in RedoStack_TileBases) {
    tbList.Clear();
}*/