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
    [SerializeField] GameObject inAppMainPanel;
    [SerializeField] GameObject inAppSavePanel;
    [SerializeField] GameObject inAppLoadPanel;

    [SerializeField] GameObject ui_inAppDisplayName;
    [SerializeField] GameObject ui_inAppDisplayID;
    Text uiTxt_inAppDisplayName;
    Text uiTxt_inAppDisplayID;

    [SerializeField] GameObject ui_inAppSaveName;
    [SerializeField] GameObject ui_inAppSaveID;
    [SerializeField] GameObject ui_btnSaveSave;
    [SerializeField] GameObject ui_btnSaveCancel;

    [SerializeField] GameObject ui_btnLoadLoad;
    [SerializeField] GameObject ui_btnLoadCancel;
    [SerializeField] GameObject ui_dropdownInAppLoad;
    InputField uiIF_inAppSaveName;
    InputField uiIF_inAppSaveID;
    string saveNameString;
    string saveIDString;

    Dropdown uiDrop_dropdownInAppLoad;



    void Start() {
        AreaEntry_ReadWriteScript = GetComponent<AreaEntry_ReadWrite>();
        AreaObjectScript = GetComponent<AreaObjectRegistrar>();

        uiIF_devkey = devkeyField.GetComponent<InputField>();
        uiIF_createName = ui_createName.GetComponent<InputField>();
        uiIF_createID = ui_createID.GetComponent<InputField>();

        uiDrop_dropdownStartLoad = ui_dropdownStartLoad.GetComponent<Dropdown>();
        uiDrop_dropdownInAppLoad = ui_dropdownInAppLoad.GetComponent<Dropdown>();

        uiTxt_inAppDisplayName = ui_inAppDisplayName.GetComponent<Text>();
        uiTxt_inAppDisplayID = ui_inAppDisplayName.GetComponent<Text>();
      
        uiIF_inAppSaveName = ui_inAppSaveName.GetComponent<InputField>();
        uiIF_inAppSaveID = ui_inAppSaveID.GetComponent<InputField>();

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
        uiDrop_dropdownInAppLoad.options.Clear();

        foreach (AreaEntry_Base areaEntryObject in AreaEntry_ReadWriteScript.AreaCatalog_DataObject.areaEntries) {    
            AreaObjectScript.The_AreaCatalog.areaEntries.Add(areaEntryObject);                   

            tempString = string.Format("{0}| {1} ", areaEntryObject.AreaEntryID, areaEntryObject.AreaEntryName );       
            uiDrop_dropdownStartLoad.options.Add(new Dropdown.OptionData() {text = tempString} );
            uiDrop_dropdownInAppLoad.options.Add(new Dropdown.OptionData() {text = tempString} );
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

        uiTxt_inAppDisplayName.text = createNameString;
        uiIF_inAppSaveName.text = createNameString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_AreaIDInput() {
        createIDString = uiIF_createID.text;

        uiTxt_inAppDisplayID.text = createIDString;
        uiIF_inAppSaveID.text = createIDString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_GenerateID() {
        createIDString = string.Format("{0}.{1}", devKeyString, _AreaIndexCounter.ToString() );
        uiIF_createID.text = createIDString;

        uiTxt_inAppDisplayID.text = createIDString;
        uiIF_inAppSaveID.text = createIDString;

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
 
//---------------- InApp Menu  --------------------------------------------------
  

    public void InApp_OpenSaveMenu() {
        inAppMainPanel.SetActive(false);
        inAppSavePanel.SetActive(true);
    }

    public void InApp_OpenLoadMenu() {
        inAppMainPanel.SetActive(false);
        inAppLoadPanel.SetActive(true);
    }


//--------------- InApp Save -----------------------------------------------------

    public void iaSave_AreaNameInput() {
        saveNameString = uiIF_inAppSaveName.text;
        uiTxt_inAppDisplayName.text = saveIDString;

        if(saveNameString != "" && saveIDString != "") {
            ui_btnSaveSave.GetComponent<Button>().interactable = true;
        }
    }
    public void iaSave_AreaIDInput() {
        saveIDString = uiIF_inAppSaveID.text;
        uiTxt_inAppDisplayID.text = saveIDString;

        if(saveNameString != "" && saveIDString != "") {
            ui_btnSaveSave.GetComponent<Button>().interactable = true;
        }
    }
    public void iaSave_GenerateID() {
        saveIDString = string.Format("{0}.{1}", devKeyString, _AreaIndexCounter.ToString() );
        uiIF_inAppSaveID.text = saveIDString;
        uiTxt_inAppDisplayID.text = saveIDString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }

    public void  iaSave_CancelButton() {
        inAppSavePanel.SetActive(false);
        inAppMainPanel.SetActive(true);
    }


    public void  iaSave_SaveAreaButton() {
        AreaObjectScript.SaveAreaDataToXml(_AreaIndexCounter.ToString(), saveIDString, saveNameString);

        inAppSavePanel.SetActive(false);
        inAppMainPanel.SetActive(true);
    }








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
