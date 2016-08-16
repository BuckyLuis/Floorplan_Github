using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Walls : MonoBehaviour {

    [SerializeField] GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TileToPaintMenu tileToPaintScript;


    public GameObject assetWorldObject;

    //------------- Asset Datas ------------------
    public string assetName;

    public Categories_Walls categoryWalls;

    public string assetUsageSet;
    public string assetDesc;

    public int assetIndex;
    string assetIndexString;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;

    public int uvMapSectorFlag;
    public int meshsetFlag;
    public string meshsetString;
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
        tileToPaintScript = assetsDbController.GetComponent<TileToPaintMenu>();

        nameText = nameObject.GetComponent<Text>();
        usageText = usageObject.GetComponent<Text>();
        descText = descObject.GetComponent<Text>();

        hkText0 = indexHkObject0.GetComponent<Text>();
        hkText1 = indexHkObject1.GetComponent<Text>();

        iconSprite = iconObject.GetComponent<Sprite>();
        tilesetColor = colorObject.GetComponent<Image>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.GetComponent<ToggleGroup>();

        //---------------------- assign datas to asset entries ---------------------
        nameText.text = assetName;
        usageText.text = assetUsageSet;
        descText.text = assetDesc;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite = assetEntryIcon;
        tilesetColor.color = assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        textureViewerManageScript.ShowCompatTexAtlases(meshsetString);

        tileToPaintScript.SetCurrentTileSprite(assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
    }

    public void SelectFromHotkey() {        //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerManageScript.ShowCompatTexAtlases(meshsetString);

        tileToPaintScript.SetCurrentTileSprite(assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
    }


}
