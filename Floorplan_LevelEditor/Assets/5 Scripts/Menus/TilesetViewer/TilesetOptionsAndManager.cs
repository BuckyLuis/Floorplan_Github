using UnityEngine;
using System.Collections.Generic;

//public enum RoleInTileset { NOSET, WALL, CORNER, CORNERINV, FLOOR, DOORJAMB, STAIRS, DIAG_CONTINUE, DIAG_CONEX, DIAG_ENDIN, DIAG_ENDOUT, DOODAD, PROP, SPECIAL, OTHER  }

[System.Serializable] public class Dictionary_iGo : SerializableDictionary<int, GameObject> { }

public class TilesetOptionsAndManager : MonoBehaviour {

    public Dictionary_iGo tsMembersEntriesDict;


    [SerializeField] GameObject memberEntryPrefab;
    GameObject tempMemberEntry;

    [SerializeField] GameObject viewAreaTilesetMembers;


    void Start() {
    }

    public void PopulateMembersDict(Asset_Tileset_Base theTilesetBase, int theTilesetIndex) {
        foreach(GameObject memberEntry in theTilesetBase.displayMembers) {
            tempMemberEntry = Instantiate(memberEntryPrefab);
            tempMemberEntry.transform.SetParent(viewAreaTilesetMembers.transform, false);

            TilesetMemberEntry tempScript = tempMemberEntry.GetComponent<TilesetMemberEntry>();
            tempScript.theAssetEntry = memberEntry;

            tempScript.AssignDatasToUI();

            tsMembersEntriesDict.Add(theTilesetIndex, tempMemberEntry);
            tempMemberEntry.SetActive(false);
        }
    }


    public void ActivateChosenTsMembers(int tilesetIndex) {
        foreach (KeyValuePair<int, GameObject> tsMemberEntry in tsMembersEntriesDict) {
            if(tsMemberEntry.Key == tilesetIndex) {
                tsMemberEntry.Value.SetActive(true);
            }
        }
    }


}

