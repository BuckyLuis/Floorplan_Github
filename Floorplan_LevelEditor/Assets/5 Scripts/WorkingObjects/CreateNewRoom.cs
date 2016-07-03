using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateNewRoom : MonoBehaviour {

    AreaObject ourAreaObject;

    GameObject ui_newRoomPanel;
    GameObject ui_roomIDField;
    GameObject ui_roomNameField;
    GameObject ui_roomColor;
    GameObject ui_roomOriginButton;
    GameObject ui_newRoomConfirmButton;
    InputField uiTxt_roomIDField;
    InputField uiTxt_roomNameField;
    Color uiCol_roomColor;
    Text uiTxt_roomOriginText;
    Button uiBtn_newRoomConfirmButton;


//------------ Config These! -----------
    public int NewRoomID;
    string NewRoomIDstring;

    public string NewRoomName; 
    public Color NewRoomColor;
    public Vector3 NewRoomOriginPos;
//-------------------------------------

    public GameObject placer_NewROrigin;
    PlaceNewRoomOrigin newOriginPlacerScript;

    bool ableToConfirm = false;
    bool dialogIsActive = false;


    void Start() {
        ourAreaObject = GetComponent<AreaObject>();
        newOriginPlacerScript = placer_NewROrigin.GetComponent<PlaceNewRoomOrigin>();

        //---init Find UI fields---
        ui_newRoomPanel = GameObject.Find("Panel_NewRoom");

        ui_roomIDField = GameObject.Find("InputField_NewRmID");
        ui_roomNameField = GameObject.Find("InputField_NewRmName");
        ui_roomColor = GameObject.Find("Button_NewRmColor");
        ui_roomOriginButton = GameObject.Find("Button_NewRmPlaceOrigin"); 
        ui_newRoomConfirmButton = GameObject.Find("Button_NewRmConfirm");

        uiTxt_roomIDField = ui_roomIDField.GetComponent<InputField>();
        uiTxt_roomNameField = ui_roomNameField.GetComponent<InputField>();
        uiCol_roomColor = ui_roomColor.GetComponent<Image>().color;
        uiTxt_roomOriginText = ui_roomOriginButton.GetComponentInChildren<Text>();
        uiBtn_newRoomConfirmButton = ui_newRoomConfirmButton.GetComponent<Button>();


//----- figure default values -----
        NewRoomIDstring = "10"; //ourAreaObject.ThisAreaID + System.DateTime.Now.ToString("ddHHmm") + Random.Range(0, 9) + ourAreaObject.ThisAreasRooms.Count;
        NewRoomID = int.Parse(NewRoomIDstring);
        NewRoomName = NewRoomIDstring;

     /*   if(DistinctColorList.distinctColorsList.Count >= ourAreaObject.ThisAreasRooms.Count - 1) {
            NewRoomColor = DistinctColorList.distinctColorsList[ourAreaObject.ThisAreasRooms.Count];
        }
        else {
            NewRoomColor = new Color(255,0,0);
        }
*/
    //    NewRoomOriginPos = new Vector3 (ourAreaObject.ThisAreasRooms.Count, 0, -ourAreaObject.ThisAreasRooms.Count);
    }


    public void NewRoomUIEnable() {
        if(dialogIsActive == false) {
            ui_newRoomPanel.SetActive(true);
            ableToConfirm = false;
            dialogIsActive = true;
        }
    }


    void PassDefaultValues() {
        
    }

    public void ChangeRoomID() {
        NewRoomID = int.Parse(uiTxt_roomIDField.text);
    }

    public void ChangeRoomName() {
        NewRoomName = uiTxt_roomNameField.text;
    }

    public void ChangeRoomColor(Color theColor) {       //set from ColorPicker.cs
        NewRoomColor = theColor;
    }

    public void ChangeRoomOrigin() {
        placer_NewROrigin.SetActive(true);
        newOriginPlacerScript.roomID = NewRoomID;
        newOriginPlacerScript.roomName = NewRoomName;
        newOriginPlacerScript.roomColor = NewRoomColor;
    }

    public void OriginPosDecided(Vector3 theOriginPos) {
        NewRoomOriginPos = theOriginPos;
        uiTxt_roomOriginText.text = string.Format("( {0}x, {1}y, {2}z )", theOriginPos.x, theOriginPos.y, theOriginPos.z);
        ableToConfirm = true;
        uiBtn_newRoomConfirmButton.interactable = true;
    }

    public void ConfirmNewRoom() {
        dialogIsActive = false;
        ui_newRoomPanel.SetActive(false);     
    }

    public void CancelNewRoom() {
        dialogIsActive = false;
        ui_newRoomPanel.SetActive(false);
    }
}
   