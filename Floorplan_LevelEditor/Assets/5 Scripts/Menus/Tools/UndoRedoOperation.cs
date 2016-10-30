using UnityEngine;
using System.Collections.Generic;

public class UndoRedoOperation{

    public List<GameObject> theOperationList_GO; //list of GameObjects that comprise the operation to Undo/Redo
    public List<Geom_Base> theOperationList_GeomBase;  
    public List<Entity_Base> theOperationList_EntityBase;

    public int operationFlag; // (from the assignment -> ) 10- geomObjPlace,  11- geomObjErase  , 20 - entityObjPlace, 21 - entityObjErase


    public UndoRedoOperation(List<GameObject> theOpList_GO, List<Geom_Base> theOpList_GeomBase, int theOperationFlag) {
        theOperationList_GO = new List<GameObject>(theOpList_GO);
        theOperationList_GeomBase = new List<Geom_Base>(theOpList_GeomBase);
        operationFlag = theOperationFlag;
    }

    public UndoRedoOperation(List<GameObject> theOpList_GO, List<Entity_Base> theOpList_EntityBase, int theOperationFlag) {
        theOperationList_GO = new List<GameObject>(theOpList_GO);
        theOperationList_EntityBase = new List<Entity_Base>(theOpList_EntityBase);
        operationFlag = theOperationFlag;
    }

}
