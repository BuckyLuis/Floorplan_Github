using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


//public enum TexAtlasCategory { GEOMETRY, DOODADS, PROPS, ACTORS }


public class TexturesViewerTexAtlasManagement : MonoBehaviour {

    [Header (">>> >>> --- TextureAtlas Lists --- <<< <<<", order = 0)] 
    [Header ("IMPORTANT!: enter compatMeshsets as numbers separated by a comma , ", order = 1)]
    [Space(15, order = 2)]
    [Header (" --- Geoms --- ", order = 3)] 
    public List<TextureAtlas_Base> texAtlasList_Geoms = new List<TextureAtlas_Base>();
    [Space(15, order = 4)]
    [Header (" --- Doodads --- ", order = 5)] 
    public List<TextureAtlas_Base> texAtlasList_Doodads = new List<TextureAtlas_Base>();
    [Space(15, order = 6)]
    [Header (" --- Props --- ", order = 7)] 
    public List<TextureAtlas_Base> texAtlasList_Props = new List<TextureAtlas_Base>();
    [Space(15, order = 8)]
    [Header (" --- Actors --- ", order = 9)] 
    public List<TextureAtlas_Base> texAtlasList_Actors = new List<TextureAtlas_Base>();
    [Space(40, order = 10)]
    [Header (" ^^^ ^^^ --- --- --- --- --- --- ^^^ ^^^ ", order = 11)]    

    [Space(120, order = 12)]
    [Header (" --- TextureAtlas Dict - DO NOT EDIT! --- ", order = 13)] 
    public Dictionary_sGo texAtlasGeomsDict;
    public Dictionary_sGo texAtlasDoodadsDict;
    public Dictionary_sGo texAtlasPropsDict;
    public Dictionary_sGo texAtlasActorsDict;
    string[] tempStringArray0;

    Dictionary_sGo tempDictToSearch;

    [HideInInspector] public GameObject currentSelAssetEntry;
    [HideInInspector] public int currentSelAssetEntryTypeFlag;
    [HideInInspector] public List<GameObject> currentCompatTexAtlasEntries = new List<GameObject>();

//---------------------- UI Ref -------------------------------------
    [Space(20, order = 14)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 15)] 
    [SerializeField] GameObject viewAreaTexAtlas;
    [SerializeField] GameObject texAtlasEntryPrefab;

    [SerializeField] GameObject ui_tglShowTexViewer;
    Toggle uiTgl_showTexViewer;

    GameObject tempEntry;
    string tempDictString;

    int listIndexCounter;
    int currEntriesIndexCounter;




	void Start () {
        uiTgl_showTexViewer = ui_tglShowTexViewer.GetComponent<Toggle>();

        PopulateTexAtlasView();
	}
	
    void PopulateTexAtlasView() {

        listIndexCounter = 0;
        foreach (var texAtlasGeomBasis in texAtlasList_Geoms) {
            tempEntry = Instantiate(texAtlasEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTexAtlas.transform, false);
            TexturesViewerEntry tempScript = tempEntry.GetComponent<TexturesViewerEntry>();
            tempScript.texAtlasBaseObject = texAtlasGeomBasis;
            tempScript.texAtlasDisplayTexture = texAtlasGeomBasis.texAtlasMatObject.mainTexture;
            tempScript.texAtlasBaseObject.texAtlasIndex = listIndexCounter;
            texAtlasGeomBasis.texAtlasIndex = listIndexCounter;

            texAtlasGeomsDict.Add(string.Format("{0}|{1}",  texAtlasGeomBasis.texAtlasCompatMeshsets, listIndexCounter), tempEntry);
            listIndexCounter++;
        }

        listIndexCounter = 0;
        foreach (var texAtlasDoodadBasis in texAtlasList_Doodads) {
            tempEntry = Instantiate(texAtlasEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTexAtlas.transform, false);
            TexturesViewerEntry tempScript = tempEntry.GetComponent<TexturesViewerEntry>();
            tempScript.texAtlasBaseObject = texAtlasDoodadBasis;
            tempScript.texAtlasDisplayTexture = texAtlasDoodadBasis.texAtlasMatObject.mainTexture;
            tempScript.texAtlasBaseObject.texAtlasIndex = listIndexCounter;
            texAtlasDoodadBasis.texAtlasIndex = listIndexCounter;

            texAtlasGeomsDict.Add(string.Format("{0}|{1}",  texAtlasDoodadBasis.texAtlasCompatMeshsets, listIndexCounter), tempEntry);
            listIndexCounter++;
        }

        listIndexCounter = 0;
        foreach (var texAtlasPropBasis in texAtlasList_Props) {
            tempEntry = Instantiate(texAtlasEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTexAtlas.transform, false);
            TexturesViewerEntry tempScript = tempEntry.GetComponent<TexturesViewerEntry>();
            tempScript.texAtlasBaseObject = texAtlasPropBasis;
            tempScript.texAtlasDisplayTexture = texAtlasPropBasis.texAtlasMatObject.mainTexture;
            tempScript.texAtlasBaseObject.texAtlasIndex = listIndexCounter;
            texAtlasPropBasis.texAtlasIndex = listIndexCounter;

            texAtlasGeomsDict.Add(string.Format("{0}|{1}",  texAtlasPropBasis.texAtlasCompatMeshsets, listIndexCounter), tempEntry);
            listIndexCounter++;
        }

        listIndexCounter = 0;
        foreach (var texAtlasActorBasis in texAtlasList_Actors) {
            tempEntry = Instantiate(texAtlasEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTexAtlas.transform, false);
            TexturesViewerEntry tempScript = tempEntry.GetComponent<TexturesViewerEntry>();
            tempScript.texAtlasBaseObject = texAtlasActorBasis;
            tempScript.texAtlasDisplayTexture = texAtlasActorBasis.texAtlasMatObject.mainTexture;
            tempScript.texAtlasBaseObject.texAtlasIndex = listIndexCounter;
            texAtlasActorBasis.texAtlasIndex = listIndexCounter;

            texAtlasGeomsDict.Add(string.Format("{0}|{1}",  texAtlasActorBasis.texAtlasCompatMeshsets, listIndexCounter), tempEntry);
            listIndexCounter++;
        }
        listIndexCounter = 0;

        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasGeomsDict) {       //hide them all at startup, nothing is selected, so nothing here should be shown
            texAtlasEntry.Value.SetActive(false);
        }
        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasDoodadsDict) {      
            texAtlasEntry.Value.SetActive(false);
        }
        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasPropsDict) {      
            texAtlasEntry.Value.SetActive(false);
        }
        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasActorsDict) {       
            texAtlasEntry.Value.SetActive(false);
        }
    }
       

    public void ShowCompatTexAtlases(string meshsetString) {     //called when an Asset becomes selected.           //meshsetString is formatted like so: "category|meshset"
        string[] tempStringArrayMS = meshsetString.Split('|');  //split the input meshsetString
        string astClassifyFlag = tempStringArrayMS[0];
        string astMeshsetFlag = tempStringArrayMS[1];
       
        switch (astClassifyFlag)
        {
            case "0":
                tempDictToSearch = texAtlasGeomsDict;
                CompareAssetVsTexAtlasCompats(astMeshsetFlag);
                break;
            case "1":
                tempDictToSearch = texAtlasDoodadsDict;
                CompareAssetVsTexAtlasCompats(astMeshsetFlag);
                break;
            case "2":
                tempDictToSearch = texAtlasPropsDict;
                CompareAssetVsTexAtlasCompats(astMeshsetFlag);
                break;
            case "3":
                tempDictToSearch = texAtlasActorsDict;
                CompareAssetVsTexAtlasCompats(astMeshsetFlag);   
                break;
        }
    }

    void CompareAssetVsTexAtlasCompats(string astMeshsetFlag) {
        currentCompatTexAtlasEntries.Clear();

        currEntriesIndexCounter = 1;
        foreach (KeyValuePair<string, GameObject> texAtlasEntry in tempDictToSearch) {
            tempStringArray0 = texAtlasEntry.Key.Split('|');    //split the DictKey string

            if(SplitDictKey_GetCompat(texAtlasEntry, astMeshsetFlag) == true) {
                texAtlasEntry.Value.SetActive(true);
                texAtlasEntry.Value.GetComponent<TexturesViewerEntry>().SetHkIndex(currEntriesIndexCounter);
                currEntriesIndexCounter++;
                currentCompatTexAtlasEntries.Add(texAtlasEntry.Value);
            }
            else {
                texAtlasEntry.Value.SetActive(false);
            }
        }

        uiTgl_showTexViewer.isOn = true;
    }

    bool SplitDictKey_GetCompat(KeyValuePair<string, GameObject> entryToSplit, string astMeshsetFlag) {
        
        string theCompatFlags = tempStringArray0[0];
        tempStringArray0 = theCompatFlags.Split(',');

        foreach(var compatFlag in tempStringArray0) {
            if(compatFlag == astMeshsetFlag) {
                return true;
            }
        }
        return false;
    }

    void ClearTextureViewer() {
        currentCompatTexAtlasEntries.Clear();
    }


    public void SelectDefaultTexAtlasEntry() {
        switch (currentSelAssetEntryTypeFlag)
        {
            case 1:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Floors>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject,
                        currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasIndex);
                break;
            case 2:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Walls>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject,
                        currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasIndex);
                break;
            case 3:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Doodads>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject,
                        currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasIndex);
                break;
            case 4:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Props>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject,
                        currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasIndex);
                break;
            case 5:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Actors>().SetSelectedMaterial
                        (currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasMatObject,
                        currentCompatTexAtlasEntries[0].GetComponent<TexturesViewerEntry>().texAtlasBaseObject.texAtlasIndex);
                break;
        }
    }

    public void SelectAndApplyTexAtlasEntry(Material theMaterial, int texAtlasIndex) {
        switch (currentSelAssetEntryTypeFlag)
        {
            case 1:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Floors>().SetSelectedMaterial(theMaterial, texAtlasIndex);
                break;
            case 2:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Walls>().SetSelectedMaterial(theMaterial, texAtlasIndex);
                break;
            case 3:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Doodads>().SetSelectedMaterial(theMaterial, texAtlasIndex);     
                break;
            case 4:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Props>().SetSelectedMaterial(theMaterial, texAtlasIndex);
                break;
            case 5:
                currentSelAssetEntry.GetComponent<AssetsViewerEntry_Actors>().SetSelectedMaterial(theMaterial, texAtlasIndex);
                break;
        }
    }

}
