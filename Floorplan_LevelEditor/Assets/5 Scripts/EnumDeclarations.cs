using UnityEngine;
using System.Collections;
using System;


//from TilesetOptionsAndManager.cs
public enum RoleInTileset { NOSET, WALL, CORNER, CORNERINV, FLOOR, DOORJAMB, STAIRS, DIAG_CONTINUE, DIAG_CONEX, DIAG_ENDIN, DIAG_ENDOUT, DOODAD, PROP, SPECIAL, OTHER  }

// from TexturesViewerTexAtlasManagement.cs
public enum TexAtlasCategory { GEOMETRY, DOODADS, PROPS, ACTORS }


//from AssetsViewerAssetManagement.cs
public enum Categories_Floors { STANDARD, PUZZLE, HAZARD, SPECIAL }
public enum Categories_Walls { STANDARD, DOORJAMB, HAZARD, SPECIAL }        //TODO: come up with proper, needed categories
public enum Categories_Doodads { STANDARD, DECAL, SIGNS, SPECIAL }
public enum Categories_Props { STANDARD, ITEM, HAZARD, SPECIAL }
public enum Categories_Actors { STANDARD, FRIENDLY, ENEMY, BOSS }
public enum Categories_Triggers { STANDARD, SPAWNER, HAZARD, SPECIAL }

public enum Categories_Tilesets { STANDARD, SPAWNER, HAZARD, SPECIAL }
public enum Categories_Templates { STANDARD, SPAWNER, HAZARD, SPECIAL }

[Serializable] public class Dictionary_sGo : SerializableDictionary<string, GameObject> { }





public class EnumDeclarations : MonoBehaviour {

}
