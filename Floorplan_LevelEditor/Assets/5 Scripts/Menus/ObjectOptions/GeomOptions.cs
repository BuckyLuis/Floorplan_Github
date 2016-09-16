﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeomOptions : MonoBehaviour {           //! @TODO: refactor/write this shit, this class should only handle displaying of the info, -- and setting TileFacingRot ... it shouldnt pass the variables thru it wtf 
/*
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

    [SerializeField] GameObject ui_btnGeomPlacer;
    [SerializeField] GameObject ui_btnEntityPlacer;
    Button uiBtn_geomPlacer;
    Button uiBtn_entityPlacer;


    Text uiTxt_currRoomID;
    Image uiCol_currRoomColorImg;

    Image uiImg_currTileIcon;





	void Start () {
        tilePlacerScript = tilePlacerObject.GetComponent<TilePlacer>();
        tilePlacerObject.SetActive(false);

        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();

        uiBtn_geomPlacer = ui_btnGeomPlacer.GetComponent<Button>();
        uiBtn_entityPlacer = ui_btnEntityPlacer.GetComponent<Button>();

        uiImg_currTileIcon = ui_ImgTileIcon.GetComponent<Image>();
        uiTxt_currRoomID = ui_TxtRoomID.GetComponent<Text>();
        uiCol_currRoomColorImg = ui_RoomColor.GetComponent<Image>();

	}
	

    public void SetCurrentRoomID(int theRoomID) {                           //from RoomViewerMenu.cs   via   RoomViewerEntry.cs Instances
        currentRoomID = theRoomID;
        uiTxt_currRoomID.text = theRoomID.ToString();
    }

    public void SetCurrentRoomColor(Color theColor) {
        currentRoomColor = theColor;
        uiCol_currRoomColorImg.color = theColor;
    }


    public void SetCurrentTileSprite(Sprite theSprite) {                    //from AssetViewerEntry_XXX.cs Instances
        uiImg_currTileIcon.sprite = theSprite;
    }

    public void SetCurrentTileGO(GameObject theGameObject) {
        tilePlacerScript.GeomPlacementMode(theGameObject);
        uiBtn_entityPlacer.interactable = false;
        uiBtn_geomPlacer.interactable = true;
    }
*/
}
