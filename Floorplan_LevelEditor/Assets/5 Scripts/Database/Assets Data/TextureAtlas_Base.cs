using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TextureAtlas_Base {
    
    public string texAtlasName;
    [HideInInspector] public int texAtlasIndex;     //assigned programmatically, TexturesViewerTexAtlasManagement.cs/PopulateTexAtlasView()
 //   public TexAtlasCategory texAtlasCategory;   //unnecessary now that i split texatlas lists into multiple lists
    public string texAtlasCompatMeshsets;

    public Color texAtlasTilesetColor;
    public Material texAtlasMatObject;

}
