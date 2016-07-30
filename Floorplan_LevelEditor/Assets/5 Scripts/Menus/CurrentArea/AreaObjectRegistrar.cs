using UnityEngine;
using System.Collections.Generic;

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

    public int ThisAreaID { get; protected set; }
    public List<Room_Base> ThisAreasRooms { get; protected set; }
    public List<Tile_Base> ThisAreasTiles { get; protected set; }


//------------ Refs to Objects to Communicate to------------
    RoomViewerMenu theRoomViewerMenu;




    void Start() {
        Area_ReadWriteScript = GetComponent<Area_ReadWrite>();
        AreaEntry_ReadWriteScript = GetComponent<AreaEntry_ReadWrite>();
        theRoomViewerMenu = GetComponent<RoomViewerMenu>();
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

        The_AreaCatalog.areaEntries.Add(ThisAreaEntry_CatalogObject);                                   //register Entry to Catalog list

        AreaEntry_ReadWriteScript.WriteXMLData(The_AreaCatalog);                                        //write currentCatalog to xml
        Area_ReadWriteScript.WriteXMLData(ThisArea_DataObject, ThisArea_DataObject.AreaName);           //write currentArea to xml
    }

    public void LoadAreaDataFromXml(string requestedAreaID) {
        foreach (AreaEntry_Base areaEntryObject in The_AreaCatalog.areaEntries)
        {
            if(areaEntryObject.AreaEntryID == requestedAreaID) {
                ThisArea_DataObject = Area_ReadWriteScript.ReadXMLData(areaEntryObject.AreaEntryName);      //call and retrieve AreaData from Xml
            }
        }
    }

//----------------------------------------------------------------------------------------------------------------------


    public void AddRoomsToAreaRoomList() {
        foreach(GameObject roomEntry in theRoomViewerMenu.roomEntries) {
            ThisAreasRooms.Add(roomEntry.GetComponent<RoomViewerEntry>().ThisRoom_DataObject);
        }
    }

    public void RemoveRoomFromArea() {
        
    }

    public void AddTileToArea() {
        
    }

    public void AlterAreaID() {
        
    }





}
   