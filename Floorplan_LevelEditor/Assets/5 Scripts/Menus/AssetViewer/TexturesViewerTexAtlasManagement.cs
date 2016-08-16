using UnityEngine;
using System.Collections.Generic;
using System;


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

//---------------------- UI Ref -------------------------------------
    [Space(20, order = 5)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 6)] 
    [SerializeField] GameObject viewAreaTexAtlas;
    [SerializeField] GameObject texAtlasEntryPrefab;

    GameObject tempEntry;
    string tempDictString;


	void Start () {
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



    public void ShowCompatTexAtlases(string meshsetString) {                //meshsetString is formatted like so: "category|meshset"
        string[] tempStringArrayMS = meshsetString.Split('|');  //split the input meshsetString
        string inMeshsetFlag = tempStringArrayMS[1];
        string inCategoryFlag = tempStringArrayMS[0];

        foreach (KeyValuePair<string, GameObject> texAtlasEntry in texAtlasEntriesDict) {
            tempStringArray0 = texAtlasEntry.Key.Split('|');    //split the DictKey string
            string theCategoryFlag = tempStringArray0[0];

            if(theCategoryFlag == inCategoryFlag) {
                if(SplitDictKey_GetCompat(texAtlasEntry, inMeshsetFlag) == true) {
                    texAtlasEntry.Value.SetActive(true);
                }
                else {
                    texAtlasEntry.Value.SetActive(false);
                }
            }
        }
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

}
