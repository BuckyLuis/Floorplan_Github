using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileToPaintMenu : MonoBehaviour {

    [SerializeField] GameObject databaseController;


    int currentRoomID;
    Color currentRoomColor;


//------- UI Element Refs ------------
    [SerializeField] GameObject ui_ImgFloorStyle;
    [SerializeField] GameObject ui_ImgWallsStyle;
    [SerializeField] GameObject ui_TglNoWall;

    [SerializeField] GameObject ui_TxtRoomID;
    [SerializeField] GameObject ui_RoomColor;

    Image uiImg_currFloorStyle;
    Image uiImg_currWallsStyle;

    Text uiTxt_currRoomID;
    Color uiCol_currRoomColor;




	void Start () {
        uiImg_currFloorStyle = ui_ImgFloorStyle.GetComponent<Image>();
        uiImg_currWallsStyle = ui_ImgWallsStyle.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColor = ui_RoomColor.GetComponent<Image>().color;
	}
	
	void Update () {
	
	}
}
