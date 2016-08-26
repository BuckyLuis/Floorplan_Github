using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Triggers : MonoBehaviour {

    GameObject assetsDbController;
    AssetsViewerAssetManagement assetViewerMgmtScript;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TileOptions tileToPaintScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    ObjectOptionsController objectOptionsContScript;


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

    [SerializeField] GameObject indexHkObject0;
    [SerializeField] GameObject indexHkObject1;

    [SerializeField] GameObject iconObject;
    [SerializeField] GameObject colorObject;

    [SerializeField] GameObject toggleObject;
    //---  ---  ---  ---  ---  ---  ---  ---  
    Text nameText;
    Image usageIcon;

    Text hkText0;
    Text hkText1;

    Sprite iconSprite;
    Image tilesetColor;
    Text tilesetNumber;
    int tilesetIndexAdjust;
    Color32 noTilesetColor = new Color32(0, 0, 0, 0);

    Toggle selectedToggle;



    void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        assetViewerMgmtScript = assetsDbController.GetComponent<AssetsViewerAssetManagement>();
        textureViewerManageScript = assetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
        tileToPaintScript = assetsDbController.GetComponent<TileOptions>();

        toolsController = GameObject.FindWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();
        objectOptionsContScript = toolsController.GetComponent<ObjectOptionsController>();


        nameText = nameObject.GetComponent<Text>();
        usageIcon = usageObject.GetComponent<Image>();

        hkText0 = indexHkObject0.GetComponent<Text>();
        hkText1 = indexHkObject1.GetComponent<Text>();

        iconSprite = iconObject.GetComponent<Sprite>();
        tilesetColor = colorObject.GetComponent<Image>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(0).GetComponent<ToggleGroup>();

        //---------------------- assign datas to asset entries ---------------------
        nameText.text = assetTrigger_BaseObject.assetName;
        usageIcon.sprite = assetTrigger_BaseObject.assetUsageIcon;

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

        if(assetTrigger_BaseObject.tilesetIndex != 0) {
            tilesetIndexAdjust = assetTrigger_BaseObject.tilesetIndex - 1;
            tilesetColor.color = assetViewerMgmtScript.assetsList_Tilesets[tilesetIndexAdjust].assetTilesetColor;

            tilesetNumber.text = assetTrigger_BaseObject.tilesetIndex.ToString();
        }
        else {
            tilesetColor.color = noTilesetColor;
            tilesetNumber.text = "";
        }

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        objectOptionsContScript.ActivateEntitiesOptions();

        tileToPaintScript.SetCurrentTileSprite(assetTrigger_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);

        objectOptionsContScript.ActivateEntitiesOptions();
    }

    public void SelectFromHotkey() {        //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        tileToPaintScript.SetCurrentTileSprite(assetTrigger_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetTrigger_BaseObject.categoryTriggers, assetTrigger_BaseObject.assetIndex, assetTrigger_BaseObject.assetMaterialName);

        objectOptionsContScript.ActivateEntitiesOptions();
    }

}
