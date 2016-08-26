using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Floors : MonoBehaviour {
   
    GameObject assetsDbController;
    AssetsViewerAssetManagement assetViewerMgmtScript;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    TileOptions tileToPaintScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    ObjectOptionsController objectOptionsContScript;


    public GameObject assetWorldObject;

//------------- Asset Datas ------------------              //! @TODO make all these assetViewerEntry BaseClasses Generic 
    public Asset_Floor_Base assetFloor_BaseObject;

    public int assetIndex;
    string assetIndexString;

//----------- UI Refs ------------------------
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
        textureViewerPreviewerScript = assetsDbController.GetComponent<TexturesViewerTexPreviewer>();
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
        tilesetNumber = tilesetNumberObject.GetComponent<Text>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(0).GetComponent<ToggleGroup>();

//---------------------- assign datas to asset entries ---------------------
        nameText.text = assetFloor_BaseObject.assetName;
        usageIcon.sprite = assetFloor_BaseObject.assetUsageIcon;

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

        if(assetFloor_BaseObject.tilesetIndex != 0) {
            tilesetIndexAdjust = assetFloor_BaseObject.tilesetIndex - 1;
            tilesetColor.color = assetViewerMgmtScript.assetsList_Tilesets[tilesetIndexAdjust].assetTilesetColor;

            tilesetNumber.text = assetFloor_BaseObject.tilesetIndex.ToString();
        }
        else {
            tilesetColor.color = noTilesetColor;
            tilesetNumber.text = "";
        }

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetFloor_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 1;
        textureViewerManageScript.ShowCompatTexAtlases(assetFloor_BaseObject.texturesetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();   //calls SetSelectedMaterial()

        objectOptionsContScript.ActivateTileOptions();
    }

    public void SelectFromHotkey() {                                //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetFloor_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 1;
        textureViewerManageScript.ShowCompatTexAtlases(assetFloor_BaseObject.texturesetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();     //calls SetSelectedMaterial()

        objectOptionsContScript.ActivateTileOptions();
    }

    public void SetSelectedMaterial(Material theMaterial) {         //called by TexAtlasManager, when this assetEntry is selected(assigning default texAtlas) ... OR by way of a TexAtlasEntry having been selected 
        assetFloor_BaseObject.assetMaterial = theMaterial;
        assetFloor_BaseObject.worldObjectPrefab.GetComponent<Renderer>().material = theMaterial;
        textureViewerPreviewerScript.DrawTexturePreview(theMaterial);

        SendInfoTo_TileToPaint();
    }

    void SendInfoTo_TileToPaint() {
        tileToPaintScript.SetCurrentTileSprite(assetFloor_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetFloor_BaseObject.categoryFloors, assetFloor_BaseObject.assetIndex, assetFloor_BaseObject.assetMaterialName);
    }

}
