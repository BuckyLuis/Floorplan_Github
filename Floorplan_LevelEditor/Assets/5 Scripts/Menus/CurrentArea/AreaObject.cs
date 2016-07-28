using UnityEngine;
using System.Collections.Generic;

public class AreaObject : MonoBehaviour {
    
//============= Loaded Area Data =========
    public Area_Base ThisArea_DataObject;
//========================================

//------------ Refs to Objects to Comm to------------
    RoomViewerMenu theRoomViewerMenu;


//------------------------------------------------------
    public int ThisAreaID { get; protected set; }
    public List<Room_Base> ThisAreasRooms { get; protected set; }
    public List<Tile_Base> ThisAreasTiles { get; protected set; }

//--------------------------------------------------------------------

    void Start() {
        theRoomViewerMenu = GetComponent<RoomViewerMenu>();
    }

    void LoadArea() {
       
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



    public void SaveAreaDataToXml() {
        
    }

}
   