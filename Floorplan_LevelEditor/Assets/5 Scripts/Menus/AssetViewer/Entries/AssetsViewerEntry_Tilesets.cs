using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class AssetsViewerEntry_Tilesets : MonoBehaviour {

    GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    TilesetOptionsAndManager tilesetOptionsScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;
    ObjectOptionsController objectOptionsContScript;
   

    //------------- Asset Datas ------------------

    public Asset_Tileset_Base assetTileset_BaseObject;

    public int assetIndex;
    string assetIndexString;

    //----------- UI Refs ---------------------
    [Space(30)]
    [SerializeField] GameObject nameObject;
    [SerializeField] GameObject usageObject;

    [SerializeField] GameObject indexHkObject0;
    [SerializeField] GameObject indexHkObject1;

    [SerializeField] GameObject iconObject_wall;
    [SerializeField] GameObject iconObject_corner;
    [SerializeField] GameObject iconObject_cornerInv;
    [SerializeField] GameObject iconObject_floor;

    [SerializeField] GameObject colorObject;

    [SerializeField] GameObject toggleObject;
    //---  ---  ---  ---  ---  ---  ---  ---  
    Text nameText;
    Image usageIcon;

    Text hkText0;
    Text hkText1;

    Sprite iconSprite_wall;
    Sprite iconSprite_corner;
    Sprite iconSprite_cornerInv;
    Sprite iconSprite_floor;

    Image tilesetColor;

    Toggle selectedToggle;



    void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        textureViewerManageScript = assetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
        textureViewerPreviewerScript = assetsDbController.GetComponent<TexturesViewerTexPreviewer>();
        tilesetOptionsScript = assetsDbController.GetComponent<TilesetOptionsAndManager>();

        toolsController = GameObject.FindWithTag("ToolsController");
        objInstantiatorScript = toolsController.GetComponent<WorldObjectInstantiator>();
        objectOptionsContScript = toolsController.GetComponent<ObjectOptionsController>();

        nameText = nameObject.GetComponent<Text>();
        usageIcon = usageObject.GetComponent<Image>();

        hkText0 = indexHkObject0.GetComponent<Text>();
        hkText1 = indexHkObject1.GetComponent<Text>();

        iconSprite_wall = iconObject_wall.GetComponent<Sprite>();
        iconSprite_corner = iconObject_corner.GetComponent<Sprite>();
        iconSprite_cornerInv = iconObject_cornerInv.GetComponent<Sprite>();
        iconSprite_floor = iconObject_floor.GetComponent<Sprite>();

        tilesetColor = colorObject.GetComponent<Image>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(0).GetComponent<ToggleGroup>();

        //---------------------- assign datas to asset entries ---------------------
        nameText.text = assetTileset_BaseObject.assetName;
        usageIcon.sprite = assetTileset_BaseObject.assetUsageIcon;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite_wall = assetTileset_BaseObject.assetEntryIcon_wall;
        iconSprite_corner = assetTileset_BaseObject.assetEntryIcon_corner;
        iconSprite_cornerInv = assetTileset_BaseObject.assetEntryIcon_cornerInv;

        tilesetColor.color = assetTileset_BaseObject.assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
        //-------------------------------------------------------------------------------------------
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        objectOptionsContScript.ActivateTilesetsOptions();
        tilesetOptionsScript.ActivateChosenTsMembers(assetTileset_BaseObject.tilesetIndex);

     /*   textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetTileset_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 2;
        textureViewerManageScript.ShowCompatTexAtlases(assetTileset_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();   //calls SetSelectedMaterial()*/
    }

    public void SelectFromHotkey() {                                //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()


        objectOptionsContScript.ActivateTilesetsOptions();
        tilesetOptionsScript.ActivateChosenTsMembers(assetTileset_BaseObject.tilesetIndex);
       /* selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetTileset_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 2;
        textureViewerManageScript.ShowCompatTexAtlases(assetTileset_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();     //calls SetSelectedMaterial()*/
    }

    public void SetSelectedMaterial(Material theMaterial) {


       /* assetTileset_BaseObject.assetMaterial = theMaterial;
//        assetTileset_BaseObject.worldObjectPrefab.GetComponent<Renderer>().material = theMaterial;
        textureViewerPreviewerScript.DrawTexturePreview(theMaterial);

        SendInfoTo_TileToPaint();*/
    }

    void SendInfoTo_TileToPaint() {



     /* //  tileToPaintScript.SetCurrentTileSprite(assetTileset_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetTileset_BaseObject.categoryTilesets, assetTileset_BaseObject.assetIndex, assetTileset_BaseObject.assetMaterialName);*/
    }


}


