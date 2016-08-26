using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TilesetMemberEntry : MonoBehaviour {

    GameObject assetsDbController;

    AssetBasis_Tile theAssetBaseObject;

    public int assetIndex;
    string assetIndexString;

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




    void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");


        pageText = pageObject.GetComponent<Text>();
        categoryText = categoryObject.GetComponent<Text>();

        usageImage = usageObject.GetComponent<Image>();
        hotkeyText = indexHotkeyObject.GetComponent<Text>();

        assetIconImage = iconObject.GetComponent<Image>();
        assetName = nameObject.GetComponent<Text>();
      
        theToggle = toggleObject.GetComponent<Toggle>();
        theToggle.group = assetsDbController.transform.GetChild(2).GetComponent<ToggleGroup>();

        //---------------------- assign datas to asset entries ---------------------
    }
}
