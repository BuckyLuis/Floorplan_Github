using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TeamUtility.IO;

public class AreaSaveLoadUI : MonoBehaviour {

    int _AreaIndexCounter;
    int currentIndexCount;

    string currentGenAreaID;


    TimeSinceSave timeSinceSave = new TimeSinceSave();
    bool welcomeMenuActive;
    Color defaultTextCol = new Color(0,0,0);
    Color saveTimeWarningCol = new Color32(213, 94, 0, 255);

//---------------------------------------------------
    AreaEntry_ReadWrite AreaEntry_ReadWriteScript;
    AreaObjectRegistrar AreaRegistrarScript;
     

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

    [SerializeField] GameObject OptionsMainPanel;
    [SerializeField] GameObject OptionsSaveAsPanel;
    [SerializeField] GameObject OptionsLoadPanel;
    [SerializeField] GameObject OptionsCreateNewPanel;
    [SerializeField] GameObject OptionsQuitPanel;

    [SerializeField] GameObject ui_lastSaveTimeDisplay;
    Text uiTxt_lastSaveTimeDisplay;


    [SerializeField] GameObject ui_inAppDisplayName;
    [SerializeField] GameObject ui_inAppDisplayID;
    Text uiTxt_inAppDisplayName;
    Text uiTxt_inAppDisplayID;

    [SerializeField] GameObject ui_OptDisplayName;
    [SerializeField] GameObject ui_OptDisplayID;
    Text uiTxt_OptDisplayName;
    Text uiTxt_OptDisplayID;

    [SerializeField] GameObject ui_OptSaveAsName;
    [SerializeField] GameObject ui_OptSaveAsID;
    [SerializeField] GameObject ui_btnSaveAsSaveAs;
    [SerializeField] GameObject ui_btnSaveAsCancel;

    [SerializeField] GameObject ui_btnOptLoadLoad;
    [SerializeField] GameObject ui_btnOptLoadCancel;
    [SerializeField] GameObject ui_dropdownOptLoad;

    [SerializeField] GameObject ui_OptCreateName;
    [SerializeField] GameObject ui_OptCreateID;
    [SerializeField] GameObject ui_btnOptCreateNew;
    [SerializeField] GameObject ui_btnOptCreateCancel;
    Dropdown uiDrop_dropdownOptLoad;

    InputField uiIF_OptSaveAsName;
    InputField uiIF_OptSaveAsID;
    string saveAsNameString;
    string saveAsIDString;

    InputField uiIF_OptCreateNewName;
    InputField uiIF_OptCreateNewID;
    string createNewNameString;
    string createNewIDString;





    void Start() {
     //   welcomeMenuActive = true;

        AreaEntry_ReadWriteScript = GetComponent<AreaEntry_ReadWrite>();
        AreaRegistrarScript = GetComponent<AreaObjectRegistrar>();

        uiIF_devkey = devkeyField.GetComponent<InputField>();
        uiIF_createName = ui_createName.GetComponent<InputField>();
        uiIF_createID = ui_createID.GetComponent<InputField>();

        uiDrop_dropdownStartLoad = ui_dropdownStartLoad.GetComponent<Dropdown>();
        uiDrop_dropdownOptLoad = ui_dropdownOptLoad.GetComponent<Dropdown>();

        uiTxt_inAppDisplayName = ui_inAppDisplayName.GetComponent<Text>();
        uiTxt_inAppDisplayID = ui_inAppDisplayID.GetComponent<Text>();
        uiTxt_OptDisplayName = ui_OptDisplayName.GetComponent<Text>();
        uiTxt_OptDisplayID = ui_OptDisplayID.GetComponent<Text>();
      
        uiIF_OptSaveAsName = ui_OptSaveAsName.GetComponent<InputField>();
        uiIF_OptSaveAsID = ui_OptSaveAsID.GetComponent<InputField>();
        uiIF_OptCreateNewName = ui_OptCreateName.GetComponent<InputField>();
        uiIF_OptCreateNewID = ui_OptCreateID.GetComponent<InputField>();

        uiTxt_lastSaveTimeDisplay = ui_lastSaveTimeDisplay.GetComponent<Text>();


        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = true;
        GeomOptions.anInputFieldIsInFocus = true;

        devKeyString = PlayerPrefs.GetString("DevKey");
        uiIF_devkey.text = devKeyString;

        GetAreaCatalogFromXML();
        PopulateCatalogNDropdowns();
    }


    void Update() {
        if(InputManager.GetButtonDown("ToggleOptionsMenu")) {
            Opt_ToggleOptionsMenu();
        }
    }
//------------------- Read AreaData from XML ----------------------- 

    void GetAreaCatalogFromXML() {
        AreaEntry_ReadWriteScript.ReadXMLData();     //  <-----------  Call to read AreaCatalog from Xml
    }

    void PopulateCatalogNDropdowns() {
        uiDrop_dropdownStartLoad.options.Clear();
        uiDrop_dropdownOptLoad.options.Clear();

        foreach (AreaEntry_Base areaEntryObject in AreaEntry_ReadWriteScript.AreaCatalog_DataObject.areaEntries) {    
            AreaRegistrarScript.The_AreaCatalog.areaEntries.Add(areaEntryObject);                   

            tempString = string.Format("{0}| {1} ", areaEntryObject.AreaEntryID, areaEntryObject.AreaEntryName );       
            uiDrop_dropdownStartLoad.options.Add(new Dropdown.OptionData() {text = tempString} );
            uiDrop_dropdownOptLoad.options.Add(new Dropdown.OptionData() {text = tempString} );

            _AreaIndexCounter = int.Parse(areaEntryObject.IndexID);   
            currentIndexCount = _AreaIndexCounter;
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
        uiTxt_OptDisplayName.text = createNameString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_AreaIDInput() {
        createIDString = uiIF_createID.text;

        uiTxt_inAppDisplayID.text = createIDString;
        uiTxt_OptDisplayID.text = createIDString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_GenerateID() {
        currentIndexCount = _AreaIndexCounter + 1;

        createIDString = string.Format("{0}.{1}", devKeyString, currentIndexCount.ToString() );
        uiIF_createID.text = createIDString;

        uiTxt_inAppDisplayID.text = createIDString;
        uiTxt_OptDisplayID.text = createIDString;

        if(createNameString != "" && createIDString != "") {
            ui_btnCreateSave.GetComponent<Button>().interactable = true;
        }
    }
    public void Create_CancelButton() {
        startAreaCreatePanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }


    public void Create_CreateAreaButton() {
        AreaRegistrarScript.Create_NewArea(currentIndexCount.ToString(), createIDString, createNameString);
        _AreaIndexCounter += 1;
        KillStartMenu();
        welcomeMenuActive = false;
        DebugConsole.Log("A new .xml file for area: <b>" + createIDString + "|" + createNameString + "</b> has been created.", "normal", 7f);
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
       AreaRegistrarScript.LoadAreaDataFromXml(areaIDfromDd);  
       KillStartMenu();
       welcomeMenuActive = false;
       DebugConsole.Log("The area: <b>" + ddItemString + "</b> has been loaded, it is now the current Area", "normal", 7f);
    }
 
//---------------- Options Menu  --------------------------------------------------

    public void Opt_ToggleOptionsMenu() {
        if(welcomeMenuActive == false && OptionsMainPanel.activeSelf == false) {
            RefreshLastSaveTime();
            OptionsMainPanel.SetActive(true);
            mainBlackoutPanel.SetActive(true);
            MoveCamera.cameraLockForStartupMenu = true;
            AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = true;
            GeomOptions.anInputFieldIsInFocus = true;
        }
        else if (welcomeMenuActive == false && OptionsMainPanel.activeSelf == true){
            OptionsMainPanel.SetActive(false);
            KillStartMenu();
        }  
    }

    public void Opt_OpenSaveAsMenu() {
        OptionsMainPanel.SetActive(false);
        OptionsSaveAsPanel.SetActive(true);
    }

    public void Opt_OpenLoadMenu() {
        OptionsMainPanel.SetActive(false);
        OptionsLoadPanel.SetActive(true);
    }

    public void Opt_OpenCreateNewMenu() {
        OptionsMainPanel.SetActive(false);
        OptionsCreateNewPanel.SetActive(true);
    }

    public void Opt_OpenQuitMenu() {
        OptionsMainPanel.SetActive(false);
        OptionsQuitPanel.SetActive(true);
    }


//--------------- Time since Last Save ----------------------------------------------

    void RefreshLastSaveTime() {
        if(timeSinceSave.areaLastSaveTime != null) {
            uiTxt_lastSaveTimeDisplay.color = defaultTextCol;
            uiTxt_lastSaveTimeDisplay.text = timeSinceSave.TimeSinceLastSave();
        }
        else {
            uiTxt_lastSaveTimeDisplay.color = saveTimeWarningCol;
            uiTxt_lastSaveTimeDisplay.text = "<b>Area never Saved!</b>";
        }   
    }
        

//--------------- Options - Save ----------------------------------------------------

    public void OptSave_SaveAreaButton() {
        AreaRegistrarScript.SaveAreaDataToXml(currentIndexCount.ToString(), uiTxt_OptDisplayID.text, uiTxt_OptDisplayName.text);
        KillStartMenu();
        DebugConsole.Log("Changes to current loaded area: <b>" + uiTxt_OptDisplayID.text + "|" + uiTxt_OptDisplayName.text + "</b> has been saved to .xml file.", "normal", 7f);
        timeSinceSave.RegisterSaveTime();
    }
        
//--------------- Options - SaveAs -----------------------------------------------------

    public void OptSaveAs_AreaNameInput() {
        saveAsNameString = uiIF_OptSaveAsName.text;

        if(saveAsNameString != "" && saveAsIDString != "") {
            ui_btnSaveAsSaveAs.GetComponent<Button>().interactable = true;
        }
    }
    public void OptSaveAs_AreaIDInput() {
        saveAsIDString = uiIF_OptSaveAsID.text;

        if(saveAsNameString != "" && saveAsIDString != "") {
            ui_btnSaveAsSaveAs.GetComponent<Button>().interactable = true;
        }
    }
    public void OptSaveAs_GenerateID() {
        currentIndexCount = _AreaIndexCounter + 1;

        saveAsIDString = string.Format("{0}.{1}", devKeyString, currentIndexCount.ToString() );
        uiIF_OptSaveAsID.text = saveAsIDString;

        if(saveAsNameString != "" && saveAsIDString != "") {
            ui_btnSaveAsSaveAs.GetComponent<Button>().interactable = true;
        }
    }

    public void OptSaveAs_CancelButton() {
        OptionsSaveAsPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
    }

    public void OptSaveAs_SaveAreaButton() {
        AreaRegistrarScript.SaveAreaDataToXml(currentIndexCount.ToString(), saveAsIDString, saveAsNameString);
        _AreaIndexCounter += 1; 

        OptionsSaveAsPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
        KillStartMenu();
        DebugConsole.Log("A new .xml file for area: <b>" + saveAsIDString + "|" + saveAsNameString + "</b> has been created and saved.", "normal", 7f);
        timeSinceSave.RegisterSaveTime();

        uiTxt_inAppDisplayName.text = saveAsNameString;
        uiTxt_inAppDisplayID.text = saveAsIDString;
        uiTxt_OptDisplayName.text = saveAsNameString;
        uiTxt_OptDisplayID.text = saveAsIDString;

    }
        
//--------------- Options - Load Area Menu ----------------------------------------------

    public void OptLoad_DropdownSelectInput() {
        ddItemString = uiDrop_dropdownOptLoad.captionText.text;
        string[] tempStringArray = ddItemString.Split('|');
        areaIDfromDd = tempStringArray[0];

        ui_btnOptLoadLoad.GetComponent<Button>().interactable = true;
    }
    public void OptLoad_CancelButton() {
        OptionsLoadPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
        KillStartMenu();
    }


    public void OptLoad_LoadAreaButton() {
        AreaRegistrarScript.LoadAreaDataFromXml(areaIDfromDd);  
        OptionsLoadPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
        KillStartMenu();
        DebugConsole.Log("The area: <b>" + ddItemString + "</b> has been loaded, it is now the current Area", "normal", 7f);
    } 
        
//----------------- Options - Create New ---------------------------------------------------------------

    public void OptCreate_AreaNameInput() {
        createNewNameString = uiIF_OptCreateNewName.text;

        if(createNewNameString != "" && createNewIDString != "") {
            ui_btnOptCreateNew.GetComponent<Button>().interactable = true;
        }
    }
    public void OptCreate_AreaIDInput() {
        createNewIDString = uiIF_OptCreateNewID.text;

        if(createNewNameString != "" && createNewIDString != "") {
            ui_btnOptCreateNew.GetComponent<Button>().interactable = true;
        }
    }
    public void OptCreate_GenerateID() {
        currentIndexCount = _AreaIndexCounter + 1;

        createNewIDString = string.Format("{0}.{1}", devKeyString, currentIndexCount.ToString() );
        uiIF_OptCreateNewID.text = createNewIDString;
      
        if(createNewNameString != "" && createNewIDString != "") {
            ui_btnOptCreateNew.GetComponent<Button>().interactable = true;
        }
    }

    public void OptCreate_CancelButton() {
        OptionsCreateNewPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
    }

    public void OptCreate_CreateAreaButton() {
        AreaRegistrarScript.Create_NewArea(currentIndexCount.ToString(), createIDString, createNameString);
        _AreaIndexCounter += 1;

        OptionsCreateNewPanel.SetActive(false);
        OptionsMainPanel.SetActive(true);
        KillStartMenu();
        DebugConsole.Log("A new .xml file for area: <b>" + createIDString + "|" + createNameString + "</b> has been created.", "normal", 7f);

        uiTxt_inAppDisplayName.text = createNewNameString;
        uiTxt_inAppDisplayID.text = createNewIDString;
        uiTxt_OptDisplayName.text = createNewNameString;
        uiTxt_OptDisplayID.text = createNewIDString;
    }

//------------------- Options - Quit ------------------------------------------------------

    public void OptQuit_CancelButton() {
       OptionsQuitPanel.SetActive(false);
       OptionsMainPanel.SetActive(true);
    }

    public void OptQuit_QuitButton() {
       Application.Quit();
    }

//-----------------------------------------------------------------------------------------


    void KillStartMenu() {
        mainBlackoutPanel.SetActive(false);
        MoveCamera.cameraLockForStartupMenu = false;
        AssetsViewerHotkeysUiControl.anInputFieldIsInFocus = false;
        GeomOptions.anInputFieldIsInFocus = false;
    }
   
      



}
