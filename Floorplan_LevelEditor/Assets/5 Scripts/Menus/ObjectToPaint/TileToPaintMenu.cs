using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class TileToPaintMenu : MonoBehaviour {

    public static bool anInputFieldIsInFocus = false; 

    [SerializeField] GameObject databaseController;



    Color currentRoomColor;

//--------- Tile Data ---------------
    int currentRoomID;
 
    public int categoryIndex;
    public int tileIndex;

    public int tileFacingFlag;

//------- UI Element Refs ----------------
    [SerializeField] GameObject ui_BtnTile;

    [SerializeField] GameObject ui_TxtRoomID;
    [SerializeField] GameObject ui_RoomColor;

    [SerializeField] GameObject ui_TileFacingSel_N;
    [SerializeField] GameObject ui_TileFacingSel_E;
    [SerializeField] GameObject ui_TileFacingSel_S;
    [SerializeField] GameObject ui_TileFacingSel_W;

    Image uiImg_currTile;

    Text uiTxt_currRoomID;
    Color uiCol_currRoomColor;

    Image uiImg_tileFacingSel_N;
    Image uiImg_tileFacingSel_E;
    Image uiImg_tileFacingSel_S;
    Image uiImg_tileFacingSel_W;




	void Start () {
        uiImg_currTile = ui_BtnTile.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColor = ui_RoomColor.GetComponent<Image>().color;

        uiImg_tileFacingSel_N = ui_TileFacingSel_N.transform.GetComponent<Image>();
        uiImg_tileFacingSel_E = ui_TileFacingSel_E.transform.GetComponent<Image>();
        uiImg_tileFacingSel_S = ui_TileFacingSel_S.transform.GetComponent<Image>();
        uiImg_tileFacingSel_W = ui_TileFacingSel_W.transform.GetComponent<Image>();

        tileFacingFlag = 0;
        uiImg_tileFacingSel_N.enabled = true;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 
	}
	
	void Update () {
        if(anInputFieldIsInFocus == false) {
            if(InputManager.GetAxis("Vertical") > 0) {      // W - N
                TileFacing_N();
            }

            if(InputManager.GetAxis("Horizontal") > 0) {    // D - E
                TileFacing_E();
            }

            if(InputManager.GetAxis("Vertical") < 0) {      // S - S
                TileFacing_S();
            }

            if(InputManager.GetAxis("Horizontal") < 0) {    // A - W
                TileFacing_W();
            }
        }

	}

    public void TileFacing_N() {
        tileFacingFlag = 0;
        uiImg_tileFacingSel_N.enabled = true;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 
    }

    public void TileFacing_E() {
        tileFacingFlag = 1;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = true;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 
    }

    public void TileFacing_S() {
        tileFacingFlag = 2;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = true;
        uiImg_tileFacingSel_W.enabled = false; 
    }

    public void TileFacing_W() {
        tileFacingFlag = 3;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = true; 
    }


}
