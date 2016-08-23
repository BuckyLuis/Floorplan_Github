using UnityEngine;
using System.Collections.Generic;

public class UndoRedoOperation{

    public List<GameObject> theOperationList_GO; //list of GameObjects that comprise the operation to Undo/Redo
    public List<Tile_Base> theOperationList_TileBase;  

    public int operationFlag; // 0- tileObjPlace,  1- tileObjErase


    public UndoRedoOperation(List<GameObject> theOpList_GO, List<Tile_Base> theOpList_TileBase, int theOperationFlag) {
        theOperationList_GO = new List<GameObject>(theOpList_GO);
        theOperationList_TileBase = new List<Tile_Base>(theOpList_TileBase);
        operationFlag = theOperationFlag;
    }

}
