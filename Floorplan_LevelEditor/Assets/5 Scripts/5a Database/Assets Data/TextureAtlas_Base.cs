using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TextureAtlas_Base {

    [HideInInspector] public int texAtlasIndex;     //assigned programmatically, TexturesViewerTexAtlasManagement.cs/PopulateTexAtlasView()

    public string texAtlasName;
 //   public TexAtlasCategory texAtlasCategory;   //unnecessary now that i split texatlas lists into multiple lists
    public string texAtlasCompatMeshsets;

    public Color texAtlasTilesetColor;
    public Material texAtlasMatObject;

}
