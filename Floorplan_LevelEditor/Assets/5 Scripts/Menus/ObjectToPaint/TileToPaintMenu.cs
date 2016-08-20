using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class TileToPaintMenu : MonoBehaviour {           //! @TODO: refactor/write this shit, this class should only handle displaying of the info, -- and setting TileFacingRot ... it shouldnt pass the variables thru it wtf 

    [SerializeField] GameObject tilePlacerObject;
    PlaceTile tilePlacerScript;
    [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;


    public static bool anInputFieldIsInFocus; 

    [SerializeField] GameObject databaseController;


//--------- Tile Data ---------------
    public float tileFacingRot  {get; protected set;}

    public int currentRoomID  {get; protected set;}
    public Color currentRoomColor {get; protected set;}

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
    Image uiCol_currRoomColorImg;

    Image uiImg_currTileIcon;




	void Start () {
        tilePlacerScript = tilePlacerObject.GetComponent<PlaceTile>();
        tilePlacerObject.SetActive(false);

        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();


        uiImg_currTileIcon = ui_ImgTileIcon.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColorImg = ui_RoomColor.GetComponent<Image>();

        uiImg_tileFacingSel_N = ui_TileFacingSel_N.transform.GetComponent<Image>();
        uiImg_tileFacingSel_E = ui_TileFacingSel_E.transform.GetComponent<Image>();
        uiImg_tileFacingSel_S = ui_TileFacingSel_S.transform.GetComponent<Image>();
        uiImg_tileFacingSel_W = ui_TileFacingSel_W.transform.GetComponent<Image>();

        tileFacingRot = 0;
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
        tileFacingRot = 0;
        uiImg_tileFacingSel_N.enabled = true;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_E() {
        tileFacingRot = 90;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = true;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_S() {
        tileFacingRot = 180;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = true;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_W() {
        tileFacingRot = 270;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = true; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }


    public void SetCurrentRoomID(int theRoomID) {                           //from RoomViewerMenu.cs   via   RoomViewerEntry.cs Instances
        currentRoomID = theRoomID;
        uiTxt_currRoomID.text = theRoomID.ToString();

        objInstantiatorScript.AssignRoomID(theRoomID);
    }

    public void SetCurrentRoomColor(Color theColor) {
        currentRoomColor = theColor;
        uiCol_currRoomColorImg.color = theColor;

        objInstantiatorScript.AssignRoomColor(theColor);
    }


    public void SetCurrentTileSprite(Sprite theSprite) {                    //from AssetViewerEntry_XXX.cs Instances
        uiImg_currTileIcon.sprite = theSprite;
    }

    public void SetCurrentTileGO(GameObject theGameObject) {
        tilePlacerScript.AssignTileToBePlaced(theGameObject);
    }

}
