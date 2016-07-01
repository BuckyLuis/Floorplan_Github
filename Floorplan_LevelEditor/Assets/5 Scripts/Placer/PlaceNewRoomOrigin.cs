using UnityEngine;
using System.Collections;

public class PlaceNewRoomOrigin : MonoBehaviour {

    bool hasFiredOnce = false;      //just to make sure

    public Transform roomOriginPrefab;
    Transform roomOriginCell;
    RoomObject roomObjectScript;

    public GameObject databaseController;
    CreateNewRoom createNewRoomScript;


    Vector3 Click_origPos;
    public int gridSize = 2;

    public int roomID;
    public string roomName;
    public Color roomColor;

    Vector3 roomOriginPos;

   
   


    void Start() {
        createNewRoomScript = databaseController.GetComponent<CreateNewRoom>();
    }


    void OnEnable() {
        hasFiredOnce = false;
    }


    void Clicked() {   //called by ClickDetectMessageSender.cs
        Click_origPos = transform.position;
        if(hasFiredOnce == false)
            NewRoomOrigin();
        gameObject.SetActive(false);
    }


    void NewRoomOrigin() {
        roomOriginPos = new Vector3 (Click_origPos.x, Click_origPos.y, Click_origPos.z);
        roomOriginCell = (Transform) Instantiate(roomOriginPrefab, roomOriginPos, Quaternion.identity);
        roomOriginCell.name = string.Format("Rm: '{0}' / #{1} ({2}, {3}, {4})", roomName, roomID, roomOriginPos.x, roomOriginPos.y, roomOriginPos.z);
        Transform marker = roomOriginCell.GetChild(0); 
        marker.GetComponent<Renderer>().material.color = roomColor;
        roomObjectScript = roomOriginCell.GetComponent<RoomObject>();
        roomObjectScript.AlterRoomOrigin(new Vector3(roomOriginPos.x, roomOriginPos.y, roomOriginPos.z));
        hasFiredOnce = true;
        InformNewRoomUI();
    }


    void InformNewRoomUI() {
        createNewRoomScript.OriginPosDecided(roomOriginPos);
    }
}