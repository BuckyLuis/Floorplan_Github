using UnityEngine;
using System.Collections;

public class GlobalInitialization : MonoBehaviour {

    RoomViewerMenu theRoomViewerMenuScript;
    AreaTilesRegistry theAreaTilesRegistryScript;

    [SerializeField] GameObject theToolsController;
    UndoRedoManager theUndoRedoManagerScript;

    [SerializeField] GameObject theAssetsDBController;
    TexturesViewerTexAtlasManagement theTexAtlasManagerScript;
    TexturesViewerTexPreviewer  theTexturePreviewerScript;
    CurrentSelectionAndDisplay theCurrSelNDisplayScript;
    AssetsViewerHotkeysUiControl theAssetViewerHotkeyScript;

    ElevationMenu theElevationMenuScript;

    [SerializeField] GameObject thePlacerWidget;
    TilePlacer theTilePlacerScript;

    [SerializeField] GameObject theWorldGeomParent;
    [SerializeField] GameObject theWorldEntityParent;
    [SerializeField] GameObject theWorldCamboundsParent;
  

    void Start() {
        theRoomViewerMenuScript = GetComponent<RoomViewerMenu>();
        theAreaTilesRegistryScript = GetComponent<AreaTilesRegistry>();
        theUndoRedoManagerScript = theToolsController.GetComponent<UndoRedoManager>();
        theCurrSelNDisplayScript = theAssetsDBController.GetComponent<CurrentSelectionAndDisplay>();
        theAssetViewerHotkeyScript = theAssetsDBController.GetComponent<AssetsViewerHotkeysUiControl>();
        theElevationMenuScript = theToolsController.GetComponent<ElevationMenu>();
        theTilePlacerScript = thePlacerWidget.GetComponent<TilePlacer>();
    }
	
	public void InitializeGlobal() {          
        theRoomViewerMenuScript.InitRoomViewerMenu();
        theAreaTilesRegistryScript.InitTilesRegistry();
        theUndoRedoManagerScript.InitUndoRedoMngr();
        theTexAtlasManagerScript.InitTexturesViewer();
        theTexturePreviewerScript.InitTexturePreviewer();
        theCurrSelNDisplayScript.InitCurrSelNDisplay();
        theAssetViewerHotkeyScript.InitAssetViewerPagesNHotkey();
        theElevationMenuScript.InitElevationMenu();

        theTilePlacerScript.InitTilePlacer();

        foreach(Transform child in theWorldGeomParent.transform) {
            Destroy(child.gameObject);
        }
        foreach(Transform child in theWorldEntityParent.transform) {
            Destroy(child.gameObject);
        }
        foreach(Transform child in theWorldCamboundsParent.transform) {
            Destroy(child.gameObject);
        }
	}
}
