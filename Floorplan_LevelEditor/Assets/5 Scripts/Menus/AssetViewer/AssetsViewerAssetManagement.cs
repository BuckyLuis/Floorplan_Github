using UnityEngine;
using System.Collections.Generic;
using System;


public enum Categories_Floors { STANDARD, PUZZLE, HAZARD, SPECIAL }
public enum Categories_Walls { STANDARD, DOORJAMB, HAZARD, SPECIAL }        //TODO: come up with proper, needed categories
public enum Categories_Doodads { STANDARD, DOORJAMB, SIGNS, SPECIAL }
public enum Categories_Props { STANDARD, ITEM, HAZARD, SPECIAL }
public enum Categories_Actors { STANDARD, FRIENDLY, ENEMY, BOSS }
public enum Categories_Triggers { STANDARD, SPAWNER, HAZARD, SPECIAL }


public class AssetsViewerAssetManagement : MonoBehaviour {


//------------- Assets Lists -------------
    [Header ("--- Asset Lists ---")]
    public List<Asset_Floor_Base> assetsList_Floors = new List<Asset_Floor_Base>();
    public List<Asset_Wall_Base> assetsList_Walls = new List<Asset_Wall_Base>();
    public List<Asset_Doodad_Base> assetsList_Doodads = new List<Asset_Doodad_Base>();
    public List<Asset_Prop_Base> assetsList_Props = new List<Asset_Prop_Base>();
    public List<Asset_Actor_Base> assetsList_Actors = new List<Asset_Actor_Base>();
    public List<Asset_Trigger_Base> assetsList_Triggers = new List<Asset_Trigger_Base>();
   
//---------------- UI refs ----------------------
   
    [Header (" --- UI references - DO NOT EDIT! --- ")]
    [Space(50)]
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



	void Start () {
	
	}
	
	void Update () {
	
	}
}
