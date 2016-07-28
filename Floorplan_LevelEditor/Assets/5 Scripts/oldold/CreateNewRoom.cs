using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateNewRoom : MonoBehaviour {

    AreaObject ourAreaObject;

//------------ Config These! -----------
    public int NewRoomID;
    string NewRoomIDstring;

    public string NewRoomName; 
    public Color NewRoomColor;
    public Vector3 NewRoomOriginPos;
//-------------------------------------

    public GameObject roomViewerEntry_Prefab;

 //------------ UI Element Refs ---------
    GameObject ui_btnAddRoom;
    GameObject ui_btnRemoveRoom;

    GameObject ui_togRoomEdit;
    GameObject ui_fieldRoomID;
    GameObject ui_fieldRoomName;
    GameObject ui_btnRoomColor;
    GameObject ui_btnCamTL;
    GameObject ui_btnCamBR;

    Toggle uiTgl_roomEdit;
    InputField uiIF_roomID;
    InputField uiIF_roomName;
    Color uiC_roomColor;
    Text uiTx_cambTL;
    Text uiTx_camBR;



	void Start () {
        ourAreaObject = GetComponent<AreaObject>();

        //---init Find UI fields---
        ui_btnAddRoom = GameObject.Find("Panel_NewRoom");
	}
	
	void Update () {
	
	}
}
