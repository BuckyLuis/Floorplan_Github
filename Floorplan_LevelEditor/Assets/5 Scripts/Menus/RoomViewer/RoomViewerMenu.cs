using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class RoomViewerMenu : MonoBehaviour {

    [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    public AreaObjectRegistrar theAreaObjectRegistrar;

    GameObject assetsDbController;
    CurrentSelectionAndDisplay optionsInfoScript;

    public List<GameObject> roomEntries = new List<GameObject>();

    public int activeRoomIndex;
    public string activeRoomID;


    [SerializeField] GameObject roomEntryPrefab;
    [SerializeField] GameObject roomViewerArea;
    GameObject roomEntryTemp;

    public GameObject colorPickerRef;
    public bool userIsEditingAnEntry = false;

    //------------ UI Element Refs ----------------------
    [SerializeField] GameObject ui_btnAddRoom;
    [SerializeField] GameObject ui_btnRemoveRoom;
    Button uiBtn_AddRoom;
    Button uiBtn_RemoveRoom;
    //------------- CamBounds Placer Refs ---------------
    public GameObject placerWidget_CamBounds;
    public PlaceCamBoundsMarker placeCamBoundsScript;




    void Start() {
        theAreaObjectRegistrar = GetComponent<AreaObjectRegistrar>();
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        optionsInfoScript = assetsDbController.GetComponent<CurrentSelectionAndDisplay>();
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();

        placeCamBoundsScript = placerWidget_CamBounds.GetComponent<PlaceCamBoundsMarker>();
        colorPickerRef.SetActive(false);

        uiBtn_AddRoom = ui_btnAddRoom.GetComponent<Button>();
        uiBtn_RemoveRoom = ui_btnRemoveRoom.GetComponent<Button>();
    }

    public void AddRoomEntry() {
        roomEntryTemp = (GameObject)Instantiate(roomEntryPrefab);
        roomEntryTemp.transform.SetParent(roomViewerArea.transform, false);

        roomEntryTemp.GetComponent<RoomViewerEntry>().NewRoomInitialization();
    }

    public void AddRoomEntry_AreaLoad(Room_Base loadedRoomBase) {
        roomEntryTemp = (GameObject)Instantiate(roomEntryPrefab);
        roomEntryTemp.transform.SetParent(roomViewerArea.transform, false);

        roomEntryTemp.GetComponent<RoomViewerEntry>().InitFromLoad(loadedRoomBase);
    }

    public void RemoveRoomEntry() {
        //ask roomEntry Only?  -OR- AllAssociatedTiles aswell?
        //ask "are you sure?"

        //selected room entry - destroy it

      //  Destroy(roomEntries[activeRoomIndex]);
      //  roomEntries.Remove(roomEntries[activeRoomIndex]);

        //all tiles registered to the room - destroy them
    }

    public void ActivateToggles() {
        userIsEditingAnEntry = false;
        foreach(GameObject roomEntry in roomEntries) {
            roomEntry.GetComponent<RoomViewerEntry>().uiTgl_activeRoom.interactable = true;
        }
        uiBtn_AddRoom.interactable = true;
        uiBtn_RemoveRoom.interactable = true;
    }

    public void DeactivateToggles() {
        userIsEditingAnEntry = true;
        foreach(GameObject roomEntry in roomEntries) {
            roomEntry.GetComponent<RoomViewerEntry>().uiTgl_activeRoom.interactable = false;
        }
        uiBtn_AddRoom.interactable = false;
        uiBtn_RemoveRoom.interactable = false;
    }


    public void RoomInfoToObjectPaintMenu(Color roomColor) {
        objInstantiatorScript.AssignRoomID(activeRoomID);
        objInstantiatorScript.AssignRoomColor(roomColor);

        optionsInfoScript.SetCurrentRoomID(activeRoomID);
        optionsInfoScript.SetCurrentRoomColor(roomColor);
    }
/*
    public string GetTimeForRoomID() {
        currentTimeString = DateTime.UtcNow.ToString("s").Replace(":","");
        currentTimeString.Replace("T","");
        Debug.Log(currentTimeString);

        return currentTimeString;
    }

*/
}
   