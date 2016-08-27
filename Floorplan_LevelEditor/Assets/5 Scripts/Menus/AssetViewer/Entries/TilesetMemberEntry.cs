using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TilesetMemberEntry : MonoBehaviour {

    GameObject assetsDbController;


    public GameObject theAssetEntry;
    IAssetViewerEntry theEntryScript;       //AssetsViewerEntry_Floors , for example
    AssetBasis theAssetBase;                //Asset_Floor_Base of ^ , for example


    string hotkeyPageString;

    //----------- UI Refs ---------------------
    [Space(30)]
    [SerializeField] GameObject pageObject;
    [SerializeField] GameObject categoryObject;

    [SerializeField] GameObject usageObject;
    [SerializeField] GameObject indexHotkeyObject;

    [SerializeField] GameObject iconObject;
    [SerializeField] GameObject nameObject;

    [SerializeField] GameObject toggleObject;
    //---  ---  ---  ---  ---  ---  ---  ---  
    Text pageText;
    Text categoryText;

    Image usageImage;
    Text hotkeyText;

    Image assetIconImage;
    Text assetName;

    Toggle theToggle;




    void Awake () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");


        pageText = pageObject.GetComponent<Text>();
        categoryText = categoryObject.GetComponent<Text>();

        usageImage = usageObject.GetComponent<Image>();
        hotkeyText = indexHotkeyObject.GetComponent<Text>();

        assetIconImage = iconObject.GetComponent<Image>();
        assetName = nameObject.GetComponent<Text>();
      
        theToggle = toggleObject.GetComponent<Toggle>();
        theToggle.group = assetsDbController.transform.GetChild(2).GetComponent<ToggleGroup>();
    }


    public void AssignDatasToUI() {
        //---------------------- assign datas to asset entries ---------------------

        theEntryScript = theAssetEntry.GetComponent<IAssetViewerEntry>();
        theAssetBase = theEntryScript.GetAssetBaseObject();

        Debug.Log(theAssetBase.pageName);

        pageText.text = theAssetBase.pageName;
        categoryText.text = theAssetBase.categoryName;


        switch (theAssetBase.pageName)
        {
            case "Floors":
                hotkeyPageString = "1";
                break;
            case "Walls":
                hotkeyPageString = "2";
                break;
            case "Doodads":
                hotkeyPageString = "3";
                break;
            case "Props":
                hotkeyPageString = "4";
                break;
            case "Actors":
                hotkeyPageString = "5";
                break;
        }
        hotkeyText.text = hotkeyPageString + ", " + theAssetBase.categoryHotkey + ", " + theAssetBase.assetIndex;


        usageImage.sprite = theAssetBase.assetUsageIcon;
        assetIconImage.sprite = theAssetBase.assetEntryIcon;
        assetName.text = theAssetBase.assetName;
    }


}
