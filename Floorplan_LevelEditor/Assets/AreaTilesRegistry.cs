﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaTilesRegistry : MonoBehaviour {

    Tile_Base[,,] theTilesInAreaGrid;
    Entity_Base[,,] theEntitiesInAreaGrid;

    int tempX, tempY, tempZ;



    void Start() {
        theTilesInAreaGrid = new Tile_Base[100,20,100];
        theEntitiesInAreaGrid = new Entity_Base[200,20,200];
    }


    public bool Tile_PosUnoccupied(Vector3 testPosition) {              
        tempX = Mathf.FloorToInt( (testPosition.x + 100) / 2 );      // input number is -99 to 99 , in increments of 2 ... add 99 to this (so -99 is index 0) and half it .. ( position 1 is index 50 ,, position 99 is index 99) 
        tempY = Mathf.FloorToInt( (testPosition.y + 30) / 3 );              // height is in increments of 3 
        tempZ = Mathf.FloorToInt( (testPosition.z + 100) / 2 );

        if( theTilesInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }
  

    public void Tile_AddToGrid(Tile_Base theTileBase) {
        tempX = Mathf.FloorToInt( (theTileBase.Position.x + 100) / 2 ); 
        tempY = Mathf.FloorToInt( (theTileBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt( (theTileBase.Position.z + 100) / 2 );

        theTilesInAreaGrid[ tempX, tempY, tempZ ] = theTileBase;
    }


    public void Tile_RemoveFromGrid(Tile_Base theTileBase) {
        tempX = Mathf.FloorToInt( (theTileBase.Position.x + 100) / 2 ); 
        tempY = Mathf.FloorToInt( (theTileBase.Position.y + 30) / 3 );              
        tempZ = Mathf.FloorToInt( (theTileBase.Position.z + 100) / 2 );

        theTilesInAreaGrid[ tempX, tempY, tempZ ] = null;
    }



    public bool Entity_PosUnoccupied(Vector3 testPosition) {         
        tempX = Mathf.FloorToInt(testPosition.x + 100);              
        tempY = Mathf.FloorToInt( (testPosition.y + 30) / 3);                 
        tempZ = Mathf.FloorToInt(testPosition.z + 100);                       

        if( theEntitiesInAreaGrid[ tempX, tempY, tempZ ] == null ) {
            return true;
        }
        else {
            return false;
        }
    }


}