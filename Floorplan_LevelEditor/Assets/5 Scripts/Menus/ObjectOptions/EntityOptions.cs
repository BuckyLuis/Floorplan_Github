using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntityOptions : MonoBehaviour {

    [SerializeField] GameObject tilePlacerObject;
    TilePlacer tilePlacerScript;
    [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;

    [SerializeField] GameObject databaseController;


    //--------- Tile Data ---------------

    public int currentRoomID  {get; protected set;}
    public Color currentRoomColor {get; protected set;}

    public int selectedTileIndex;

    //------- UI Element Refs ----------------

    [SerializeField] GameObject ui_TxtRoomID;
    [SerializeField] GameObject ui_RoomColor;

    [SerializeField] GameObject ui_ImgTileIcon;

    [SerializeField] GameObject ui_btnEntityPlacer;
    Button uiBtn_entityPlacer;


    Text uiTxt_currRoomID;
    Image uiCol_currRoomColorImg;

    Image uiImg_currTileIcon;





    void Start () {
        tilePlacerScript = tilePlacerObject.GetComponent<TilePlacer>();
        tilePlacerObject.SetActive(false);

        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();

        uiBtn_entityPlacer = ui_btnEntityPlacer.GetComponent<Button>();

        uiImg_currTileIcon = ui_ImgTileIcon.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColorImg = ui_RoomColor.GetComponent<Image>();

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
        tilePlacerScript.EntityPlacementMode(theGameObject);
        uiBtn_entityPlacer.interactable = true;
    }

}
