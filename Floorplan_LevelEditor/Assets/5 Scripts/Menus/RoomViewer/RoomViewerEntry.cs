using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomViewerEntry : MonoBehaviour {

    [SerializeField] GameObject databaseController;

    AreaObject ourAreaObject;
    RoomViewerMenu theRoomViewerMenu;

    [SerializeField]GameObject uiPanel_colorPicker;

//------------ Room Data Object -------------------
    public Room_Base ThisRoom_DataObject = new Room_Base(); 

//------------ Config These! ---------------------
    public int thisRoomIndex;   //index of room in Area list
    public int thisRoomID;      //identifier for room,  for tiles to know
    string thisRoomIDstring;

    public string thisRoomName; 
    public Color thisRoomColor;
    public Vector3 thisRoomCamTLPos;
    public Vector3 thisRoomCamBRPos;

//---------------- default value construction ---------


//-------------------------------------------------
    public bool cbTLSetOnce = false;   //has the CamBounds been set by user at least once?
    public bool cbBRSetOnce = false;

    public GameObject markerCamBoundsTL;
    public GameObject markerCamBoundsBR;

//------------ UI Element Refs ------------------
    [SerializeField] GameObject ui_txtRmIndex;
    [SerializeField] GameObject ui_fieldRoomID;
    [SerializeField] GameObject ui_fieldRoomName;
    [SerializeField] GameObject ui_btnRoomColor;
    [SerializeField] GameObject ui_tglActiveRoom;
    [SerializeField] GameObject ui_btnCamTL;
    [SerializeField] GameObject ui_btnCamBR;

    Text uiTx_RoomIndex;
    InputField uiIF_roomID;
    InputField uiIF_roomName;
    Image uiImg_roomColorImg;
    Button uiBtn_roomColor;
    public Toggle uiTgl_activeRoom;
    Button uiBtn_camTL;
    Button uiBtn_camBR;
    Image uiImg_camTLSet;
    Image uiImg_camBRSet;
    Text uiTx_camTL;
    Text uiTx_camBR;
    //ToggleGroup uiTG_activeRoomTGroup;

   


	void Start () {
        databaseController = GameObject.Find("- == Database Controller == -");
        theRoomViewerMenu = databaseController.GetComponent<RoomViewerMenu>();
        uiPanel_colorPicker = theRoomViewerMenu.colorPickerRef; //GameObject.Find("Panel_ColorPicker");
     /*
        ui_fieldRoomID = transform.Find("InputField_RVERoomID").gameObject;
        ui_fieldRoomName = transform.Find("InputField_RVEName").gameObject;
        ui_btnRoomColor = transform.Find("Button_RVEColor").gameObject;
        ui_tglActiveRoom = transform.Find("Toggle_RVEActive").gameObject;
        ui_txtRmIndex = transform.Find("Toggle_RVEActive/ValueLabel_RoomIndex").gameObject;
        ui_btnCamTL = transform.Find("Button_RVECamBoundsTL").gameObject;
        ui_btnCamBR = transform.Find("Button_RVECamBoundsBR").gameObject;
    */
        uiTx_RoomIndex = ui_txtRmIndex.GetComponent<Text>();
        uiIF_roomID = ui_fieldRoomID.GetComponent<InputField>();
        uiIF_roomName = ui_fieldRoomName.GetComponent<InputField>();
        uiImg_roomColorImg = ui_btnRoomColor.GetComponent<Image>();
        uiBtn_roomColor = ui_btnRoomColor.GetComponent<Button>();
        uiTgl_activeRoom = ui_tglActiveRoom.GetComponent<Toggle>();
        uiBtn_camTL = ui_btnCamTL.GetComponent<Button>();
        uiBtn_camBR = ui_btnCamBR.GetComponent<Button>();
        uiImg_camTLSet = ui_btnCamTL.transform.GetChild(0).GetComponent<Image>();
        uiImg_camBRSet = ui_btnCamBR.transform.GetChild(0).GetComponent<Image>();
        uiTx_camTL = ui_btnCamTL.transform.GetChild(1).GetComponent<Text>();
        uiTx_camBR = ui_btnCamBR.transform.GetChild(1).GetComponent<Text>();
     

        uiTgl_activeRoom.group = databaseController.GetComponent<ToggleGroup>();  //assign ToggleGroup

//-------- init Room --------------------
        SetRoomIndex();
        SetRoomDefaultValues();
        theRoomViewerMenu.roomEntries.Add(gameObject);
        AssignButtonListeners();
        DeactivateRoomEntry();
        if(theRoomViewerMenu.userIsEditingAnEntry == true)
            uiTgl_activeRoom.interactable = false;
	}

    void Update() {
        if( uiIF_roomID.isFocused || uiIF_roomName.isFocused ) {
            AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = true;
            TileToPaintMenu.anInputFieldIsInFocus = true;
        }
    }

    public void SetRoomIndex() {
        uiTx_RoomIndex.text = theRoomViewerMenu.roomEntries.Count.ToString();
        thisRoomIndex = theRoomViewerMenu.roomEntries.Count;

        ThisRoom_DataObject.RoomAreaIndex = thisRoomIndex;
    }

    void SetRoomDefaultValues() {
        //RoomID:  devkey 1 digit + areaID 3 digits + roomIndex 2 digits  + (for modders 3 digits)
       // thisRoomID = 
        thisRoomColor = DistinctColors.GetNextDistinctColor();
        uiImg_roomColorImg.color = thisRoomColor;

        ThisRoom_DataObject.RoomColor = thisRoomColor;
    }

    void AssignButtonListeners() {
        uiIF_roomID.onEndEdit.AddListener(delegate { ChangeRoomID(); });
        uiIF_roomName.onEndEdit.AddListener(delegate { ChangeRoomName(); });
        uiBtn_roomColor.onClick.AddListener(() => { uiPanel_colorPicker.SetActive(true); });
        uiBtn_roomColor.onClick.AddListener(() => { uiPanel_colorPicker.GetComponentInChildren<ColorPicker>().ActivateColPicker(uiBtn_roomColor); });
        uiTgl_activeRoom.onValueChanged.AddListener(delegate {ToggleActiveRoom(uiTgl_activeRoom.isOn); });
        uiBtn_camTL.onClick.AddListener(this.ChangeCamBoundsTL);
        uiBtn_camBR.onClick.AddListener(this.ChangeCamBoundsBR);
    }

    public void ChangeRoomID() {
        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = false;
        TileToPaintMenu.anInputFieldIsInFocus = false;

        thisRoomID = int.Parse(uiIF_roomID.text);

        ThisRoom_DataObject.RoomID = thisRoomID;

        if(markerCamBoundsTL != null) {
            markerCamBoundsTL.GetComponent<CamBoundsMarker>().roomID = thisRoomID;
            markerCamBoundsTL.name = string.Format("CamBoundsTL: rm{0} ({1}, {2}, {3})", thisRoomID, markerCamBoundsTL.transform.position.x, markerCamBoundsTL.transform.position.y, markerCamBoundsTL.transform.position.z);
        }
        if(markerCamBoundsBR != null) {
            markerCamBoundsBR.GetComponent<CamBoundsMarker>().roomID = thisRoomID;
            markerCamBoundsBR.name = string.Format("CamBoundsTL: rm{0} ({1}, {2}, {3})", thisRoomID, markerCamBoundsBR.transform.position.x, markerCamBoundsBR.transform.position.y, markerCamBoundsBR.transform.position.z);
        }
    }
	
    public void ChangeRoomName() {
        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = false;
        TileToPaintMenu.anInputFieldIsInFocus = false;

        thisRoomName = uiIF_roomName.text;

        ThisRoom_DataObject.RoomName = thisRoomName;
    }

    public void ChangeRoomColor(Color theColor) {       //set from ColorPicker.cs
        thisRoomColor = theColor;
        theRoomViewerMenu.ActivateToggles();

        if(markerCamBoundsTL != null) {
            markerCamBoundsTL.GetComponent<Renderer>().material.SetColor("_Color1", thisRoomColor);
            markerCamBoundsTL.GetComponent<Renderer>().material.SetColor("_Color2", thisRoomColor);
            Transform child = markerCamBoundsTL.transform.GetChild(0); 
            child.GetComponent<Renderer>().material.SetColor("_Color1", thisRoomColor);
            child.GetComponent<Renderer>().material.SetColor("_Color2", thisRoomColor);
        }
        if(markerCamBoundsBR != null) {
            markerCamBoundsBR.GetComponent<Renderer>().material.SetColor("_Color1", thisRoomColor);
            markerCamBoundsBR.GetComponent<Renderer>().material.SetColor("_Color2", thisRoomColor);
            Transform child = markerCamBoundsBR.transform.GetChild(0); 
            child.GetComponent<Renderer>().material.SetColor("_Color1", thisRoomColor);
            child.GetComponent<Renderer>().material.SetColor("_Color2", thisRoomColor);
        }
    }

    public void ToggleActiveRoom(bool toggleStatus) {
        if(toggleStatus == true) {
            theRoomViewerMenu.activeRoomIndex = thisRoomIndex;
            theRoomViewerMenu.activeRoomID = thisRoomID;
            ActivateRoomEntry();
            theRoomViewerMenu.RoomInfoToObjectPaintMenu(thisRoomColor);
        }
        else {
            DeactivateRoomEntry();
        }
    }

    void ActivateRoomEntry() {
        uiIF_roomID.interactable = true;
        uiIF_roomName.interactable = true;
        uiBtn_roomColor.interactable = true;
        uiBtn_camTL.interactable = true;
        uiBtn_camBR.interactable = true;
    }
        
    void DeactivateRoomEntry() {
        uiIF_roomID.interactable = false;
        uiIF_roomName.interactable = false;
        uiBtn_roomColor.interactable = false;
        uiBtn_camTL.interactable = false;
        uiBtn_camBR.interactable = false;
    }
        
    void ChangeCamBoundsTL() {
        theRoomViewerMenu.DeactivateToggles();
        theRoomViewerMenu.placerWidget_CamBounds.SetActive(true);
        theRoomViewerMenu.placeCamBoundsScript.roomID = thisRoomID;
        theRoomViewerMenu.placeCamBoundsScript.roomColor = thisRoomColor;
        theRoomViewerMenu.placeCamBoundsScript.TL0_BR1 = false;
    }

    void ChangeCamBoundsBR() {
        theRoomViewerMenu.DeactivateToggles();
        theRoomViewerMenu.placerWidget_CamBounds.SetActive(true);
        theRoomViewerMenu.placeCamBoundsScript.roomID = thisRoomID;
        theRoomViewerMenu.placeCamBoundsScript.roomColor = thisRoomColor;
        theRoomViewerMenu.placeCamBoundsScript.TL0_BR1 = true;
    }

    public void CamBoundsTLHasSet(Vector3 theTLPos) {
        theRoomViewerMenu.ActivateToggles();
        thisRoomCamTLPos = theTLPos;

        ThisRoom_DataObject.CamBoundsTLPos = thisRoomCamTLPos;

        cbTLSetOnce = true;
        VerifyCamBounds();
    }
        
    public void CamBoundsBRHasSet(Vector3 theBRPos) {
        theRoomViewerMenu.ActivateToggles();
        thisRoomCamBRPos = theBRPos;

        ThisRoom_DataObject.CamBoundsBRPos = thisRoomCamBRPos;

        cbBRSetOnce = true;
        VerifyCamBounds();
    }

    void VerifyCamBounds() {
        if(cbTLSetOnce == true && cbBRSetOnce == false) {
            uiTx_camTL.text = string.Format("{0}, {1}, {2}", thisRoomCamTLPos.x, thisRoomCamTLPos.y, thisRoomCamTLPos.z);
        }
        if(cbTLSetOnce == false && cbBRSetOnce == true) {
            uiTx_camBR.text = string.Format("{0}, {1}, {2}", thisRoomCamBRPos.x, thisRoomCamBRPos.y, thisRoomCamBRPos.z);
        }
        if(cbTLSetOnce != false && cbBRSetOnce != false) {
            if(thisRoomCamTLPos.x < thisRoomCamBRPos.x && thisRoomCamTLPos.z > thisRoomCamBRPos.z) {
                uiTx_camTL.text = string.Format("{0}, {1}, {2}", thisRoomCamTLPos.x, thisRoomCamTLPos.y, thisRoomCamTLPos.z);
                uiImg_camTLSet.enabled = true;
                uiTx_camBR.text = string.Format("{0}, {1}, {2}", thisRoomCamBRPos.x, thisRoomCamBRPos.y, thisRoomCamBRPos.z);
                uiImg_camBRSet.enabled = true;
                DebugConsole.Log("<b>Both CamBounds-Marker's positions have been placed correctly!</b>", "normal", 10f);
            }
            else if(thisRoomCamTLPos.x >= thisRoomCamBRPos.x && thisRoomCamTLPos.z > thisRoomCamBRPos.z) {
                uiTx_camTL.text = string.Format("<color=#E69F00>{0}</color>, {1}, {2}", thisRoomCamTLPos.x, thisRoomCamTLPos.y, thisRoomCamTLPos.z);
                uiImg_camTLSet.enabled = false;
                uiTx_camBR.text = string.Format("<color=#E69F00>{0}</color>, {1}, {2}", thisRoomCamBRPos.x, thisRoomCamBRPos.y, thisRoomCamBRPos.z);
                uiImg_camBRSet.enabled = false;
                DebugConsole.Log("The <i><b>Top-Left</b> CamBounds-Marker</i>'s position should be <b>Above and to the Left</b> of <i><b>Bottom-Right</b> CamBounds-Marker</i>'s position, by at least 2 units.", "warning", 10f);
            }
            else if(thisRoomCamTLPos.x < thisRoomCamBRPos.x && thisRoomCamTLPos.z <= thisRoomCamBRPos.z) {
                uiTx_camTL.text = string.Format("{0}, {1},<color=#E69F00>{2}</color>", thisRoomCamTLPos.x, thisRoomCamTLPos.y, thisRoomCamTLPos.z);
                uiImg_camTLSet.enabled = false;
                uiTx_camBR.text = string.Format("{0}, {1},<color=#E69F00>{2}</color>", thisRoomCamBRPos.x, thisRoomCamBRPos.y, thisRoomCamBRPos.z);
                uiImg_camBRSet.enabled = false;
                DebugConsole.Log("The <i><b>Top-Left</b> CamBounds-Marker</i>'s position should be <b>Above and to the Left</b> of <i><b>Bottom-Right</b> CamBounds-Marker</i>'s position, by at least 2 units.", "warning", 10f);
            }
            else if(thisRoomCamTLPos.x >= thisRoomCamBRPos.x && thisRoomCamTLPos.z <= thisRoomCamBRPos.z) {
                uiTx_camTL.text = string.Format("<color=#E69F00>{0}</color>, {1},<color=#E69F00>{2}</color>", thisRoomCamTLPos.x, thisRoomCamTLPos.y, thisRoomCamTLPos.z);
                uiImg_camTLSet.enabled = false;
                uiTx_camBR.text = string.Format("<color=#E69F00>{0}</color>, {1},<color=#E69F00>{2}</color>", thisRoomCamBRPos.x, thisRoomCamBRPos.y, thisRoomCamBRPos.z);
                uiImg_camBRSet.enabled = false;
                DebugConsole.Log("The <i><b>Top-Left</b> CamBounds-Marker</i>'s position should be <b>Above and to the Left</b> of <i><b>Bottom-Right</b> CamBounds-Marker</i>'s position, by at least 2 units.", "warning", 10f);
            }
        }
    }
}
