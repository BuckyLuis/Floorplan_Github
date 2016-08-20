using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Triggers : MonoBehaviour {

    GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TileToPaintMenu tileToPaintScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;


    public GameObject assetWorldObject;

    //------------- Asset Datas ------------------
    public Asset_Trigger_Base assetTrigger_BaseObject;

    public int assetIndex;
    string assetIndexString;

    //triggers have no ingame textures

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

        toolsController = GameObject.FindWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();


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
        nameText.text = assetTrigger_BaseObject.assetName;
        usageText.text = assetTrigger_BaseObject.assetUsageSet;
        descText.text = assetTrigger_BaseObject.assetDesc;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite = assetTrigger_BaseObject.assetEntryIcon;
        tilesetColor.color = assetTrigger_BaseObject.assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        tileToPaintScript.SetCurrentTileSprite(assetTrigger_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
    }

    public void SelectFromHotkey() {        //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        tileToPaintScript.SetCurrentTileSprite(assetTrigger_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetTrigger_BaseObject.categoryTriggers, assetTrigger_BaseObject.assetIndex, assetTrigger_BaseObject.assetMaterialName);
    }

}
