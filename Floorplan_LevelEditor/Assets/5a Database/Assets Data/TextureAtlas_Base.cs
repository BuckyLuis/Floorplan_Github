using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TextureAtlas_Base {

    public string texAtlasName;
    public TexAtlasCategory texAtlasCategory;
    public List<int> texAtlasCompatMeshsets = new List<int>();

    public Color texAtlasTilesetColor;
    public Material texAtlasMatObject;

}
