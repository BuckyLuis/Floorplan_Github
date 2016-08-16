using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class AssetsViewerHotkeysUiControl : MonoBehaviour {

    public static bool anInputFieldIsInFocus;

    AssetsViewerAssetManagement assetManagerScript;

    int keyPressed;
    int hotkeyStage = 0;
    Color hotkeyStageColor;
    Color hkS_Pages = new Color32(0, 114, 178, 255);    //0
    Color hkS_Category = new Color32(0, 158, 115, 255); //1
    Color hkS_ObjectA = new Color32(213, 94, 0, 255);   //2
    Color hkS_ObjectB = new Color32(230, 159, 0, 255);  //3

    bool isHkStageTimerOn = false;
    public float hkStageDuration = 2f;
    float hkStageResetTimer;

    public bool allowHkAutoReset = false;
    bool isAutoResetTimerOn = false;
    public float hkAutoResetDuration = 4f;
    float hkAutoResetTimer;

    int currentPage;
    int currentCategory;

    string entryDictKey;

#region - vars UI Element References -
//------------  UI Element Refs -----------------
    [SerializeField] GameObject btn_Floors;
    [SerializeField] GameObject btn_Walls;
    [SerializeField] GameObject btn_Doodads;
    [SerializeField] GameObject btn_Props;
    [SerializeField] GameObject btn_Actors;
    [SerializeField] GameObject btn_Triggers;
    Image uiImg_HighlightFloors;
    Image uiImg_HighlightWalls;
    Image uiImg_HighlightDoodads;
    Image uiImg_HighlightProps;
    Image uiImg_HighlightActors;
    Image uiImg_HighlightTriggers;

    [SerializeField] GameObject sv_Floors;
    [SerializeField] GameObject sv_Walls;
    [SerializeField] GameObject sv_Doodads;
    [SerializeField] GameObject sv_Props;
    [SerializeField] GameObject sv_Actors;
    [SerializeField] GameObject sv_Triggers;

    [SerializeField] GameObject header_Floors;
    [SerializeField] GameObject header_Walls;
    [SerializeField] GameObject header_Doodads;
    [SerializeField] GameObject header_Props;
    [SerializeField] GameObject header_Actors;
    [SerializeField] GameObject header_Triggers;
    Image uiImg_HlFloorCat1;
    Image uiImg_HlFloorCat2;
    Image uiImg_HlFloorCat3;
    Image uiImg_HlFloorCat4;

    Image uiImg_HlWallsCat1;
    Image uiImg_HlWallsCat2;
    Image uiImg_HlWallsCat3;
    Image uiImg_HlWallsCat4;

    Image uiImg_HlDoodadsCat1;
    Image uiImg_HlDoodadsCat2;
    Image uiImg_HlDoodadsCat3;
    Image uiImg_HlDoodadsCat4;

    Image uiImg_HlPropsCat1;
    Image uiImg_HlPropsCat2;
    Image uiImg_HlPropsCat3;
    Image uiImg_HlPropsCat4;

    Image uiImg_HlActorsCat1;
    Image uiImg_HlActorsCat2;
    Image uiImg_HlActorsCat3;
    Image uiImg_HlActorsCat4;

    Image uiImg_HlTriggersCat1;
    Image uiImg_HlTriggersCat2;
    Image uiImg_HlTriggersCat3;
    Image uiImg_HlTriggersCat4;

  /*  [SerializeField] GameObject view_Floors;
    [SerializeField] GameObject view_Walls;
    [SerializeField] GameObject view_Doodads;
    [SerializeField] GameObject view_Props;
    [SerializeField] GameObject view_Actors;
    [SerializeField] GameObject view_Triggers;*/
//--------------------------------------------------
    [SerializeField] GameObject tgl_allowAutoReset;
    Toggle uiTgl_allowAutoReset;

    [SerializeField] GameObject ui_txtLastHotkeyEntered;
    [SerializeField] GameObject ui_imgHotkeyStage;
    Text uiTxt_lastHotkeyEntered;
    Image uiImg_hotkeyStage;
#endregion


	void Start () {
        assetManagerScript = GetComponent<AssetsViewerAssetManagement>();

        uiImg_hotkeyStage = ui_imgHotkeyStage.GetComponent<Image>();
        uiTxt_lastHotkeyEntered = ui_txtLastHotkeyEntered.GetComponent<Text>();
        HotkeyStageColor();

        uiImg_HighlightFloors = btn_Floors.transform.GetChild(2).GetComponent<Image>();
        uiImg_HighlightWalls = btn_Walls.transform.GetChild(2).GetComponent<Image>();
        uiImg_HighlightDoodads = btn_Doodads.transform.GetChild(2).GetComponent<Image>();
        uiImg_HighlightProps = btn_Props.transform.GetChild(2).GetComponent<Image>();
        uiImg_HighlightActors = btn_Actors.transform.GetChild(2).GetComponent<Image>();
        uiImg_HighlightTriggers = btn_Triggers.transform.GetChild(2).GetComponent<Image>();

        uiImg_HighlightFloors.enabled = false;
        uiImg_HighlightWalls.enabled = false;
        uiImg_HighlightDoodads.enabled = false;
        uiImg_HighlightProps.enabled = false; 
        uiImg_HighlightActors.enabled = false; 
        uiImg_HighlightTriggers.enabled = false; 

        uiImg_HlFloorCat1 = header_Floors.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlFloorCat2 = header_Floors.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlFloorCat3 = header_Floors.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlFloorCat4 = header_Floors.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlFloorCat1.enabled = false;
        uiImg_HlFloorCat2.enabled = false;
        uiImg_HlFloorCat3.enabled = false;
        uiImg_HlFloorCat4.enabled = false;

        uiImg_HlWallsCat1 = header_Walls.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlWallsCat2 = header_Walls.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlWallsCat3 = header_Walls.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlWallsCat4 = header_Walls.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlWallsCat1.enabled = false;
        uiImg_HlWallsCat2.enabled = false;
        uiImg_HlWallsCat3.enabled = false;
        uiImg_HlWallsCat4.enabled = false;

        uiImg_HlDoodadsCat1 = header_Doodads.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlDoodadsCat2 = header_Doodads.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlDoodadsCat3 = header_Doodads.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlDoodadsCat4 = header_Doodads.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlDoodadsCat1.enabled = false;
        uiImg_HlDoodadsCat2.enabled = false;
        uiImg_HlDoodadsCat3.enabled = false;
        uiImg_HlDoodadsCat4.enabled = false;

        uiImg_HlPropsCat1 = header_Props.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlPropsCat2 = header_Props.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlPropsCat3 = header_Props.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlPropsCat4 = header_Props.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlPropsCat1.enabled = false;
        uiImg_HlPropsCat2.enabled = false;
        uiImg_HlPropsCat3.enabled = false;
        uiImg_HlPropsCat4.enabled = false;

        uiImg_HlActorsCat1 = header_Actors.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlActorsCat2 = header_Actors.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlActorsCat3 = header_Actors.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlActorsCat4 = header_Actors.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlActorsCat1.enabled = false;
        uiImg_HlActorsCat2.enabled = false;
        uiImg_HlActorsCat3.enabled = false;
        uiImg_HlActorsCat4.enabled = false;

        uiImg_HlTriggersCat1 = header_Triggers.transform.GetChild(1).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlTriggersCat2 = header_Triggers.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlTriggersCat3 = header_Triggers.transform.GetChild(3).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlTriggersCat4 = header_Triggers.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>();
        uiImg_HlTriggersCat1.enabled = false;
        uiImg_HlTriggersCat2.enabled = false;
        uiImg_HlTriggersCat3.enabled = false;
        uiImg_HlTriggersCat4.enabled = false;

        uiTgl_allowAutoReset = tgl_allowAutoReset.GetComponent<Toggle>();

        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

	}
	
    void Update () {
//----------------------- Timers --------------------------
        if(isHkStageTimerOn == true) {
            hkStageResetTimer -= Time.deltaTime;

            if(hkStageResetTimer <= 0) {
                hotkeyStage = 2;
                HotkeyStageColor();
                isHkStageTimerOn = false;
            }
        }

        if(isAutoResetTimerOn == true && allowHkAutoReset == true) {
            hkAutoResetTimer -= Time.deltaTime;

            if(hkAutoResetTimer <= 0) {
                hotkeyStage = 0;
                HotkeyStageColor();
                isAutoResetTimerOn = false;
            }
        }
            
//--------------------  Manual Set hkStage --------------
        if(anInputFieldIsInFocus == false) {
            if(InputManager.GetButtonDown("F1")) {
                isHkStageTimerOn = false;
                isAutoResetTimerOn = false;

                hotkeyStage = 0;
                uiTxt_lastHotkeyEntered.text = "|<";
                HotkeyStageColor();
            }
            if(InputManager.GetButtonDown("F2")) {
                if(hotkeyStage > 0) {
                    hotkeyStage--;
                    uiTxt_lastHotkeyEntered.text = "<";
                    HotkeyStageColor();
                }
            }
            if(InputManager.GetButtonDown("F3")) {
                if(hotkeyStage < 2) {
                    hotkeyStage++;
                    uiTxt_lastHotkeyEntered.text = ">";
                    HotkeyStageColor();
                }
            }
            if(InputManager.GetButtonDown("F4")) {
                hotkeyStage = 2;
                uiTxt_lastHotkeyEntered.text = ">|";
                HotkeyStageColor();
            }

    //-----------------  Hotkey Inputs -----------------
            if(InputManager.GetButtonDown("1")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}1",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "1";
                }
                keyPressed = 1;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("2")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}2",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "2";
                }
                keyPressed = 2;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("3")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}3",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "3";
                }
                keyPressed = 3;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("4")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}4",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "4";
                }
                keyPressed = 4;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("5")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}5",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "5";
                }
                keyPressed = 5;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("6")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}6",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "6";
                }
                keyPressed = 6;   
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("7")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}7",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "7";
                }
                keyPressed = 7;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("8")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}8",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "8";
                }
                keyPressed = 8;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("9")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}9",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "9";
                }
                keyPressed = 9;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
            if(InputManager.GetButtonDown("0")) {
                if(hotkeyStage == 3) {
                    uiTxt_lastHotkeyEntered.text = string.Format("{0}0",keyPressed);
                }
                else {
                    uiTxt_lastHotkeyEntered.text = "0";
                }
                keyPressed = 0;
                HotkeyAuto_ResetTimer();
                HotkeyWasPressed();
            }
        } //end of InputFieldInFocus test
	}

 #region -- == HotkeyWasPressed == --
    void HotkeyWasPressed() {
        switch (hotkeyStage) {
            case 0:         //---------------- Pages -----------------  
                switch (keyPressed) {
                    case 1: 
                        SetFloorsPage();
                        break;  
                    case 2: 
                        SetWallsPage();
                        break;  
                    case 3: 
                        SetDoodadsPage();
                        break;  
                    case 4: 
                        SetPropsPage();
                        break;  
                    case 5: 
                        SetActorsPage();
                        break;  
                    case 6: 
                        SetTriggersPage();
                        break;  
                }    
                break; 
            case 1:         //---------------- Categories ---------- 
                switch (currentPage) {
                    case 1:                         //floors Categories
                        switch (keyPressed) {
                            case 1: 
                                FloorCategory1();
                                break;  
                            case 2: 
                                FloorCategory2();
                                break;  
                            case 3: 
                                FloorCategory3();
                                break;  
                            case 4: 
                                FloorCategory4();
                                break;  
                        }    
                        break;  
                    case 2:                          //walls Categories
                        switch (keyPressed) {
                            case 1: 
                                WallsCategory1();
                                break;  
                            case 2: 
                                WallsCategory2();
                                break;  
                            case 3: 
                                WallsCategory3();
                                break;  
                            case 4: 
                                WallsCategory4();
                                break;  
                        }    
                        break;  
                    case 3:                         //doodads Categories
                        switch (keyPressed) {
                            case 1: 
                                DoodadsCategory1();
                                break;  
                            case 2: 
                                DoodadsCategory2();
                                break;  
                            case 3: 
                                DoodadsCategory3();
                                break;  
                            case 4: 
                                DoodadsCategory4();
                                break;  
                        }    
                        break;  
                    case 4:                         //props Categories
                        switch (keyPressed) {
                            case 1: 
                                PropsCategory1();
                                break;  
                            case 2: 
                                PropsCategory2();
                                break;  
                            case 3: 
                                PropsCategory3();
                                break;  
                            case 4: 
                                PropsCategory4();
                                break;  
                        }    
                        break;  
                    case 5:                         //actors Categories
                        switch (keyPressed) {
                            case 1: 
                                ActorsCategory1();
                                break;  
                            case 2: 
                                ActorsCategory2();
                                break;  
                            case 3: 
                                ActorsCategory3();
                                break;  
                            case 4: 
                                ActorsCategory4();
                                break;  
                        }    
                        break;
                    case 6:                         //triggers Categories
                        switch (keyPressed) {
                            case 1: 
                                TriggersCategory1();
                                break;  
                            case 2: 
                                TriggersCategory2();
                                break;  
                            case 3: 
                                TriggersCategory3();
                                break;  
                            case 4: 
                                TriggersCategory4();
                                break;  
                        }    
                        break;
                }    
                break;  
            case 2:         //---------------- Assets ----------
                HotkeyPressedAssetsFirstDigit();                            
                isHkStageTimerOn = true;
                hkStageResetTimer = hkStageDuration;
                break;  
            case 3: 
                HotkeyPressedAssetsSecondDigit();
                isHkStageTimerOn = true;
                hkStageResetTimer = hkStageDuration;
                break; 
        }    
    }


    void HotkeyPressedAssetsFirstDigit() {
        hotkeyStage = 3;
        HotkeyStage_ResetTimer();
        HotkeyStageColor();

        entryDictKey = ((currentCategory - 1) % 10).ToString() + "," + keyPressed;      //we have the currentCategory var as: for example: "11" , this represents 'Page 1, category 1' in concern for the user's display ... but category "1" is enum index of 0 :: we want "0"
        assetManagerScript.EntryFromHotkey(currentPage, entryDictKey);
    }

    void HotkeyPressedAssetsSecondDigit() {
        hotkeyStage = 2;
        HotkeyStage_ResetTimer();
        HotkeyStageColor();

        entryDictKey = ((currentCategory - 1) % 10).ToString() + "," + keyPressed;
        assetManagerScript.EntryFromHotkey(currentPage, entryDictKey);
    }
#endregion
        
#region HotkeyTimerMethods
    void HotkeyStageColor() {
        switch (hotkeyStage) {
            case 0: 
                hotkeyStageColor = hkS_Pages;
                break;  
            case 1: 
                hotkeyStageColor = hkS_Category;
                break;  
            case 2: 
                hotkeyStageColor = hkS_ObjectA;
                break;  
            case 3: 
                hotkeyStageColor = hkS_ObjectB;
                break;  
        }
        uiImg_hotkeyStage.color = hotkeyStageColor;
    }

    void HotkeyStage_ResetTimer() {
        isHkStageTimerOn = true;
        hkStageResetTimer = hkStageDuration;
    }

    void HotkeyAuto_ResetTimer() {
        if(allowHkAutoReset == true) {
            isAutoResetTimerOn = true;
            hkAutoResetTimer = hkAutoResetDuration;
        }
    }

    public void ToggleAllowAutoReset() {
        if(uiTgl_allowAutoReset.isOn == false) {     //guess the Toggle Unity component sets it before the Method here is called.
            allowHkAutoReset = false;
        }
        if(uiTgl_allowAutoReset.isOn == true) {
            allowHkAutoReset = true;
            HotkeyAuto_ResetTimer();
        }
    }  
 #endregion

 #region Pages and Categories
    public void SetFloorsPage() {
            uiImg_HighlightFloors.enabled = true;
        uiImg_HighlightWalls.enabled = false;
        uiImg_HighlightDoodads.enabled = false;
        uiImg_HighlightProps.enabled = false; 
        uiImg_HighlightActors.enabled = false; 
        uiImg_HighlightTriggers.enabled = false; 

 
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        header_Floors.SetActive(true);

        currentPage = 1;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void FloorCategory1() {
        sv_Floors.SetActive(true);

        uiImg_HlFloorCat1.enabled = true;
        uiImg_HlFloorCat2.enabled = false;
        uiImg_HlFloorCat3.enabled = false;
        uiImg_HlFloorCat4.enabled = false;

        assetManagerScript.ShowCategory_Floors(0);

        currentCategory = 11;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory2() {
        sv_Floors.SetActive(true);

        uiImg_HlFloorCat1.enabled = false;
        uiImg_HlFloorCat2.enabled = true;
        uiImg_HlFloorCat3.enabled = false;
        uiImg_HlFloorCat4.enabled = false;

        assetManagerScript.ShowCategory_Floors(1);

        currentCategory = 12;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory3() {
        sv_Floors.SetActive(true);

        uiImg_HlFloorCat1.enabled = false;
        uiImg_HlFloorCat2.enabled = false;
        uiImg_HlFloorCat3.enabled = true;
        uiImg_HlFloorCat4.enabled = false;

        assetManagerScript.ShowCategory_Floors(2);

        currentCategory = 13;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory4() {
        sv_Floors.SetActive(true);

        uiImg_HlFloorCat1.enabled = false;
        uiImg_HlFloorCat2.enabled = false;
        uiImg_HlFloorCat3.enabled = false;
        uiImg_HlFloorCat4.enabled = true;

        assetManagerScript.ShowCategory_Floors(3);

        currentCategory = 14;
        hotkeyStage = 2;
        HotkeyStageColor();
    }


    public void SetWallsPage() {
        uiImg_HighlightFloors.enabled = false;
            uiImg_HighlightWalls.enabled = true;
        uiImg_HighlightDoodads.enabled = false;
        uiImg_HighlightProps.enabled = false; 
        uiImg_HighlightActors.enabled = false; 
        uiImg_HighlightTriggers.enabled = false; 

        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        header_Walls.SetActive(true);

        currentPage = 2;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void WallsCategory1() {
        sv_Walls.SetActive(true);
        uiImg_HlWallsCat1.enabled = true;
        uiImg_HlWallsCat2.enabled = false;
        uiImg_HlWallsCat3.enabled = false;
        uiImg_HlWallsCat4.enabled = false;

        assetManagerScript.ShowCategory_Walls(0);

        currentCategory = 21;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory2() {
        sv_Walls.SetActive(true);
        uiImg_HlWallsCat1.enabled = false;
        uiImg_HlWallsCat2.enabled = true;
        uiImg_HlWallsCat3.enabled = false;
        uiImg_HlWallsCat4.enabled = false;

        assetManagerScript.ShowCategory_Walls(1);

        currentCategory = 22;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory3() {
        sv_Walls.SetActive(true);
        uiImg_HlWallsCat1.enabled = false;
        uiImg_HlWallsCat2.enabled = false;
        uiImg_HlWallsCat3.enabled = true;
        uiImg_HlWallsCat4.enabled = false;

        assetManagerScript.ShowCategory_Walls(2);

        currentCategory = 23;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory4() {
        sv_Walls.SetActive(true);
        uiImg_HlWallsCat1.enabled = false;
        uiImg_HlWallsCat2.enabled = false;
        uiImg_HlWallsCat3.enabled = false;
        uiImg_HlWallsCat4.enabled = true;

        assetManagerScript.ShowCategory_Walls(3);

        currentCategory = 24;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void SetDoodadsPage() {
        uiImg_HighlightFloors.enabled = false;
        uiImg_HighlightWalls.enabled = false;
            uiImg_HighlightDoodads.enabled = true;
        uiImg_HighlightProps.enabled = false; 
        uiImg_HighlightActors.enabled = false; 
        uiImg_HighlightTriggers.enabled = false; 

        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false); 
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        header_Doodads.SetActive(true);

        currentPage = 3;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void DoodadsCategory1() {
        sv_Doodads.SetActive(true);

        uiImg_HlDoodadsCat1.enabled = true;
        uiImg_HlDoodadsCat2.enabled = false;
        uiImg_HlDoodadsCat3.enabled = false;
        uiImg_HlDoodadsCat4.enabled = false;

        assetManagerScript.ShowCategory_Doodads(0);

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory2() {
        sv_Doodads.SetActive(true);

        uiImg_HlDoodadsCat1.enabled = false;
        uiImg_HlDoodadsCat2.enabled = true;
        uiImg_HlDoodadsCat3.enabled = false;
        uiImg_HlDoodadsCat4.enabled = false;

        assetManagerScript.ShowCategory_Doodads(1);

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory3() {
        sv_Doodads.SetActive(true);

        uiImg_HlDoodadsCat1.enabled = false;
        uiImg_HlDoodadsCat2.enabled = false;
        uiImg_HlDoodadsCat3.enabled = true;
        uiImg_HlDoodadsCat4.enabled = false;

        assetManagerScript.ShowCategory_Doodads(2);

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory4() {
        sv_Doodads.SetActive(true);

        uiImg_HlDoodadsCat1.enabled = false;
        uiImg_HlDoodadsCat2.enabled = false;
        uiImg_HlDoodadsCat3.enabled = false;
        uiImg_HlDoodadsCat4.enabled = true;

        assetManagerScript.ShowCategory_Doodads(3);

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void SetPropsPage() {
        uiImg_HighlightFloors.enabled = false;
        uiImg_HighlightWalls.enabled = false;
        uiImg_HighlightDoodads.enabled = false;
            uiImg_HighlightProps.enabled = true; 
        uiImg_HighlightActors.enabled = false; 
        uiImg_HighlightTriggers.enabled = false; 

        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        header_Props.SetActive(true);

        currentPage = 4;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void PropsCategory1() {
        sv_Props.SetActive(true);

        uiImg_HlPropsCat1.enabled = true;
        uiImg_HlPropsCat2.enabled = false;
        uiImg_HlPropsCat3.enabled = false;
        uiImg_HlPropsCat4.enabled = false;

        assetManagerScript.ShowCategory_Props(0);

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory2() {
        sv_Props.SetActive(true);

        uiImg_HlPropsCat1.enabled = false;
        uiImg_HlPropsCat2.enabled = true;
        uiImg_HlPropsCat3.enabled = false;
        uiImg_HlPropsCat4.enabled = false;

        assetManagerScript.ShowCategory_Props(1);

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory3() {
        sv_Props.SetActive(true);

        uiImg_HlPropsCat1.enabled = false;
        uiImg_HlPropsCat2.enabled = false;
        uiImg_HlPropsCat3.enabled = true;
        uiImg_HlPropsCat4.enabled = false;

        assetManagerScript.ShowCategory_Props(2);

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory4() {
        sv_Props.SetActive(true);

        uiImg_HlPropsCat1.enabled = false;
        uiImg_HlPropsCat2.enabled = false;
        uiImg_HlPropsCat3.enabled = false;
        uiImg_HlPropsCat4.enabled = true;

        assetManagerScript.ShowCategory_Props(3);

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void SetActorsPage() {
        uiImg_HighlightFloors.enabled = false;
        uiImg_HighlightWalls.enabled = false;
        uiImg_HighlightDoodads.enabled = false;
        uiImg_HighlightProps.enabled = false; 
            uiImg_HighlightActors.enabled = true; 
        uiImg_HighlightTriggers.enabled = false; 

        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        header_Actors.SetActive(true);

        currentPage = 5;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void ActorsCategory1() {
        sv_Actors.SetActive(true);

        uiImg_HlActorsCat1.enabled = true;
        uiImg_HlActorsCat2.enabled = false;
        uiImg_HlActorsCat3.enabled = false;
        uiImg_HlActorsCat4.enabled = false;

        assetManagerScript.ShowCategory_Actors(0);

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory2() {
        sv_Actors.SetActive(true);

        uiImg_HlActorsCat1.enabled = false;
        uiImg_HlActorsCat2.enabled = true;
        uiImg_HlActorsCat3.enabled = false;
        uiImg_HlActorsCat4.enabled = false;

        assetManagerScript.ShowCategory_Actors(1);

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory3() {
        sv_Actors.SetActive(true);

        uiImg_HlActorsCat1.enabled = false;
        uiImg_HlActorsCat2.enabled = false;
        uiImg_HlActorsCat3.enabled = true;
        uiImg_HlActorsCat4.enabled = false;

        assetManagerScript.ShowCategory_Actors(2);

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory4() {
        sv_Actors.SetActive(true);

        uiImg_HlActorsCat1.enabled = false;
        uiImg_HlActorsCat2.enabled = false;
        uiImg_HlActorsCat3.enabled = false;
        uiImg_HlActorsCat4.enabled = true;

        assetManagerScript.ShowCategory_Actors(3);

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void SetTriggersPage() {
        uiImg_HighlightFloors.enabled = false;
        uiImg_HighlightWalls.enabled = false;
        uiImg_HighlightDoodads.enabled = false;
        uiImg_HighlightProps.enabled = false; 
        uiImg_HighlightActors.enabled = false; 
            uiImg_HighlightTriggers.enabled = true; 
     
        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);

        header_Triggers.SetActive(true);

        currentPage = 6; 
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void TriggersCategory1() {
        sv_Triggers.SetActive(true);

        uiImg_HlTriggersCat1.enabled = true;
        uiImg_HlTriggersCat2.enabled = false;
        uiImg_HlTriggersCat3.enabled = false;
        uiImg_HlTriggersCat4.enabled = false;

        assetManagerScript.ShowCategory_Triggers(0);

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory2() {
        sv_Triggers.SetActive(true);

        uiImg_HlTriggersCat1.enabled = false;
        uiImg_HlTriggersCat2.enabled = true;
        uiImg_HlTriggersCat3.enabled = false;
        uiImg_HlTriggersCat4.enabled = false;

        assetManagerScript.ShowCategory_Triggers(1);

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory3() {
        sv_Triggers.SetActive(true);

        uiImg_HlTriggersCat1.enabled = false;
        uiImg_HlTriggersCat2.enabled = false;
        uiImg_HlTriggersCat3.enabled = true;
        uiImg_HlTriggersCat4.enabled = false;

        assetManagerScript.ShowCategory_Triggers(2);

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory4() {
        sv_Triggers.SetActive(true);

        uiImg_HlTriggersCat1.enabled = false;
        uiImg_HlTriggersCat2.enabled = false;
        uiImg_HlTriggersCat3.enabled = false;
        uiImg_HlTriggersCat4.enabled = true;

        assetManagerScript.ShowCategory_Triggers(3);

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }
 #endregion      



}
