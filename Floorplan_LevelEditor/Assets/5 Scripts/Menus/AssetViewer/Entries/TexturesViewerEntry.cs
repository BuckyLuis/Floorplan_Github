using UnityEngine;
using System.Collections.Generic;

public class TexturesViewerEntry : MonoBehaviour {

    [SerializeField] GameObject assetsDbController;


    public Material texAtlasMatObject;

//----------- texAtlas Datas -------------------------
   /* public string texAtlasName;
    public TexAtlasCategory texAtlasCategory;
    public List<int> texAtlasCompatMeshsets = new List<int>();

    public Color texAtlasTilesetColor;*/

    public TextureAtlas_Base texAtlasBaseObject;
    public Texture texAtlasDisplayTexture;

//------------ UI Refs ----------------------------------
    [Space(30)]
    [SerializeField] GameObject nameObject;

    [SerializeField] GameObject indexHkObject2;
    [SerializeField] GameObject indexHkObject3;

    [SerializeField] GameObject matDisplayObject;

    [SerializeField] GameObject toggleObject;

}
