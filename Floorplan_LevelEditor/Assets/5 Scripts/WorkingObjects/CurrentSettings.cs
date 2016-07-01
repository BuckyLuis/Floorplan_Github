using UnityEngine;
using System.Collections.Generic;

public class CurrentSettings : MonoBehaviour {

    public List<Room_Base> CurrentRooms = new List<Room_Base>();  //list of all the rooms in the RoomViewer 
   
    public int currRoomID;
    public Color currRoomColor;

    public string currFloorName;
    public string currWallsName;
    public int currWOrientFlag;



    public void SetRoom() {
        
    }

    public void SetRoomColor(Color newColor) {
        currRoomColor = newColor;
    }

}
