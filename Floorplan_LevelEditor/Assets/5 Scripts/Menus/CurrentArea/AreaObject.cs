using UnityEngine;
using System.Collections.Generic;

public class AreaObject : MonoBehaviour {
    
//============= Loaded Area Data =========
    public Area_Base ThisArea_DataObject;
//========================================
    Area_ReadWrite Area_ReadWriteScript;


//------------ Refs to Objects to Comm to------------
    RoomViewerMenu theRoomViewerMenu;


//------------------------------------------------------
    public int ThisAreaID { get; protected set; }
    public List<Room_Base> ThisAreasRooms { get; protected set; }
    public List<Tile_Base> ThisAreasTiles { get; protected set; }

//--------------------------------------------------------------------

    void Start() {
        Area_ReadWriteScript = GetComponent<Area_ReadWrite>();
        theRoomViewerMenu = GetComponent<RoomViewerMenu>();
    }


    public void Create_NewArea(string theIndexID, string theAreaID, string theAreaName) {
        ThisArea_DataObject = new Area_Base();
        ThisArea_DataObject.IndexID = theIndexID;
        ThisArea_DataObject.AreaID = theAreaID;
        ThisArea_DataObject.AreaName = theAreaName;
   //     SaveAreaDataToXml();
    }

    public void SaveAreaDataToXml() {
        Area_ReadWriteScript.WriteXMLData(ThisArea_DataObject);
    }

    public void Load_LoadArea(Area_Base theLoadedAreaObject) {
        ThisArea_DataObject = theLoadedAreaObject;
    }

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
   