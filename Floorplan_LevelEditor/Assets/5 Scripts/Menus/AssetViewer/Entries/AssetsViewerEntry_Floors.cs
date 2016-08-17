using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Floors : MonoBehaviour {
   
    [SerializeField] GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    TileToPaintMenu tileToPaintScript;


    public GameObject assetWorldObject;

//------------- Asset Datas ------------------              //! @TODO make all these assetViewerEntry BaseClasses Generic 
    public Asset_Floor_Base assetFloor_BaseObject;
   /* public string assetName;

    public Categories_Floors categoryFloors;

    public string assetUsageSet;
    public string assetDesc;
*/
    public int assetIndex;
    string assetIndexString;

 /* public Sprite assetEntryIcon;
    public Color assetTilesetColor;

    public int uvMapSectorFlag;
    public int meshsetFlag;
    public string meshsetString;*/
//----------- UI Refs ---------------------
    [Space(30)]
    [SerializeField] GameObject nameObject;
    [SerializeField] GameObject usageObject;
    [SerializeField] GameObject descObject;

    [SerializeField] GameObject indexHkObject0;
    [SerializeField] GameObject indexHkObject1;

    [SerializeField] GameObject iconObject;
    [SerializeField] GameObject colorObject;

    [SerializeField] GameObject toggleObject;
//---  ---  ---  ---  ---  ---  ---  ---  
    Text nameText;
    Text usageText;
    Text descText;

    Text hkText0;
    Text hkText1;

    Sprite iconSprite;
    Image tilesetColor;

    Toggle selectedToggle;



	void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        textureViewerManageScript = assetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
        textureViewerPreviewerScript = assetsDbController.GetComponent<TexturesViewerTexPreviewer>();
        tileToPaintScript = assetsDbController.GetComponent<TileToPaintMenu>();

        nameText = nameObject.GetComponent<Text>();
        usageText = usageObject.GetComponent<Text>();
        descText = descObject.GetComponent<Text>();

        hkText0 = indexHkObject0.GetComponent<Text>();
        hkText1 = indexHkObject1.GetComponent<Text>();

        iconSprite = iconObject.GetComponent<Sprite>();
        tilesetColor = colorObject.GetComponent<Image>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(0).GetComponent<ToggleGroup>();

//---------------------- assign datas to asset entries ---------------------
        nameText.text = assetFloor_BaseObject.assetName;
        usageText.text = assetFloor_BaseObject.assetUsageSet;
        descText.text = assetFloor_BaseObject.assetDesc;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";   
        }
        iconSprite = assetFloor_BaseObject.assetEntryIcon;
        tilesetColor.color = assetFloor_BaseObject.assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetFloor_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 1;
        textureViewerManageScript.ShowCompatTexAtlases(assetFloor_BaseObject.meshsetString);

        tileToPaintScript.SetCurrentTileSprite(assetFloor_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
    }

    public void SelectFromHotkey() {        //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetFloor_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 1;
        textureViewerManageScript.ShowCompatTexAtlases(assetFloor_BaseObject.meshsetString);

        tileToPaintScript.SetCurrentTileSprite(assetFloor_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
    }

    public void SetSelectedMaterial(Material theMaterial) {
        assetFloor_BaseObject.assetMaterial = theMaterial;
    }

}
