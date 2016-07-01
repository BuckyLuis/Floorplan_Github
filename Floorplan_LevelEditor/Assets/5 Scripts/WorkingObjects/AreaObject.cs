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

    public int newRoomOriginX , newRoomOriginZ;
    public GameObject roomObjectPrefab;



    void Start() {
        
    }



    void LoadArea() {
       
    }

    public void AddRoomToArea() {
        Instantiate(roomObjectPrefab, new Vector3(newRoomOriginX, 0, newRoomOriginZ) , Quaternion.identity);


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
   