using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerMenu : MonoBehaviour {


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

    public bool allowHkAutoFullReset;
    bool isAutoFullResetTimerOn = false;
    public float hkAutoFullResetDuration = 7f;
    float hkAutoFullResetTimer;

    int currentPage;
    int currentCategory;

//------------  UI Element Refs -----------------
    [SerializeField] GameObject tgl_Floors;
    [SerializeField] GameObject tgl_Walls;
    [SerializeField] GameObject tgl_Doodads;
    [SerializeField] GameObject tgl_Props;
    [SerializeField] GameObject tgl_Actors;
    [SerializeField] GameObject tgl_Triggers;

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

    [SerializeField] GameObject view_Floors;
    [SerializeField] GameObject view_Walls;
    [SerializeField] GameObject view_Doodads;
    [SerializeField] GameObject view_Props;
    [SerializeField] GameObject view_Actors;
    [SerializeField] GameObject view_Triggers;
//--------------------------------------------------
    [SerializeField] GameObject ui_txtLastHotkeyEntered;
    [SerializeField] GameObject ui_imgHotkeyStage;
    Text uiTxt_lastHotkeyEntered;
    Image uiImg_hotkeyStage;





	void Start () {
        uiImg_hotkeyStage = ui_imgHotkeyStage.GetComponent<Image>();
        uiTxt_lastHotkeyEntered = ui_txtLastHotkeyEntered.GetComponent<Text>();
        HotkeyStageColor();
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

        if(isAutoFullResetTimerOn == true && allowHkAutoFullReset == true) {
            hkStageResetTimer -= Time.deltaTime;

            if(hkAutoFullResetTimer <= 0) {
                hotkeyStage = 0;
                HotkeyStageColor();
                isAutoFullResetTimerOn = false;
            }
        }
  
//--------------------  Manual Set hkStage --------------
        if(Input.GetKeyDown(KeyCode.F1)) {
            hotkeyStage = 0;
            uiTxt_lastHotkeyEntered.text = "|<";
            HotkeyStageColor();
        }
        if(Input.GetKeyDown(KeyCode.F2)) {
            if(hotkeyStage > 0) {
                hotkeyStage--;
                uiTxt_lastHotkeyEntered.text = "<";
                HotkeyStageColor();
            }
        }
        if(Input.GetKeyDown(KeyCode.F3)) {
            if(hotkeyStage < 2) {
                hotkeyStage++;
                uiTxt_lastHotkeyEntered.text = ">";
                HotkeyStageColor();
            }
        }
        if(Input.GetKeyDown(KeyCode.F4)) {
            hotkeyStage = 2;
            uiTxt_lastHotkeyEntered.text = ">|";
            HotkeyStageColor();
        }

//-----------------  Hotkey Inputs -----------------
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}1",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "1";
            }
            keyPressed = 1;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}2",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "2";
            }
            keyPressed = 2;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}3",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "3";
            }
            keyPressed = 3;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}4",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "4";
            }
            keyPressed = 4;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}5",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "5";
            }
            keyPressed = 5;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}6",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "6";
            }
            keyPressed = 6;   
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}7",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "7";
            }
            keyPressed = 7;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}8",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "8";
            }
            keyPressed = 8;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}9",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "9";
            }
            keyPressed = 9;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
            if(hotkeyStage == 3) {
                uiTxt_lastHotkeyEntered.text = string.Format("{0}0",keyPressed);
            }
            else {
                uiTxt_lastHotkeyEntered.text = "0";
            }
            keyPressed = 0;
            isAutoFullResetTimerOn = true;
            hkAutoFullResetTimer = hkAutoFullResetDuration;
            HotkeyWasPressed();
        }
	}

 #region HotkeyWasPressed
    void HotkeyWasPressed() {
        switch (hotkeyStage) {
            case 0:         //---------------- Pages -----------------  
                switch (keyPressed) {
                    case 1: 
                        ToggleFloorsPage();
                        break;  
                    case 2: 
                        ToggleWallsPage();
                        break;  
                    case 3: 
                        ToggleDoodadsPage();
                        break;  
                    case 4: 
                        TogglePropsPage();
                        break;  
                    case 5: 
                        ToggleActorsPage();
                        break;  
                    case 6: 
                        ToggleTriggersPage();
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
        HotkeyStageColor();
    }

    void HotkeyPressedAssetsSecondDigit() {
        hotkeyStage = 2;
        HotkeyStageColor();
    }
 #endregion


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




    public void ToggleFloorsPage() {
        sv_Floors.SetActive(true);
        header_Floors.SetActive(true);
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

        currentPage = 1;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void FloorCategory1() {

        currentCategory = 11;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory2() {

        currentCategory = 12;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory3() {

        currentCategory = 13;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void FloorCategory4() {

        currentCategory = 14;
        hotkeyStage = 2;
        HotkeyStageColor();
    }


    public void ToggleWallsPage() {
        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(true);
        header_Walls.SetActive(true);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        currentPage = 2;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void WallsCategory1() {

        currentCategory = 21;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory2() {

        currentCategory = 22;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory3() {

        currentCategory = 23;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void WallsCategory4() {

        currentCategory = 24;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ToggleDoodadsPage() {
        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(true);
        header_Doodads.SetActive(true);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        currentPage = 3;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void DoodadsCategory1() {

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory2() {

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory3() {

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void DoodadsCategory4() {

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TogglePropsPage() {
        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(true);
        header_Props.SetActive(true);
        sv_Actors.SetActive(false);
        header_Actors.SetActive(false);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        currentPage = 4;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void PropsCategory1() {

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory2() {

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory3() {

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void PropsCategory4() {

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ToggleActorsPage() {
        sv_Floors.SetActive(false);
        header_Floors.SetActive(false);
        sv_Walls.SetActive(false);
        header_Walls.SetActive(false);
        sv_Doodads.SetActive(false);
        header_Doodads.SetActive(false);
        sv_Props.SetActive(false);
        header_Props.SetActive(false);
        sv_Actors.SetActive(true);
        header_Actors.SetActive(true);
        sv_Triggers.SetActive(false);
        header_Triggers.SetActive(false);

        currentPage = 5;
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void ActorsCategory1() {

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory2() {

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory3() {

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ActorsCategory4() {

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void ToggleTriggersPage() {
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
        sv_Triggers.SetActive(true);
        header_Triggers.SetActive(true);

        currentPage = 6; 
        hotkeyStage = 1;
        HotkeyStageColor();
    }

    public void TriggersCategory1() {

        currentCategory = 31;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory2() {

        currentCategory = 32;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory3() {

        currentCategory = 33;
        hotkeyStage = 2;
        HotkeyStageColor();
    }

    public void TriggersCategory4() {

        currentCategory = 34;
        hotkeyStage = 2;
        HotkeyStageColor();
    }



}
