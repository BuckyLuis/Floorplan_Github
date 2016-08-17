using UnityEngine;
using System.Collections.Generic;
using System;


public enum Categories_Floors { STANDARD, PUZZLE, HAZARD, SPECIAL }
public enum Categories_Walls { STANDARD, DOORJAMB, HAZARD, SPECIAL }        //TODO: come up with proper, needed categories
public enum Categories_Doodads { STANDARD, DECAL, SIGNS, SPECIAL }
public enum Categories_Props { STANDARD, ITEM, HAZARD, SPECIAL }
public enum Categories_Actors { STANDARD, FRIENDLY, ENEMY, BOSS }
public enum Categories_Triggers { STANDARD, SPAWNER, HAZARD, SPECIAL }

[Serializable] public class Dictionary_sGo : SerializableDictionary<string, GameObject> { }

public class AssetsViewerAssetManagement : MonoBehaviour {


    int assetIndexCounterCat0;  //these counters assign indices to assets, it is used to assign hotkey #s
    int assetIndexCounterCat1;
    int assetIndexCounterCat2;
    int assetIndexCounterCat3;
//------------- Assets Lists --------------------
    [Header (">>> >>> --- Asset Lists --- <<< <<<", order = 0)]            //in the editor you setup references to all of the asset's vars
    public List<Asset_Floor_Base> assetsList_Floors = new List<Asset_Floor_Base>();
    public List<Asset_Wall_Base> assetsList_Walls = new List<Asset_Wall_Base>();
    public List<Asset_Doodad_Base> assetsList_Doodads = new List<Asset_Doodad_Base>();
    public List<Asset_Prop_Base> assetsList_Props = new List<Asset_Prop_Base>();
    public List<Asset_Actor_Base> assetsList_Actors = new List<Asset_Actor_Base>();
    public List<Asset_Trigger_Base> assetsList_Triggers = new List<Asset_Trigger_Base>();
    [Space(40, order = 1)]
    [Header (" ^^^ ^^^ --- --- --- --- --- --- ^^^ ^^^ ", order = 2)]    


    //----------- Assets Dicts ----------------------  //these Dictionaries exist simply to denote seperation of the assets into types and categories.
    [Space(120, order = 3)]
    [Header (" --- Assets Dicts - DO NOT EDIT! --- ", order = 4)]  // these Dictionaries hold references to the constructed AssetViewerEntry objects



    public Dictionary_sGo assetsEntriesDict_Floors;
    public Dictionary_sGo assetsEntriesDict_Walls;
    public Dictionary_sGo assetsEntriesDict_Doodads;
    public Dictionary_sGo assetsEntriesDict_Props;
    public Dictionary_sGo assetsEntriesDict_Actors;
    public Dictionary_sGo assetsEntriesDict_Triggers;
   
//---------------- UI refs ----------------------
    [Space(20, order = 5)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 6)] 

 
    [SerializeField] GameObject viewAreaFloors;
    [SerializeField] GameObject viewAreaWalls;
    [SerializeField] GameObject viewAreaDoodads;
    [SerializeField] GameObject viewAreaProps;
    [SerializeField] GameObject viewAreaActors;
    [SerializeField] GameObject viewAreaTriggers;

    [SerializeField] GameObject floorEntryPrefab;
    [SerializeField] GameObject wallEntryPrefab;
    [SerializeField] GameObject doodadEntryPrefab;
    [SerializeField] GameObject propEntryPrefab;
    [SerializeField] GameObject actorEntryPrefab;
    [SerializeField] GameObject triggerEntryPrefab;

    [Header ("--- --- --- --- --- ---", order = 7)]    

    GameObject tempEntry;


 #region PopulateViews
	void Start () {
        PopulateAssetViews();
	}

    void PopulateAssetViews() {
        
        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var floorBasis in assetsList_Floors) {
            switch ((int)floorBasis.categoryFloors)
            {
                case 0:
                    floorBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    floorBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    floorBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    floorBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(floorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Floors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Floors>();

            tempScript.assetFloor_BaseObject = floorBasis;
            tempScript.assetIndex = floorBasis.assetIndex;
            tempScript.assetWorldObject = floorBasis.worldObjectPrefab;
            tempScript.assetFloor_BaseObject.meshsetString = "0|" + floorBasis.meshsetFlag.ToString();     //establish the texAtlasCategory relationship (0 - GEOMETRY)


            assetsEntriesDict_Floors.Add(string.Format("{0},{1}", (int)floorBasis.categoryFloors, floorBasis.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var wallBasis in assetsList_Walls) {
            switch ((int)wallBasis.categoryWalls)
            {
                case 0:
                    wallBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    wallBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    wallBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    wallBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(wallEntryPrefab);
            tempEntry.transform.SetParent(viewAreaWalls.transform, false);
            AssetsViewerEntry_Walls tempScript = tempEntry.GetComponent<AssetsViewerEntry_Walls>();

            tempScript.assetWall_BaseObject = wallBasis;
            tempScript.assetIndex = wallBasis.assetIndex;
            tempScript.assetWorldObject = wallBasis.worldObjectPrefab;
            tempScript.assetWall_BaseObject.meshsetString = "0|" + wallBasis.meshsetFlag.ToString();   //establish the texAtlasCategory relationship (0 - GEOMETRY)

            assetsEntriesDict_Walls.Add(string.Format("{0},{1}", (int)wallBasis.categoryWalls, wallBasis.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var doodadBasis in assetsList_Doodads) {
            switch ((int)doodadBasis.categoryDoodads)
            {
                case 0:
                    doodadBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    doodadBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    doodadBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    doodadBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }
            tempEntry = Instantiate(doodadEntryPrefab);
            tempEntry.transform.SetParent(viewAreaDoodads.transform, false);
            AssetsViewerEntry_Doodads tempScript = tempEntry.GetComponent<AssetsViewerEntry_Doodads>();

            tempScript.assetDoodad_BaseObject = doodadBasis;
            tempScript.assetIndex = doodadBasis.assetIndex;
            tempScript.assetWorldObject = doodadBasis.worldObjectPrefab;
            tempScript.assetDoodad_BaseObject.meshsetString = "1|" + doodadBasis.meshsetFlag.ToString();   //establish the texAtlasCategory relationship (1 - DOODADS)

            assetsEntriesDict_Doodads.Add(string.Format("{0},{1}", (int)doodadBasis.categoryDoodads, doodadBasis.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var propBasis in assetsList_Props) {
            switch ((int)propBasis.categoryProps)
            {
                case 0:
                    propBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    propBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    propBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    propBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(propEntryPrefab);
            tempEntry.transform.SetParent(viewAreaProps.transform, false);
            AssetsViewerEntry_Props tempScript = tempEntry.GetComponent<AssetsViewerEntry_Props>();

            tempScript.assetProp_BaseObject = propBasis;
            tempScript.assetIndex = propBasis.assetIndex;
            tempScript.assetWorldObject = propBasis.worldObjectPrefab;
            tempScript.assetProp_BaseObject.meshsetString = "2|" + propBasis.meshsetFlag.ToString();  //establish the texAtlasCategory relationship (2 - PROPS)

            assetsEntriesDict_Props.Add(string.Format("{0},{1}", (int)propBasis.categoryProps, propBasis.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var actorBasis in assetsList_Actors) {
            switch ((int)actorBasis.categoryActors)
            {
                case 0:
                    actorBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    actorBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    actorBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    actorBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(actorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaActors.transform, false);
            AssetsViewerEntry_Actors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Actors>();
         
            tempScript.assetActor_BaseObject = actorBasis;
            tempScript.assetIndex = actorBasis.assetIndex;
            tempScript.assetWorldObject = actorBasis.worldObjectPrefab;
            tempScript.assetActor_BaseObject.meshsetString = "3|" + actorBasis.meshsetFlag.ToString(); //establish the texAtlasCategory relationship (3 - ACTORS)

            assetsEntriesDict_Actors.Add(string.Format("{0},{1}", (int)actorBasis.categoryActors, actorBasis.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var triggerBasis in assetsList_Triggers) {
            switch ((int)triggerBasis.categoryTriggers)
            {
                case 0:
                    triggerBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    triggerBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    triggerBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    triggerBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(triggerEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTriggers.transform, false);
            AssetsViewerEntry_Triggers tempScript = tempEntry.GetComponent<AssetsViewerEntry_Triggers>();

            tempScript.assetTrigger_BaseObject = triggerBasis;
            tempScript.assetIndex = triggerBasis.assetIndex;
            tempScript.assetWorldObject = triggerBasis.worldObjectPrefab;
            //triggers have no in-game texture

            assetsEntriesDict_Triggers.Add(string.Format("{0}|{1}", (int)triggerBasis.categoryTriggers, triggerBasis.assetIndex), tempEntry);
        }
            
    }
#endregion
	

    public void ShowCategory_Floors(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> floorEntry in assetsEntriesDict_Floors) {
            if(SplitDictKey_GetCategory(floorEntry) == categoryIndex) {
                floorEntry.Value.SetActive(true);
            }
            else {
                floorEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Walls(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> wallEntry in assetsEntriesDict_Walls) {
            if(SplitDictKey_GetCategory(wallEntry) == categoryIndex) {
                wallEntry.Value.SetActive(true);
            }
            else {
                wallEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Doodads(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> doodadEntry in assetsEntriesDict_Doodads) {
            if(SplitDictKey_GetCategory(doodadEntry) == categoryIndex) {
                doodadEntry.Value.SetActive(true);
            }
            else {
                doodadEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Props(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> propEntry in assetsEntriesDict_Props) {
            if(SplitDictKey_GetCategory(propEntry) == categoryIndex) {
                propEntry.Value.SetActive(true);
            }
            else {
                propEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Actors(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> actorEntry in assetsEntriesDict_Actors) {
            if(SplitDictKey_GetCategory(actorEntry) == categoryIndex) {
                actorEntry.Value.SetActive(true);
            }
            else {
                actorEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Triggers(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> triggerEntry in assetsEntriesDict_Triggers) {
            if(SplitDictKey_GetCategory(triggerEntry) == categoryIndex) {
                triggerEntry.Value.SetActive(true);
            }
            else {
                triggerEntry.Value.SetActive(false);
            }
        }
    }


    int SplitDictKey_GetCategory(KeyValuePair<string, GameObject> entryToSplit) {
        string[] tempStringArray = entryToSplit.Key.Split('|');
        int entryCategory = int.Parse(tempStringArray[0]);
        return entryCategory;
    }
        

    public void EntryFromHotkey(int assetBaseTypeFlag, string entryDictKey) {
        GameObject theEntryObject;

        switch (assetBaseTypeFlag)
        {
            case 1:
                assetsEntriesDict_Floors.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Floors>().SelectFromHotkey();
                break;
            case 2:
                assetsEntriesDict_Walls.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Walls>().SelectFromHotkey();
                break;
            case 3:
                assetsEntriesDict_Doodads.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Doodads>().SelectFromHotkey();
                break;
            case 4:
                assetsEntriesDict_Props.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Props>().SelectFromHotkey();
                break;
            case 5:
                assetsEntriesDict_Actors.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Actors>().SelectFromHotkey();
                break;
            case 6:
                assetsEntriesDict_Triggers.TryGetValue(entryDictKey, out theEntryObject);
                if(theEntryObject != null)
                    theEntryObject.GetComponent<AssetsViewerEntry_Triggers>().SelectFromHotkey();
                break;
        }
    }

}
