using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentSelectionAndDisplay : MonoBehaviour {

    [SerializeField] GameObject tilePlacerObject;
    TilePlacer tilePlacerScript;
    [SerializeField] GameObject toolsController;
    [SerializeField] GameObject databaseController;
   
    public bool geom0_entity1;

    public GameObject tilePlacerWidget;
    public GameObject theTileToPlace;


    //--------- Tile Data ---------------
    public string currentRoomID  {get; protected set;}
    public Color currentRoomColor {get; protected set;}

    //------- UI Element Refs ----------------

    [SerializeField] GameObject ui_TxtRoomID;
    [SerializeField] GameObject ui_RoomColor;

    [SerializeField] GameObject ui_ImgTileIcon;


    Text uiTxt_currRoomID;
    Image uiCol_currRoomColorImg;

    Image uiImg_currTileIcon;



    void Start () {
        tilePlacerScript = tilePlacerObject.GetComponent<TilePlacer>();
        tilePlacerObject.SetActive(false);

        uiImg_currTileIcon = ui_ImgTileIcon.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColorImg = ui_RoomColor.GetComponent<Image>();
    }

    public void SetCurrentRoomID(string theRoomID) {                           //from RoomViewerMenu.cs   via   RoomViewerEntry.cs Instances
        currentRoomID = theRoomID;
        uiTxt_currRoomID.text = theRoomID;
    }

    public void SetCurrentRoomColor(Color theColor) {
        currentRoomColor = theColor;
        uiCol_currRoomColorImg.color = theColor;
    }
        
    public void SetCurrentTileSprite(Sprite theSprite) {                    //from AssetViewerEntry_XXX.cs Instances
        uiImg_currTileIcon.sprite = theSprite;
    }

    public void SetCurrentTileGO(GameObject theGameObject) {
        theTileToPlace = theGameObject;
    }

}
