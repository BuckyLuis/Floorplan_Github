using UnityEngine;
using System.Collections;

public class PlaceCamBoundsMarker : MonoBehaviour {
    
    [SerializeField] GameObject databaseController;
    RoomViewerMenu theRoomViewerMenu;
    RoomViewerEntry activeRoomEntryScript;

    public int gridSize = 2;

//------------------------------------------------------
    [SerializeField] GameObject camBoundTLMarkerPrefab;
    [SerializeField] GameObject camBoundBRMarkerPrefab;
    GameObject markerTemp;

    [SerializeField] GameObject AreaCamBoundsParent;

    public bool TL0_BR1;
    public string roomID;
    public Color roomColor;

    Vector3 camBoundsTLpos;
    Vector3 camBoundsBRpos;




    void Awake() {
        databaseController = GameObject.Find("- == Database Controller == -");
        theRoomViewerMenu = databaseController.GetComponent<RoomViewerMenu>();
    }

    void OnEnable() {
        activeRoomEntryScript = theRoomViewerMenu.roomEntries[theRoomViewerMenu.activeRoomIndex].GetComponent<RoomViewerEntry>(); 
    }
  

    void Clicked() {   //called by ClickDetectMessageSender.cs
        DeleteOldMarker();

        if(TL0_BR1 == true) {
            camBoundsBRpos = transform.position;
            PlaceMarkerBR();
            gameObject.SetActive(false);
        }
        else {
            camBoundsTLpos = transform.position;
            PlaceMarkerTL();
            gameObject.SetActive(false);
        }
       
    }
       
    public void InitCamBoundsPlacer(string roomID_in) {       //called by roomsViewer button, is given roomViewer vars
        roomID = roomID_in;
    }
        
    void PlaceMarkerTL() {
        markerTemp = (GameObject) Instantiate(camBoundTLMarkerPrefab, camBoundsTLpos, Quaternion.identity);
        markerTemp.transform.SetParent(AreaCamBoundsParent.transform, true);
        markerTemp.name = string.Format("CamBoundsTL: rm{0} ({1}, {2}, {3})", roomID, camBoundsTLpos.x, camBoundsTLpos.y, camBoundsTLpos.z);
        markerTemp.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        markerTemp.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        markerTemp.GetComponent<CamBoundsMarker>().roomID = roomID;
        Transform child = markerTemp.transform.GetChild(0); 
        child.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        child.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);

        activeRoomEntryScript.markerCamBoundsTL = markerTemp;
        InformRoomViewerEntry();
    }
        
    void PlaceMarkerBR() {
        markerTemp = (GameObject) Instantiate(camBoundBRMarkerPrefab, camBoundsBRpos, Quaternion.identity);
        markerTemp.transform.SetParent(AreaCamBoundsParent.transform, true);
        markerTemp.name = string.Format("CamBoundsBR: rm{0} ({1}, {2}, {3})", roomID, camBoundsBRpos.x, camBoundsBRpos.y, camBoundsBRpos.z);
        markerTemp.GetComponent<Renderer>().material.SetColor("_Color1", roomColor); 
        markerTemp.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);
        markerTemp.GetComponent<CamBoundsMarker>().roomID = roomID;
        Transform child = markerTemp.transform.GetChild(0); 
        child.GetComponent<Renderer>().material.SetColor("_Color1", roomColor);
        child.GetComponent<Renderer>().material.SetColor("_Color2", roomColor);


        activeRoomEntryScript.markerCamBoundsBR = markerTemp;
        InformRoomViewerEntry();
    }
        
    void InformRoomViewerEntry() {
        if(TL0_BR1 == true) {
            activeRoomEntryScript.CamBoundsBRHasSet(camBoundsBRpos);  
        }
        else{
            activeRoomEntryScript.CamBoundsTLHasSet(camBoundsTLpos);
        }
    }

    void DeleteOldMarker() {
        if(TL0_BR1 == true) {
            if(activeRoomEntryScript.cbBRSetOnce == true) {
                Destroy(activeRoomEntryScript.markerCamBoundsBR);
            }
        }
        else{
            if(activeRoomEntryScript.cbTLSetOnce == true) {
                Destroy(activeRoomEntryScript.markerCamBoundsTL);
            }
        }
    }


}
