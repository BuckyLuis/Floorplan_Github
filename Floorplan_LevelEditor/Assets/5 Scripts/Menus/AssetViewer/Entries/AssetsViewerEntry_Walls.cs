using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetsViewerEntry_Walls : MonoBehaviour {

    GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;
    TileToPaintMenu tileToPaintScript;

    GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;


    public GameObject assetWorldObject;

    //------------- Asset Datas ------------------
    public Asset_Wall_Base assetWall_BaseObject;

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
        nameText.text = assetWall_BaseObject.assetName;
        usageIcon.sprite = assetWall_BaseObject.assetUsageIcon;

        assetIndexString = assetIndex.ToString();
        if(assetIndexString.Length > 1) {
            hkText0.text = assetIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText1.text = assetIndexString[0].ToString();
        }
        else {
            hkText0.text = assetIndexString;   
            hkText1.text = "";
        }
        iconSprite = assetWall_BaseObject.assetEntryIcon;
        tilesetColor.color = assetWall_BaseObject.assetTilesetColor;

        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void ThisSelected(bool toggleStatus) {                   //called by UItoggle
        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetWall_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 2;
        textureViewerManageScript.ShowCompatTexAtlases(assetWall_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();   //calls SetSelectedMaterial()
    }

    public void SelectFromHotkey() {                                //called by hotkey -- AssetsViewerAssetManagement.EntryFromHotkey() -- which is called by AssetsViewerHotkeysUiControl.HotkeyPressedAssetsFirstDigit()
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerPreviewerScript.ReceiveAssetUvMapFlag(assetWall_BaseObject.uvMapSectorFlag);
        textureViewerManageScript.currentSelAssetEntry = this.gameObject;
        textureViewerManageScript.currentSelAssetEntryTypeFlag = 2;
        textureViewerManageScript.ShowCompatTexAtlases(assetWall_BaseObject.meshsetString);

        textureViewerManageScript.SelectDefaultTexAtlasEntry();     //calls SetSelectedMaterial()
    }

    public void SetSelectedMaterial(Material theMaterial) {
        assetWall_BaseObject.assetMaterial = theMaterial;
        assetWall_BaseObject.worldObjectPrefab.GetComponent<Renderer>().material = theMaterial;
        textureViewerPreviewerScript.DrawTexturePreview(theMaterial);

        SendInfoTo_TileToPaint();
    }

    void SendInfoTo_TileToPaint() {
        tileToPaintScript.SetCurrentTileSprite(assetWall_BaseObject.assetEntryIcon);
        tileToPaintScript.SetCurrentTileGO(assetWorldObject);
        objInstantiatorScript.AssignIndicesAndMatName((int)assetWall_BaseObject.categoryWalls, assetWall_BaseObject.assetIndex, assetWall_BaseObject.assetMaterialName);
    }


}
