using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AreaSaveLoadUI : MonoBehaviour {

    int _AreaIndexCounter;
    string currentGenAreaID;

    Area_ReadWrite Area_ReadWriteScript;
    AreaObject AreaObjectScript;

    Area_Base TheLoadedAreaObject;


    List<string> areasDropdownList = new List<string>();
    string tempString;

 // --- UI Refs ---
 //-------- Start Menu ----------------------------------
    [SerializeField] GameObject mainBlackoutPanel;

    [SerializeField] GameObject startMenuPanel;
    [SerializeField] GameObject startAreaLoadPanel;
    [SerializeField] GameObject startAreaCreatePanel;

    [SerializeField] GameObject devkeyField;

    [SerializeField] GameObject ui_createName;
    [SerializeField] GameObject ui_createID;
    [SerializeField] GameObject ui_btnCreateSave;

    [SerializeField] GameObject ui_dropdownStartLoad;
    [SerializeField] GameObject ui_btnLoadArea;

 //---------------- In Main Program ----------------
    [SerializeField] GameObject areaSavePanel;
    [SerializeField] GameObject areaLoadPanel;

    [SerializeField] GameObject ui_btnOpenSavePane;
    [SerializeField] GameObject ui_btnOpenLoadPane;
    [SerializeField] GameObject ui_displayName;
    [SerializeField] GameObject ui_displayID;

    [SerializeField] GameObject ui_btnSaveSave;
    [SerializeField] GameObject ui_btnSaveCancel;
    [SerializeField] GameObject ui_SaveName;
    [SerializeField] GameObject ui_SaveID;

    [SerializeField] GameObject ui_btnLoadLoad;
    [SerializeField] GameObject ui_btnLoadCancel;
    [SerializeField] GameObject ui_dropdownLoad;
    InputField uiIF_devkey;
    public static string devKeyString;

    InputField uiIF_createName;
    InputField uiIF_createID;
    string createNameString;
    string createIDString;

    Dropdown uiDrop_dropdownStartLoad;
    string ddItemString;
    int areaIndexIDfromDd;


//----------- in main program ------------
    InputField uiIF_saveName;
    InputField uiIF_saveID;

    Dropdown uiDrop_dropdownLoad;


    void Start() {
        Area_ReadWriteScript = GetComponent<Area_ReadWrite>();
        AreaObjectScript = GetComponent<AreaObject>();

        uiIF_devkey = devkeyField.GetComponent<InputField>();
        uiIF_createName = ui_createName.GetComponent<InputField>();
        uiIF_createID = ui_createID.GetComponent<InputField>();

        uiDrop_dropdownStartLoad = ui_dropdownStartLoad.GetComponent<Dropdown>();

        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = true;
        TileToPaintMenu.anInputFieldIsInFocus = true;

        GetAreaListFromXML();
    }
//------------------- Read AreaData from XML ----------------------- 

    void GetAreaListFromXML() {
        Area_ReadWriteScript.ReadXMLData();                                  //  <-----------  Call to ReadXMLData of Area_ReadWrite.cs 
        PopulateAreaLoadDropdowns();
    }

    void PopulateAreaLoadDropdowns() {
        uiDrop_dropdownStartLoad.options.Clear();
     //   uiDrop_dropdownLoad.options.Clear();

        if(Area_ReadWrite.Areas_DataObject != null) {
            foreach (Area_Base areaObject in Area_ReadWrite.Areas_DataObject.areas) {                                              
                tempString = string.Format("{0}|{1}|{2}", areaObject.IndexID, areaObject.AreaName, areaObject.AreaID);
                uiDrop_dropdownStartLoad.options.Add(new Dropdown.OptionData(tempString));
                uiDrop_dropdownLoad.options.Add(new Dropdown.OptionData(tempString));
                _AreaIndexCounter = int.Parse(areaObject.IndexID) + 1;
            }
        }
        else {      // if there is NO areas ever made
            _AreaIndexCounter = 0;
        }
    }

//--------------- Start Menu ----------------------------------------------

    public void OpenCreateMenu() {
        startMenuPanel.SetActive(false);
        startAreaCreatePanel.SetActive(true);
    }

    public void OpenLoadMenu() {
        startMenuPanel.SetActive(false);
        startAreaLoadPanel.SetActive(true);
    }
        
    public void DevKeyInput() {
        devKeyString = uiIF_devkey.text;
    }
//--------------- Start - Create New Area Menu -----------------------------------------
    public void Create_AreaNameInput() {
        createNameString = uiIF_createName.text;
        if(createNameString != null && createIDString != null) {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }

    public void Create_AreaIDInput() {
        createIDString = uiIF_createID.text;
        if(createNameString != null && createIDString != null) {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }

    public void Create_GenerateID() {
        createIDString = string.Format("{0}_{2}", devKeyString, _AreaIndexCounter );
        uiIF_createID.text = createIDString;
        if(createNameString != null && createIDString != null) {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }

    public void Create_CancelButton() {
        startAreaCreatePanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void Create_CreateAreaButton() {
        AreaObjectScript.Create_NewArea(_AreaIndexCounter.ToString(), createIDString, createNameString);
        KillStartMenu();
    }
        
//--------------- Start - Load Area Menu ----------------------------------------------

    public void Load_DropdownSelectInput() {
        ddItemString = uiDrop_dropdownStartLoad.itemText.text;
        string[] tempStringArray = ddItemString.Split('|');
        areaIndexIDfromDd = int.Parse(tempStringArray[0]);

        ui_btnLoadArea.GetComponent<Button>().interactable = true;
    }

    public void Load_CancelButton() {
        startAreaLoadPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void Load_LoadAreaButton() {
        TheLoadedAreaObject = Area_ReadWrite.Areas_DataObject.areas[areaIndexIDfromDd];
        AreaObjectScript.Load_LoadArea(TheLoadedAreaObject);
        KillStartMenu();
    }
 
//-------------------------------------------------------------------------------------
  
    public void SaveAreaData() {
        
    }

    public void LoadAreaData() {
        
    }


    void KillStartMenu() {
        mainBlackoutPanel.SetActive(false);
        MoveCamera.cameraLockForStartupMenu = false;
        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = false;
        TileToPaintMenu.anInputFieldIsInFocus = false;
    }
   
      



}
