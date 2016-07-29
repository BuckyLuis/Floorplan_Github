using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AreaSaveLoadUI : MonoBehaviour {

    int _AreaIndexCounter;
    string currentGenAreaID;


//---------------------------------------------------
    AreaEntry_ReadWrite AreaEntry_ReadWriteScript;
    AreaObjectRegistrar AreaObjectScript;

    Area_Base TheLoadedAreaObject;

  

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
    InputField uiIF_devkey;
    public static string devKeyString;

    InputField uiIF_createName;
    InputField uiIF_createID;
    string createNameString;
    string createIDString;

    Dropdown uiDrop_dropdownStartLoad;
    string tempString;
    List<string> areasDropdownList = new List<string>();

    string ddItemString;
    string areaIDfromDd;

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
    InputField uiIF_saveName;
    InputField uiIF_saveID;

    Dropdown uiDrop_dropdownLoad;



    void Start() {
        AreaEntry_ReadWriteScript = GetComponent<AreaEntry_ReadWrite>();
        AreaObjectScript = GetComponent<AreaObjectRegistrar>();

        uiIF_devkey = devkeyField.GetComponent<InputField>();
        uiIF_createName = ui_createName.GetComponent<InputField>();
        uiIF_createID = ui_createID.GetComponent<InputField>();

        uiDrop_dropdownStartLoad = ui_dropdownStartLoad.GetComponent<Dropdown>();

        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = true;
        TileToPaintMenu.anInputFieldIsInFocus = true;


        devKeyString = PlayerPrefs.GetString("DevKey");
        uiIF_devkey.text = devKeyString;

        GetAreaCatalogFromXML();
        PopulateCatalogNDropdowns();
    }
//------------------- Read AreaData from XML ----------------------- 

    void GetAreaCatalogFromXML() {
        AreaEntry_ReadWriteScript.ReadXMLData();     //  <-----------  Call to read AreaCatalog from Xml
    }

    void PopulateCatalogNDropdowns() {
        uiDrop_dropdownStartLoad.options.Clear();
     //   uiDrop_dropdownLoad.options.Clear();

        foreach (AreaEntry_Base areaEntryObject in AreaEntry_ReadWriteScript.AreaCatalog_DataObject.areaEntries) {    
            AreaObjectScript.The_AreaCatalog.areaEntries.Add(areaEntryObject);                   

            tempString = string.Format("{0}| {1} ", areaEntryObject.AreaEntryID, areaEntryObject.AreaEntryName );       
            uiDrop_dropdownStartLoad.options.Add(new Dropdown.OptionData() {text = tempString} );
            _AreaIndexCounter = int.Parse(areaEntryObject.IndexID) + 1;
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
        PlayerPrefs.SetString("DevKey", devKeyString);
    }
//--------------- Start - Create New Area Menu -----------------------------------------
    public void Create_AreaNameInput() {
        createNameString = uiIF_createName.text;
        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_AreaIDInput() {
        createIDString = uiIF_createID.text;
        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_GenerateID() {
        createIDString = string.Format("{0}.{1}", devKeyString, _AreaIndexCounter.ToString() );
        uiIF_createID.text = createIDString;
        if(createNameString != "" && createIDString != "") {
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
        ddItemString = uiDrop_dropdownStartLoad.captionText.text;
        string[] tempStringArray = ddItemString.Split('|');
        areaIDfromDd = tempStringArray[0];

        ui_btnLoadArea.GetComponent<Button>().interactable = true;
    }
    public void Load_CancelButton() {
        startAreaLoadPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }


    public void Load_LoadAreaButton() {
       AreaObjectScript.LoadAreaDataFromXml(areaIDfromDd);  
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
