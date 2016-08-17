using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public enum TexAtlasCategory { GEOMETRY, DOODADS, PROPS, ACTORS }


public class TexturesViewerTexAtlasManagement : MonoBehaviour {

    [Header (">>> >>> --- TextureAtlas Lists --- <<< <<<", order = 0)]     
    public List<TextureAtlas_Base> texAtlasList = new List<TextureAtlas_Base>();
    [Space(40, order = 1)]
    [Header (" ^^^ ^^^ --- --- --- --- --- --- ^^^ ^^^ ", order = 2)]    

    [Space(120, order = 3)]
    [Header (" --- TextureAtlas Dict - DO NOT EDIT! --- ", order = 4)] 
    public Dictionary_sGo texAtlasEntriesDict;
    string[] tempStringArray0;

    [HideInInspector] public GameObject currentSelAssetEntry;
    [HideInInspector] public int currentSelAssetEntryTypeFlag;
    [HideInInspector] public List<GameObject> currentCompatTexAtlasEntries = new List<GameObject>();

//---------------------- UI Ref -------------------------------------
    [Space(20, order = 5)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 6)] 
    [SerializeField] GameObject viewAreaTexAtlas;
    [SerializeField] GameObject texAtlasEntryPrefab;

    [SerializeField] GameObject ui_tglShowTexViewer;
    Toggle uiTgl_showTexViewer;


    GameObject tempEntry;
    string tempDictString;

    int entriesHkIndexCounter;



	void Start () {
        uiTgl_showTexViewer = ui_tglShowTexViewer.GetComponent<Toggle>();

        PopulateTexAtlasView();
	}
	
    void PopulateTexAtlasView() {

        foreach (var texAtlasBasis in texAtlasList) {
            tempEntry = Instantiate(texAtlasEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTexAtlas.transform, false);
            TexturesViewerEntry tempScript = tempEntry.GetComponent<TexturesViewerEntry>();
            tempScript.texAtlasBaseObject = texAtlasBasis;
            tempScript.texAtlasDisplayTexture = texAtlasBasis.texAtlasMatObject.mainTexture;

            tempDictString = "";
            foreach (var compatMeshsetID in texAtlasBasis.texAtlasCompatMeshsets) {
                tempDictString += compatMeshsetID.ToString() + ",";
            }
            texAtlasEntriesDict.Add(string.Format("{0}|{1}", (int)texAtlasBasis.texAtlasCategory, tempDictString), tempEntry);
        }
    }



    public void ShowCompatTexAtlases(string meshsetString) {     //called when an Asset becomes selected.           //meshsetString is formatted like so: "category|meshset"
        string[] tempStringArrayMS = meshsetString.Split('|');  //split the input meshsetString
        string inMeshsetFlag = tempStringArrayMS[1];
        string inCategoryFlag = tempStringArrayMS[0];

        currentCompatTexAtlasEntries.Clear();
        entriesHkIndexCounter = 1;
        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasEntriesDict) {
            tempStringArray0 = texAtlasEntry.Key.Split('|');    //split the DictKey string
            string theCategoryFlag = tempStringArray0[0];

            if(theCategoryFlag == inCategoryFlag) {
                if(SplitDictKey_GetCompat(texAtlasEntry, inMeshsetFlag) == true) {
                    texAtlasEntry.Value.SetActive(true);
                    texAtlasEntry.Value.GetComponent<TexturesViewerEntry>().SetHkIndex(entriesHkIndexCounter);
                    entriesHkIndexCounter++;
                    currentCompatTexAtlasEntries.Add(texAtlasEntry.Value);
                }
                else {
                    texAtlasEntry.Value.SetActive(false);
                }
            }
        }
        SelectDefaultTexAtlasEntry();
        uiTgl_showTexViewer.isOn = true;
    }

    bool SplitDictKey_GetCompat(KeyValuePair<string, GameObject> entryToSplit, string meshsetFlag) {
        
        string theCompatFlags = tempStringArray0[1];
        tempStringArray0 = theCompatFlags.Split(',');

        foreach(var compatFlag in tempStringArray0) {
            if(compatFlag == meshsetFlag) {
                return true;
            }
        }
        return false;
    }


    public void SelectDefaultTexAtlasEntry() {
        switch (currentSelAssetEntryTypeFlag)
        {
            case 1:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Floors>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject);
                break;
            case 2:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Walls>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject);
                break;
            case 3:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Doodads>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject);
                break;
            case 4:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Props>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject);
                break;
            case 5:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Actors>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject);
                break;
        }

    }

}
