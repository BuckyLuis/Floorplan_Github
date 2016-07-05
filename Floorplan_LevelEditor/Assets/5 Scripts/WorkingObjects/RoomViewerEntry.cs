using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomViewerEntry : MonoBehaviour {

    [SerializeField] GameObject databaseController;

    AreaObject ourAreaObject;
    RoomViewerMenu theRoomViewerMenu;

    [SerializeField]GameObject uiPanel_colorPicker;

//------------ Config These! --------------------
    public int thisRoomIndex;
    public int thisRoomID;
    string thisRoomIDstring;

    public string thisRoomName; 
    public Color thisRoomColor;
    public Vector3 thisRoomCamTLPos;
    public Vector3 thisRoomCamBRPos;

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
    Color uiC_roomColor;
    Button uiBtn_roomColor;
    public Toggle uiTgl_activeRoom;
    Text uiTx_camTL;
    Text uiTx_camBR;
    Button uiBtn_camTL;
    Button uiBtn_camBR;
    ToggleGroup uiTG_activeRoomTGroup;


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
        uiC_roomColor = ui_btnRoomColor.GetComponent<Image>().color;
        uiBtn_roomColor = ui_btnRoomColor.GetComponent<Button>();
        uiTgl_activeRoom = ui_tglActiveRoom.GetComponent<Toggle>();
        uiTx_camTL = ui_btnCamTL.GetComponent<Text>();
        uiTx_camBR = ui_btnCamBR.GetComponent<Text>();
        uiBtn_camTL = ui_btnCamTL.GetComponent<Button>();
        uiBtn_camBR = ui_btnCamBR.GetComponent<Button>();

        uiTgl_activeRoom.group = databaseController.GetComponent<ToggleGroup>();

        SetRoomIndex();
        theRoomViewerMenu.roomEntries.Add(gameObject);
        AssignButtonListeners();
        DeactivateRoomEntry();
        if(theRoomViewerMenu.userIsEditingAnEntry == true)
            uiTgl_activeRoom.interactable = false;
	}

    public void SetRoomIndex() {
        uiTx_RoomIndex.text = theRoomViewerMenu.roomEntries.Count.ToString();
        thisRoomIndex = theRoomViewerMenu.roomEntries.Count;
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
        thisRoomID = int.Parse(uiIF_roomID.text);
    }
	
    public void ChangeRoomName() {
        thisRoomName = uiIF_roomName.text;
    }

    public void ChangeRoomColor(Color theColor) {       //set from ColorPicker.cs
        thisRoomColor = theColor;
        theRoomViewerMenu.ActivateToggles();
    }

    public void ToggleActiveRoom(bool toggleStatus) {
        if(toggleStatus == true) {
            theRoomViewerMenu.activeRoomIndex = thisRoomIndex;
            ActivateRoomEntry();
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

    public void CamBoundsTLDHasSet(Vector3 theTLPos) {
        theRoomViewerMenu.ActivateToggles();
        thisRoomCamTLPos = theTLPos;
    }

    public void CamBoundsBRHasSet(Vector3 theBRPos) {
        theRoomViewerMenu.ActivateToggles();
        thisRoomCamBRPos = theBRPos;
    }
}
