using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TexturesViewerTexPreviewer : MonoBehaviour {

    [SerializeField] GameObject ui_texPreviewerObject;
    RawImage uiRawImg_texPreviewer;

    [SerializeField] Material defaultTestMat;

	void Start () {
        uiRawImg_texPreviewer = ui_texPreviewerObject.GetComponent<RawImage>();
	}
	
	public void ReceiveAssetUvMapFlag (int uvMapSectorFlag) {
        switch (uvMapSectorFlag)        //X, Y, w, h
        {
            case 0:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0.75f, 0.25f, 0.25f );
                break;
            case 1:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.25f, 0.75f, 0.25f, 0.25f );
                break;
            case 2:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0.75f, 0.25f, 0.25f );
                break;
            case 3:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.75f, 0.75f, 0.25f, 0.25f );
                break;
            case 4:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0.5f, 0.25f, 0.25f );
                break;
            case 5:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.25f, 0.5f, 0.25f, 0.25f );
                break;
            case 6:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0.5f, 0.25f, 0.25f );
                break;
            case 7:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.75f, 0.5f, 0.25f, 0.25f );
                break;
            case 8:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0.25f, 0.25f, 0.25f );
                break;
            case 9:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.25f, 0.25f, 0.25f, 0.25f );
                break;
            case 10:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0.25f, 0.25f, 0.25f );
                break;
            case 11:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.75f, 0.25f, 0.25f, 0.25f );
                break;
            case 12:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0, 0.25f, 0.25f );
                break;
            case 13:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.25f, 0, 0.25f, 0.25f );
                break;
            case 14:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0, 0.25f, 0.25f );
                break;
            case 15:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.75f, 0, 0.25f, 0.25f );
                break;
            
        //------- tex split to 4 ------
            case 20:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0.5f, 0.5f, 0.5f );
                break;
            case 21:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0.5f, 0.5f, 0.5f );
                break;
            case 22:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0, 0.5f, 0.5f );
                break;
            case 23:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0.5f, 0, 0.5f, 0.5f );
                break;

        //------- full texture ------
            case 30:
                uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0, 1, 1 );
                break;
        }
	}


    public void DrawTexturePreview(Material theMaterial) {
        uiRawImg_texPreviewer.texture = theMaterial.mainTexture;
    }

    public void InitTexturePreviewer() {
        uiRawImg_texPreviewer.uvRect = new Rect ( 0, 0, 1, 1 );
        uiRawImg_texPreviewer.texture = defaultTestMat.mainTexture;
    }

}
