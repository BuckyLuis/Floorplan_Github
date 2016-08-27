using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;


public enum Categories_Floors { STANDARD, PUZZLE, HAZARD, SPECIAL }
public enum Categories_Walls { STANDARD, DOORJAMB, HAZARD, SPECIAL }        //TODO: come up with proper, needed categories
public enum Categories_Doodads { STANDARD, DECAL, SIGNS, SPECIAL }
public enum Categories_Props { STANDARD, ITEM, HAZARD, SPECIAL }
public enum Categories_Actors { STANDARD, FRIENDLY, ENEMY, BOSS }
public enum Categories_Triggers { STANDARD, SPAWNER, HAZARD, SPECIAL }

public enum Categories_Tilesets { STANDARD, SPAWNER, HAZARD, SPECIAL }
public enum Categories_Templates { STANDARD, SPAWNER, HAZARD, SPECIAL }

[Serializable] public class Dictionary_sGo : SerializableDictionary<string, GameObject> { }

public class AssetsViewerAssetManagement : MonoBehaviour {

    TilesetOptionsAndManager tilesetOptionsScript;


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
    public List<Asset_Tileset_Base> assetsList_Tilesets = new List<Asset_Tileset_Base>();
    public List<Asset_Template_Base> assetsList_Templates = new List<Asset_Template_Base>();
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
    public Dictionary_sGo assetsEntriesDict_Tilesets;
    public Dictionary_sGo assetsEntriesDict_Templates;
   
//---------------- UI refs ----------------------
    [Space(20, order = 5)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 6)] 

 
    [SerializeField] GameObject viewAreaFloors;
    [SerializeField] GameObject viewAreaWalls;
    [SerializeField] GameObject viewAreaDoodads;
    [SerializeField] GameObject viewAreaProps;
    [SerializeField] GameObject viewAreaActors;
    [SerializeField] GameObject viewAreaTriggers;
    [SerializeField] GameObject viewAreaTilesets;
    [SerializeField] GameObject viewAreaTemplates;

    [SerializeField] GameObject floorEntryPrefab;
    [SerializeField] GameObject wallEntryPrefab;
    [SerializeField] GameObject doodadEntryPrefab;
    [SerializeField] GameObject propEntryPrefab;
    [SerializeField] GameObject actorEntryPrefab;
    [SerializeField] GameObject triggerEntryPrefab;
    [SerializeField] GameObject tilesetEntryPrefab;
    [SerializeField] GameObject templateEntryPrefab;

    [Header ("--- --- --- --- --- ---", order = 7)]    

    GameObject tempEntry;


 #region PopulateViews
	void Start () {
        tilesetOptionsScript = GetComponent<TilesetOptionsAndManager>();
        PopulateAssetViews();
	}

    void PopulateAssetViews() {

//--------------------------------------------- FLOORS -----------------------------------------
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
            floorBasis.pageName = "Floors";
            floorBasis.categoryName = floorBasis.categoryFloors.ToString();
            floorBasis.categoryHotkey = (int)floorBasis.categoryFloors + 1;


            tempEntry = Instantiate(floorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Floors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Floors>();

            tempScript.assetBaseObject = floorBasis;
            tempScript.assetIndex = floorBasis.assetIndex;
            tempScript.assetWorldObject = floorBasis.worldObjectPrefab;
            tempScript.assetBaseObject.texturesetString = "0|" + floorBasis.texturesetFlag.ToString();     //establish the texAtlasCategory relationship (0 - GEOMETRY)


            assetsEntriesDict_Floors.Add(string.Format("{0}|{1}|{2}", (int)floorBasis.categoryFloors, floorBasis.assetIndex, floorBasis.tilesetIndex - 1), tempEntry);
        }

//--------------------------------------------- WALLS -----------------------------------------
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
            wallBasis.pageName = "Walls";
            wallBasis.categoryName = wallBasis.categoryWalls.ToString();
            wallBasis.categoryHotkey = (int)wallBasis.categoryWalls + 1;


            tempEntry = Instantiate(wallEntryPrefab);
            tempEntry.transform.SetParent(viewAreaWalls.transform, false);
            AssetsViewerEntry_Walls tempScript = tempEntry.GetComponent<AssetsViewerEntry_Walls>();

            tempScript.assetBaseObject = wallBasis;
            tempScript.assetIndex = wallBasis.assetIndex;
            tempScript.assetWorldObject = wallBasis.worldObjectPrefab;
            tempScript.assetBaseObject.texturesetString = "0|" + wallBasis.texturesetFlag.ToString();   //establish the texAtlasCategory relationship (0 - GEOMETRY)

            assetsEntriesDict_Walls.Add(string.Format("{0}|{1}|{2}", (int)wallBasis.categoryWalls, wallBasis.assetIndex, wallBasis.tilesetIndex - 1), tempEntry);
        }

//--------------------------------------------- DOODADS -----------------------------------------
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
            doodadBasis.pageName = "Doodads";
            doodadBasis.categoryName = doodadBasis.categoryDoodads.ToString();
            doodadBasis.categoryHotkey = (int)doodadBasis.categoryDoodads + 1;


            tempEntry = Instantiate(doodadEntryPrefab);
            tempEntry.transform.SetParent(viewAreaDoodads.transform, false);
            AssetsViewerEntry_Doodads tempScript = tempEntry.GetComponent<AssetsViewerEntry_Doodads>();

            tempScript.assetBaseObject = doodadBasis;
            tempScript.assetIndex = doodadBasis.assetIndex;
            tempScript.assetWorldObject = doodadBasis.worldObjectPrefab;
            tempScript.assetBaseObject.texturesetString = "1|" + doodadBasis.texturesetFlag.ToString();   //establish the texAtlasCategory relationship (1 - DOODADS)

            assetsEntriesDict_Doodads.Add(string.Format("{0}|{1}|{2}", (int)doodadBasis.categoryDoodads, doodadBasis.assetIndex, doodadBasis.tilesetIndex - 1), tempEntry);
        }
            
//--------------------------------------------- PROPS -----------------------------------------
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
            propBasis.pageName = "Props";
            propBasis.categoryName = propBasis.categoryProps.ToString();
            propBasis.categoryHotkey = (int)propBasis.categoryProps + 1;


            tempEntry = Instantiate(propEntryPrefab);
            tempEntry.transform.SetParent(viewAreaProps.transform, false);
            AssetsViewerEntry_Props tempScript = tempEntry.GetComponent<AssetsViewerEntry_Props>();

            tempScript.assetBaseObject = propBasis;
            tempScript.assetIndex = propBasis.assetIndex;
            tempScript.assetWorldObject = propBasis.worldObjectPrefab;
            tempScript.assetBaseObject.texturesetString = "2|" + propBasis.texturesetFlag.ToString();  //establish the texAtlasCategory relationship (2 - PROPS)

            assetsEntriesDict_Props.Add(string.Format("{0}|{1}|{2}", (int)propBasis.categoryProps, propBasis.assetIndex, propBasis.tilesetIndex - 1), tempEntry);
        }

//--------------------------------------------- ACTORS -----------------------------------------
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
            actorBasis.pageName = "Actors";
            actorBasis.categoryName = actorBasis.categoryActors.ToString();
            actorBasis.categoryHotkey = (int)actorBasis.categoryActors + 1;


            tempEntry = Instantiate(actorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaActors.transform, false);
            AssetsViewerEntry_Actors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Actors>();
         
            tempScript.assetBaseObject = actorBasis;
            tempScript.assetIndex = actorBasis.assetIndex;
            tempScript.assetWorldObject = actorBasis.worldObjectPrefab;
            tempScript.assetBaseObject.texturesetString = "3|" + actorBasis.texturesetFlag.ToString(); //establish the texAtlasCategory relationship (3 - ACTORS)

            assetsEntriesDict_Actors.Add(string.Format("{0}|{1}", (int)actorBasis.categoryActors, actorBasis.assetIndex), tempEntry);
        }

//--------------------------------------------- TRIGGERS -----------------------------------------
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
            triggerBasis.pageName = "Triggers";
            triggerBasis.categoryName = triggerBasis.categoryTriggers.ToString();
            triggerBasis.categoryHotkey = (int)triggerBasis.categoryTriggers + 1;


            tempEntry = Instantiate(triggerEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTriggers.transform, false);
            AssetsViewerEntry_Triggers tempScript = tempEntry.GetComponent<AssetsViewerEntry_Triggers>();

            tempScript.assetBaseObject = triggerBasis;
            tempScript.assetIndex = triggerBasis.assetIndex;
            tempScript.assetWorldObject = triggerBasis.worldObjectPrefab;
            //triggers have no in-game texture

            assetsEntriesDict_Triggers.Add(string.Format("{0}|{1}", (int)triggerBasis.categoryTriggers, triggerBasis.assetIndex), tempEntry);
        }

//--------------------------------------------- TILESETS -----------------------------------------
        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        for (int i = 0; i < assetsList_Tilesets.Count; i++) { //foreach (var tilesetBasis in assetsList_Tilesets) {  //use a for() here because i need to work with the index of the currentTileset
            Asset_Tileset_Base tilesetBasis = assetsList_Tilesets[i];

            switch ((int)tilesetBasis.categoryTilesets)
            {
                case 0:
                    tilesetBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    tilesetBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    tilesetBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    tilesetBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(tilesetEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTilesets.transform, false);

            AssetsViewerEntry_Tilesets tempScript = tempEntry.GetComponent<AssetsViewerEntry_Tilesets>();

            tempScript.assetTileset_BaseObject = tilesetBasis;
            tempScript.assetIndex = tilesetBasis.assetIndex;
            tempScript.assetTileset_BaseObject.tilesetIndex = i;

            GameObject tempGO;
            foreach (KeyValuePair<string, GameObject> floorEntry in assetsEntriesDict_Floors) {
                tempGO = AssignEntriesToTileset(i, floorEntry);
                if(tempGO != null)
                    tempScript.assetTileset_BaseObject.tilesetMembers.Add(tempGO);
            }
            foreach (KeyValuePair<string, GameObject> wallEntry in assetsEntriesDict_Walls) {
                tempGO = AssignEntriesToTileset(i, wallEntry);
                if(tempGO != null)
                    tempScript.assetTileset_BaseObject.tilesetMembers.Add(tempGO);
            }
            foreach (KeyValuePair<string, GameObject> doodadEntry in assetsEntriesDict_Doodads) {
                tempGO = AssignEntriesToTileset(i, doodadEntry);
                if(tempGO != null)
                    tempScript.assetTileset_BaseObject.tilesetMembers.Add(tempGO);
            }
            foreach (KeyValuePair<string, GameObject> propEntry in assetsEntriesDict_Doodads) {
                tempGO = AssignEntriesToTileset(i, propEntry);
                if(tempGO != null)
                    tempScript.assetTileset_BaseObject.tilesetMembers.Add(tempGO);
            }

            tilesetBasis.displayMembers = tilesetBasis.tilesetMembers.OrderBy( member => (int)member.GetComponent<AssetBasis>().tilesetRole).ToList();

            tilesetOptionsScript.PopulateMembersDict(tilesetBasis, tilesetBasis.tilesetIndex);
            assetsEntriesDict_Tilesets.Add(string.Format("{0}|{1}|{2}", (int)tilesetBasis.categoryTilesets, tilesetBasis.assetIndex, i), tempEntry);
        }

//--------------------------------------------- TEMPLATES -----------------------------------------
        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var templateBasis in assetsList_Templates) {
            switch ((int)templateBasis.categoryTemplates)
            {
                case 0:
                    templateBasis.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    templateBasis.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    templateBasis.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    templateBasis.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(templateEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTemplates.transform, false);
            AssetsViewerEntry_Templates tempScript = tempEntry.GetComponent<AssetsViewerEntry_Templates>();

            tempScript.assetTemplate_BaseObject = templateBasis;
            tempScript.assetIndex = templateBasis.assetIndex;
            tempScript.assetWorldObject = templateBasis.worldObjectPrefab;
            //triggers have no in-game texture

            assetsEntriesDict_Templates.Add(string.Format("{0}|{1}", (int)templateBasis.categoryTemplates, templateBasis.assetIndex), tempEntry);
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

    public void ShowCategory_Tilesets(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> tilesetEntry in assetsEntriesDict_Tilesets) {
            if(SplitDictKey_GetCategory(tilesetEntry) == categoryIndex) {
                tilesetEntry.Value.SetActive(true);
            }
            else {
                tilesetEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Templates(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> templateEntry in assetsEntriesDict_Templates) {
            if(SplitDictKey_GetCategory(templateEntry) == categoryIndex) {
                templateEntry.Value.SetActive(true);
            }
            else {
                templateEntry.Value.SetActive(false);
            }
        }
    }


    int SplitDictKey_GetCategory(KeyValuePair<string, GameObject> entryToSplit) {
        string[] tempStringArray = entryToSplit.Key.Split('|');
        int entryCategory = int.Parse(tempStringArray[0]);
        return entryCategory;
    }


    GameObject AssignEntriesToTileset(int index, KeyValuePair<string, GameObject> testEntry) {
        if(SplitDictKey_GetTileset(testEntry) == index) {
            return testEntry.Value;
        }
        return null;
    }

    int SplitDictKey_GetTileset(KeyValuePair<string, GameObject> entryToSplit) {
        string[] tempStringArray = entryToSplit.Key.Split('|');
        int entryTileset = int.Parse(tempStringArray[2]);
        return entryTileset;
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
