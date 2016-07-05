using UnityEngine;
using System.Collections.Generic;

public class AreaObject : MonoBehaviour {
    
//============= Loaded Area Data =========
    public Area_Base ThisArea { get; protected set; }
//========================================

    public int ThisAreaID { get; protected set; }
    public List<Room_Base> ThisAreasRooms { get; protected set; }
    public List<Tile_Base> ThisAreasTiles { get; protected set; }

//--------------------------------------------------------------------

    void Start() {
        
    }

    void LoadArea() {
       
    }

    public void AddRoomToArea() {
        
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
   