using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AreaSaveLoadUI : MonoBehaviour {
    //============= Area Data List =========
    public List<Area_Base> AreasList;
    //========================================

    //-------- UI Refs ----------
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



    void PopulateAreaLoadDropdown() {
        
    }

  
    void SaveAreaData() {
        
    }

    void LoadAreaData() {
        
    }
   
 





}
