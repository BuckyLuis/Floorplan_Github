using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomViewerMenu : MonoBehaviour {

    public List<GameObject> roomEntries = new List<GameObject>();
    public int activeRoomIndex;

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
        placeCamBoundsScript = placerWidget_CamBounds.GetComponent<PlaceCamBoundsMarker>();
        colorPickerRef.SetActive(false);

        uiBtn_AddRoom = ui_btnAddRoom.GetComponent<Button>();
        uiBtn_RemoveRoom = ui_btnRemoveRoom.GetComponent<Button>();
    }

    public void AddRoomEntry() {
        roomEntryTemp = (GameObject)Instantiate(roomEntryPrefab);
        roomEntryTemp.transform.SetParent(roomViewerArea.transform, false);
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


}
   