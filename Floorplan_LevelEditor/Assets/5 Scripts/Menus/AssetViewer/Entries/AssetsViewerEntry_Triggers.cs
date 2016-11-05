using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Triggers : MonoBehaviour, IAssetViewerEntry {

    GameObject assetsDbController;
    AssetsViewerAssetManagement assetViewerMgmtScript;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    OptionsInfoDisplay optionsInfoScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    ObjectOptionsController objectOptionsContScript;


    public GameObject assetWorldObject;

    //------------- Asset Datas ------------------
    public Asset_Trigger_Base assetBaseObject;

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
    [SerializeField] GameObject tilesetNumberObject;

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
        optionsInfoScript = assetsDbController.GetComponent<OptionsInfoDisplay>();

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
        nameText.text = assetBaseObject.assetName;
        usageIcon.sprite = assetBaseObject.assetUsageIcon;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite = assetBaseObject.assetEntryIcon;

        if(assetBaseObject.tilesetIndex != 0) {
            tilesetIndexAdjust = assetBaseObject.tilesetIndex - 1;
            tilesetColor.color = assetViewerMgmtScript.assetsList_Tilesets[tilesetIndexAdjust].assetTilesetColor;

            tilesetNumber.text = assetBaseObject.tilesetIndex.ToString();
        }
        else {
            tilesetColor.color = noTilesetColor;
            tilesetNumber.text = "";
        }

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        optionsInfoScript.SetCurrentTileSprite(assetBaseObject.assetEntryIcon);
        optionsInfoScript.SetCurrentTileGO(assetWorldObject);


        optionsInfoScript.geom0_entity1 = true;
        optionsInfoScript.tilePlacerWidget.SetActive(true);

        objectOptionsContScript.ActivateEntitiesOptions();
    }

    public void SelectFromHotkey() {        //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        optionsInfoScript.SetCurrentTileSprite(assetBaseObject.assetEntryIcon);
        optionsInfoScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndices( 6, (int)assetBaseObject.categoryTriggers, assetBaseObject.assetIndex, assetBaseObject.assetTexAtlasIndex); //triggers have their material setup in their Prefab, there is no configurable TexAtlas for them

        optionsInfoScript.geom0_entity1 = true;
        optionsInfoScript.tilePlacerWidget.SetActive(true);

        objectOptionsContScript.ActivateEntitiesOptions();
    }

    public AssetBasis GetAssetBaseObject() {
        return assetBaseObject;
    }

}
