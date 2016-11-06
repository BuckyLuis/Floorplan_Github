﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class AreaObjectRegistrar : MonoBehaviour {

//============= Loaded Area Data =========

    //============ Area Object ==========
    public Area_Base ThisArea_DataObject;                               // the Area object with refs to Rooms and Tiles
    //===================================
    public AreaEntry_Base ThisAreaEntry_CatalogObject;                  // the AreaEntry object , with refs to Area object indices and names
    public AreaEntry_DataList The_AreaCatalog = new AreaEntry_DataList();

   
    Area_ReadWrite Area_ReadWriteScript;
    AreaEntry_ReadWrite AreaEntry_ReadWriteScript;
//========================================
/*
    public List<Room_Base> ThisAreasRooms { get; protected set; }
    public List<Geom_Base> ThisAreasTiles { get; protected set; }
*/

//------------ Refs to Objects to Communicate to------------
    RoomViewerMenu theRoomViewerMenuScript;
    AreaTilesRegistry theTilesRegistryScript;

    [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;

    Room_Base tempRoomBase;




    void Start() {
        toolsController = GameObject.FindGameObjectWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();

        Area_ReadWriteScript = GetComponent<Area_ReadWrite>();
        AreaEntry_ReadWriteScript = GetComponent<AreaEntry_ReadWrite>();
        theRoomViewerMenuScript = GetComponent<RoomViewerMenu>();
        theTilesRegistryScript = GetComponent<AreaTilesRegistry>();
    }


    public void Create_NewArea(string theIndexID, string theAreaID, string theAreaName) {
        ThisArea_DataObject = new Area_Base();                                              //create an Area 
        ThisAreaEntry_CatalogObject = new AreaEntry_Base();                                 //create an AreaEntry

        ThisArea_DataObject.IndexID = theIndexID;
        ThisArea_DataObject.AreaID = theAreaID;
        ThisArea_DataObject.AreaName = theAreaName;

        ThisAreaEntry_CatalogObject.IndexID = theIndexID;
        ThisAreaEntry_CatalogObject.AreaEntryID = theAreaID;
        ThisAreaEntry_CatalogObject.AreaEntryName = theAreaName;
    }

    public void SaveAreaDataToXml(string theIndexID, string theAreaID, string theAreaName) {
        ThisArea_DataObject.IndexID = theIndexID;
        ThisArea_DataObject.AreaID = theAreaID;
        ThisArea_DataObject.AreaName = theAreaName;

        ThisAreaEntry_CatalogObject.IndexID = theIndexID;
        ThisAreaEntry_CatalogObject.AreaEntryID = theAreaID;
        ThisAreaEntry_CatalogObject.AreaEntryName = theAreaName;

        AddRoomsToAreaRoomList();

        The_AreaCatalog.areaEntries.Add(ThisAreaEntry_CatalogObject);                                   //register Entry to Catalog list

        AreaEntry_ReadWriteScript.WriteXMLData(The_AreaCatalog);                                        //write currentCatalog to xml
        Area_ReadWriteScript.WriteXMLData(ThisArea_DataObject, ThisArea_DataObject.AreaName);           //write currentArea to xml
    }

    public void SaveAs_AreaDataToXml(string theIndexID, string theAreaID, string theAreaName) {
        ThisAreaEntry_CatalogObject = new AreaEntry_Base();                                          //create a new AreaEntry

        ThisArea_DataObject.IndexID = theIndexID;
        ThisArea_DataObject.AreaID = theAreaID;
        ThisArea_DataObject.AreaName = theAreaName;

        ThisAreaEntry_CatalogObject.IndexID = theIndexID;
        ThisAreaEntry_CatalogObject.AreaEntryID = theAreaID;
        ThisAreaEntry_CatalogObject.AreaEntryName = theAreaName;

        AddRoomsToAreaRoomList();

        The_AreaCatalog.areaEntries.Add(ThisAreaEntry_CatalogObject);                                   //register Entry to Catalog list

        AreaEntry_ReadWriteScript.WriteXMLData(The_AreaCatalog);                                        //write currentCatalog to xml
        Area_ReadWriteScript.WriteXMLData(ThisArea_DataObject, ThisArea_DataObject.AreaName);           //write currentArea to xml
    }

    public void LoadAreaDataFromXml(string requestedAreaID) {
        foreach (AreaEntry_Base areaEntryObject in The_AreaCatalog.areaEntries)
        {
            if(areaEntryObject.AreaEntryID == requestedAreaID) {
                Area_ReadWriteScript.ReadXMLData(areaEntryObject.AreaEntryName);      //call and retrieve AreaData from Xml
            }
        }
    }

//----------------------------------------------------------------------------------------------------------------------


    void AddRoomsToAreaRoomList() { //and add tiles to Room's Tiles lists
        foreach(GameObject roomEntry in theRoomViewerMenuScript.roomEntries) {
            tempRoomBase = roomEntry.GetComponent<RoomViewerEntry>().ThisRoom_DataObject;
            ThisArea_DataObject.roomsInArea.Add(tempRoomBase);

            foreach(Geom_Base geomEntry in theTilesRegistryScript.theGeomsInAreaGrid) {
                if(geomEntry == null)
                    continue;
                if(geomEntry.RoomID == tempRoomBase.RoomID) 
                    tempRoomBase.geomsInRoom.Add(geomEntry);
            }
            foreach(Entity_Base entityEntry in theTilesRegistryScript.theEntitiesInAreaGrid) {
                if(entityEntry == null)
                    continue;
                if(entityEntry.RoomID == tempRoomBase.RoomID) 
                    tempRoomBase.entitiesInRoom.Add(entityEntry);
            }
        }
    }
        
    public void AlterAreaID() {
        
    }


    public void ConstructLevelFromLoadedArea() {
        ThisArea_DataObject = null;
        ThisArea_DataObject = Area_ReadWriteScript.Area_DataObject;

        if(ThisArea_DataObject != null) {
            foreach(Room_Base roomEntry in ThisArea_DataObject.roomsInArea) {
                theRoomViewerMenuScript.AddRoomEntry_AreaLoad(roomEntry);

                foreach(Geom_Base geomEntry in roomEntry.geomsInRoom) {
                    objInstantiatorScript.CreateGeoms_AreaLoad(geomEntry);
                }
                foreach(Entity_Base entityEntry in roomEntry.entitiesInRoom) {
                    objInstantiatorScript.CreateEntities_AreaLoad(entityEntry);
                }
            }
           
        }
        else {
            Debug.LogError("ERROR!: AreaObjectRegistrar.cs - Area_ReadWrite has failed to provide a proper AreaObject to the Registrar!");
        }
    }




}
   