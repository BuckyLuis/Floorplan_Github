using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Props : MonoBehaviour {

    GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    TileToPaintMenu tileToPaintScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;


    public GameObject assetWorldObject;

    //------------- Asset Datas ------------------
    public Asset_Prop_Base assetProp_BaseObject;

    public int assetIndex;
    string assetIndexString;

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

    Toggle selectedToggle;



    void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        textureViewerManageScript = assetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
        textureViewerPreviewerScript = assetsDbController.GetComponent<TexturesViewerTexPreviewer>();
        tileToPaintScript = assetsDbController.GetComponent<TileToPaintMenu>();

        toolsController = GameObject.FindWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();


        nameText = nameObject.GetComponent<Text>();
        usageIcon = usageObject.GetComponent<Image>();

        hkText0 = indexHkObject0.GetComponent<Text>();
        hkText1 = indexHkObject1.GetComponent<Text>();

        iconSprite = iconObject.GetComponent<Sprite>();
        tilesetColor = colorObject.GetComponent<Image>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(0).GetComponent<ToggleGroup>();

        //---------------------- assign datas to asset entries ---------------------
        nameText.text = assetProp_BaseObject.assetName;
        usageIcon.sprite = assetProp_BaseObject.assetUsageIcon;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite = assetProp_BaseObject.assetEntryIcon;
        tilesetColor.color = assetProp_BaseObject.assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetProp_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 4;
        textureViewerManageScript.ShowCompatTexAtlases(assetProp_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();   //calls SetSelectedMaterial()
    }

    public void SelectFromHotkey() {                                //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetProp_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 4;
        textureViewerManageScript.ShowCompatTexAtlases(assetProp_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();     //calls SetSelectedMaterial()
    }

    public void SetSelectedMaterial(Material theMaterial) {
        assetProp_BaseObject.assetMaterial = theMaterial;
        assetProp_BaseObject.worldObjectPrefab.GetComponent<Renderer>().material = theMaterial;
        textureViewerPreviewerScript.DrawTexturePreview(theMaterial);

        SendInfoTo_TileToPaint();
    }

    void SendInfoTo_TileToPaint() {
        tileToPaintScript.SetCurrentTileSprite(assetProp_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetProp_BaseObject.categoryProps, assetProp_BaseObject.assetIndex, assetProp_BaseObject.assetMaterialName);
    }

}
