using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class TileToPaintMenu : MonoBehaviour {

    [SerializeField] GameObject tilePlacerObject;
    PlaceTile tilePlacerScript;

    public static bool anInputFieldIsInFocus = false; 

    [SerializeField] GameObject databaseController;


//--------- Tile Data ---------------
    public int tileFacingFlag  {get; protected set;}

    public int currentRoomID  {get; protected set;}
    public Color currentRoomColor {get; protected set;}
 
    public Sprite tileIconSprite  {get; protected set;}
    public GameObject tileGameObject {get; protected set;}

 

    public int selectedTileIndex;

//------- UI Element Refs ----------------
   
    [SerializeField] GameObject ui_TileFacingSel_N;
    [SerializeField] GameObject ui_TileFacingSel_E;
    [SerializeField] GameObject ui_TileFacingSel_S;
    [SerializeField] GameObject ui_TileFacingSel_W;

    [SerializeField] GameObject ui_TxtRoomID;
    [SerializeField] GameObject ui_RoomColor;

    [SerializeField] GameObject ui_ImgTileIcon;

    Image uiImg_tileFacingSel_N;
    Image uiImg_tileFacingSel_E;
    Image uiImg_tileFacingSel_S;
    Image uiImg_tileFacingSel_W;

    Text uiTxt_currRoomID;
    Color uiCol_currRoomColor;

    Image uiImg_currTileIcon;




	void Start () {
        tilePlacerObject = GameObject.FindWithTag("TilePlacer");
        tilePlacerScript = tilePlacerObject.GetComponent<PlaceTile>();

        uiImg_currTileIcon = ui_ImgTileIcon.GetComponent<Image>();
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
                tilePlacerScript.AssignFacingYrot(tileFacingFlag);
            }

            if(InputManager.GetAxis("Horizontal") > 0) {    // D - E
                TileFacing_E();
                tilePlacerScript.AssignFacingYrot(tileFacingFlag);
            }

            if(InputManager.GetAxis("Vertical") < 0) {      // S - S
                TileFacing_S();
                tilePlacerScript.AssignFacingYrot(tileFacingFlag);
            }

            if(InputManager.GetAxis("Horizontal") < 0) {    // A - W
                TileFacing_W();
                tilePlacerScript.AssignFacingYrot(tileFacingFlag);
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


    public void SetCurrentRoomID(int theRoomID) {                           //from RoomViewerMenu.cs   via   RoomViewerEntry.cs Instances
        currentRoomID = theRoomID;
        uiTxt_currRoomID.text = theRoomID.ToString();

        tilePlacerScript.AssignRoomID(theRoomID);
    }

    public void SetCurrentRoomColor(Color theColor) {
        currentRoomColor = theColor;
        uiCol_currRoomColor = theColor;

        tilePlacerScript.AssignRoomColor(theColor);
    }


    public void SetCurrentTileSprite(Sprite theSprite) {                    //from AssetViewerEntry_XXX.cs Instances
        tileIconSprite = theSprite;
        uiImg_currTileIcon.sprite = theSprite;
    }

    public void SetCurrentTileGO(GameObject theGameObject) {
        tileGameObject = theGameObject;

        tilePlacerScript.AssignTileToBePlaced(theGameObject);
    }

}
