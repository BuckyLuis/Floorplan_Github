using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AreaTilesRegistry : MonoBehaviour {

    public Geom_Base[,,] theGeomsInAreaGrid { get; private set; }
    public Entity_Base[,,] theEntitiesInAreaGrid { get; private set; }

    int tempX, tempY, tempZ;



    void Start() {
        theGeomsInAreaGrid = new Geom_Base[100,20,100];
        theEntitiesInAreaGrid = new Entity_Base[200,20,200];
    }


    public bool Geom_PosUnoccupied(Vector3 testPosition) {              
        tempX = Mathf.FloorToInt( (testPosition.x + 100) / 2 );      // input number is -100 to 98 , in increments of 2 ... add 99 to this (so -99 is index 0) and half it .. ( position 1 is index 50 ,, position 99 is index 99) 
        tempY = Mathf.FloorToInt( (testPosition.y + 30) / 3 );              // height is in increments of 3 
        tempZ = Mathf.FloorToInt( (testPosition.z + 100) / 2 );

        if( theGeomsInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool Geom_PosUnoccupied(Geom_Base theGeomBase) {              
        tempX = Mathf.FloorToInt( (theGeomBase.Position.x + 100) / 2 );      // input number is -100 to 98 , in increments of 2 ... add 99 to this (so -99 is index 0) and half it .. ( position 1 is index 50 ,, position 99 is index 99) 
        tempY = Mathf.FloorToInt( (theGeomBase.Position.y + 30) / 3 );              // height is in increments of 3 
        tempZ = Mathf.FloorToInt( (theGeomBase.Position.z + 100) / 2 );

        if( theGeomsInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }
  

    public void Geom_AddToGrid(Geom_Base theGeomBase) {
        tempX = Mathf.FloorToInt( (theGeomBase.Position.x + 100) / 2 ); 
        tempY = Mathf.FloorToInt( (theGeomBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt( (theGeomBase.Position.z + 100) / 2 );

        theGeomsInAreaGrid[ tempX, tempY, tempZ ] = theGeomBase;
    }


    public void Geom_RemoveFromGrid(Geom_Base theGeomBase) {
        tempX = Mathf.FloorToInt( (theGeomBase.Position.x + 100) / 2 ); 
        tempY = Mathf.FloorToInt( (theGeomBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt( (theGeomBase.Position.z + 100) / 2 );

        theGeomsInAreaGrid[ tempX, tempY, tempZ ] = null;
    }




    public bool Entity_PosUnoccupied(Vector3 testPosition) {         
        tempX = Mathf.FloorToInt(testPosition.x + 100);        // input number is -100.5 to 98.5 , floor it to -100 to 98 + 100 .. so its 0 - 199 .... WorldPosition remains -100.5 to 98.5 .. the conversion is for the 3D array        
        tempY = Mathf.FloorToInt( (testPosition.y + 30) / 3);                 
        tempZ = Mathf.FloorToInt(testPosition.z + 100);                       

        if( theEntitiesInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool Entity_PosUnoccupied(Entity_Base theEntityBase) {              
        tempX = Mathf.FloorToInt(theEntityBase.Position.x + 100);      
        tempY = Mathf.FloorToInt( (theEntityBase.Position.y + 30) / 3 );           
        tempZ = Mathf.FloorToInt(theEntityBase.Position.z + 100);

        if( theEntitiesInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }

    public void Entity_AddToGrid(Entity_Base theEntityBase) {
        tempX = Mathf.FloorToInt(theEntityBase.Position.x + 100); 
        tempY = Mathf.FloorToInt( (theEntityBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt(theEntityBase.Position.z + 100);

        theEntitiesInAreaGrid[ tempX, tempY, tempZ ] = theEntityBase;
    }

    public void Entity_RemoveFromGrid(Entity_Base theEntityBase) {
        tempX = Mathf.FloorToInt(theEntityBase.Position.x + 100); 
        tempY = Mathf.FloorToInt( (theEntityBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt(theEntityBase.Position.z + 100);

        theEntitiesInAreaGrid[ tempX, tempY, tempZ ] = null;
    }

    public void InitTilesRegistry() {
        Array.Clear(theGeomsInAreaGrid, 0, theGeomsInAreaGrid.Length);
        Array.Clear(theEntitiesInAreaGrid, 0, theEntitiesInAreaGrid.Length);
    }


}
