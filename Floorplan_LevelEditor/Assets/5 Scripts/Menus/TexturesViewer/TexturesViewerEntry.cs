using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TexturesViewerEntry : MonoBehaviour {

    [SerializeField] GameObject assetsDbController;
    TexturesViewerTexAtlasManagement textureViewerManageScript;
    TexturesViewerTexPreviewer textureViewerPreviewerScript;


    public Material texAtlasMatObject;

//----------- texAtlas Datas -------------------------
   /* public string texAtlasName;
    public TexAtlasCategory texAtlasCategory;
    public List<int> texAtlasCompatMeshsets = new List<int>();

    public Color texAtlasTilesetColor;*/

    public TextureAtlas_Base texAtlasBaseObject;
    public Texture texAtlasDisplayTexture;


    public int hkIndex {get; protected set;}
    string hkIndexString;

//------------ UI Refs ----------------------------------
    [Space(30)]
    [SerializeField] GameObject nameObject;

    [SerializeField] GameObject indexHkObject2;
    [SerializeField] GameObject indexHkObject3;

    [SerializeField] GameObject colorObject;

    [SerializeField] GameObject texDisplayObject;
    [SerializeField] GameObject toggleObject;

    Text nameText;
    Text hkText2;
    Text hkText3;

    Image tilesetColor;
    RawImage texDisplayRawImg;

    Toggle selectedToggle;




    void Start () {
        assetsDbController = GameObject.FindWithTag("AssetsDBController");
        textureViewerManageScript = assetsDbController.GetComponent<TexturesViewerTexAtlasManagement>();
        textureViewerPreviewerScript = assetsDbController.GetComponent<TexturesViewerTexPreviewer>();

        nameText = nameObject.GetComponent<Text>();
      //  hkText2 = indexHkObject2.GetComponent<Text>();
      //  hkText3 = indexHkObject3.GetComponent<Text>();    

        tilesetColor = colorObject.GetComponent<Image>();
        texDisplayRawImg = texDisplayObject.GetComponent<RawImage>();

        selectedToggle = toggleObject.GetComponent<Toggle>();
        selectedToggle.group = assetsDbController.transform.GetChild(1).GetComponent<ToggleGroup>();

        //--------------------- assign data to entry --------------------------------
        nameText.text = texAtlasBaseObject.texAtlasName;

        tilesetColor.color = texAtlasBaseObject.texAtlasTilesetColor;
        texDisplayRawImg.texture = texAtlasDisplayTexture;


        //------- Assign Toggle Listener ----------
        selectedToggle.onValueChanged.AddListener(delegate {ThisSelected(selectedToggle.isOn); });
    }


    public void SetHkIndex(int inHkIndex) {
        hkIndex = inHkIndex;
        hkIndexString = hkIndex.ToString();

        hkText2 = indexHkObject2.GetComponent<Text>();
        hkText3 = indexHkObject3.GetComponent<Text>();    

        if(hkIndexString.Length > 1) {
            hkText2.text = hkIndexString[1].ToString();       // in the string "42"  4 is index 0 ... hkText0 is "2" 
            hkText3.text = hkIndexString[0].ToString();
        }
        else {
            hkText2.text = hkIndexString;   
            hkText3.text = "";   
        }
    }


    public void ThisSelected(bool toggleStatus) {           //called by UItoggle
        textureViewerManageScript.SelectAndApplyTexAtlasEntry(texAtlasBaseObject.texAtlasMatObject);
    }

    public void SelectFromHotkey() {
        selectedToggle.group.SetAllTogglesOff();
        selectedToggle.isOn = true;

        textureViewerManageScript.SelectAndApplyTexAtlasEntry(texAtlasBaseObject.texAtlasMatObject);
    }
        

}
