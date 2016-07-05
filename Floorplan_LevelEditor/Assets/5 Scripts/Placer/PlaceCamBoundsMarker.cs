using UnityEngine;
using System.Collections;

public class PlaceCamBoundsMarker : MonoBehaviour {

    public int gridSize = 2;

//-----------------------------
    [SerializeField] GameObject camBoundTLMarkerPrefab;
    [SerializeField] GameObject camBoundBRMarkerPrefab;
    Transform tempTrans;

    public bool TL0_BR1;
    public int roomID;
    public Color roomColor;

    Vector3 camBoundsTLpos;
    Vector3 camBoundsBRpos;


  

    void Clicked() {   //called by ClickDetectMessageSender.cs
        if(TL0_BR1 == true) {
            camBoundsBRpos = transform.position;
            PlaceMarkerBR();
        }
        else {
            camBoundsTLpos = transform.position;
            PlaceMarkerTL();
        }
        gameObject.SetActive(false);
    }


    public void InitCamBoundsPlacer(int roomID_in) {       //called by roomsViewer button, is given roomViewer vars
        roomID = roomID_in;
    }


    void PlaceMarkerTL() {
        tempTrans = (Transform) Instantiate(camBoundTLMarkerPrefab, camBoundsTLpos, Quaternion.identity);
        tempTrans.name = string.Format("CamBoundsTL: {1} ({2}, {3}, {4})", roomID, camBoundsTLpos.x, camBoundsTLpos.y, camBoundsTLpos.z);
        tempTrans.GetComponent<Renderer>().material.color = roomColor;
        tempTrans.GetComponent<CamBoundsMarker>().roomID = roomID;
        Transform child = tempTrans.GetChild(0); 
        child.GetComponent<Renderer>().material.color = roomColor;
        InformRoomViewerEntry();
    }

    void PlaceMarkerBR() {
        tempTrans = (Transform) Instantiate(camBoundBRMarkerPrefab, camBoundsBRpos, Quaternion.identity);
        tempTrans.name = string.Format("CamBoundsBR: {1} ({2}, {3}, {4})", roomID, camBoundsBRpos.x, camBoundsBRpos.y, camBoundsBRpos.z);
        tempTrans.GetComponent<Renderer>().material.color = roomColor;
        tempTrans.GetComponent<CamBoundsMarker>().roomID = roomID;
        Transform child = tempTrans.GetChild(0); 
        child.GetComponent<Renderer>().material.color = roomColor;
        InformRoomViewerEntry();
    }

    void InformRoomViewerEntry() {
        
    }
}
