using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectOptionsController : MonoBehaviour {

    [SerializeField]GameObject AssetsDBController;
    CurrentSelectionAndDisplay currSelectionAndDisplayScript;

    [SerializeField] GameObject geomOptionsMenu;
    [SerializeField] GameObject entityOptionsMenu;
    [SerializeField] GameObject tilesetOptionsMenu;
    [SerializeField] GameObject templatesOptionsMenu;

    [SerializeField] GameObject optionsTitle_Geom;
    [SerializeField] GameObject optionsTitle_Entity;
    [SerializeField] GameObject optionsTitle_Tileset;
    [SerializeField] GameObject optionsTitle_Template;

    [SerializeField] GameObject ui_btnGeomPlacer;
    [SerializeField] GameObject ui_btnEntityPlacer;
    [SerializeField] GameObject ui_btnTilesetPlacer;
    [SerializeField] GameObject ui_btnTemplatePlacer;
 
    void Start() {
        currSelectionAndDisplayScript = AssetsDBController.GetComponent<CurrentSelectionAndDisplay>();
    }

    public void ActivateGeomOptions() {
        currSelectionAndDisplayScript.geom0_entity1 = false;

        //----- Menus -----------
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        geomOptionsMenu.SetActive(true);

        //----- Titles ---------
        optionsTitle_Entity.SetActive(false);
        optionsTitle_Tileset.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Geom.SetActive(true);

        //----- Buttons --------
        ui_btnEntityPlacer.SetActive(false);
        ui_btnTilesetPlacer.SetActive(false);
        ui_btnTemplatePlacer.SetActive(false);

        ui_btnGeomPlacer.SetActive(true);
    }

    public void ActivateEntitiesOptions() {
        currSelectionAndDisplayScript.geom0_entity1 = true;

        //----- Menus -----------
        geomOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        entityOptionsMenu.SetActive(true);

        //----- Titles ---------
        optionsTitle_Geom.SetActive(false);
        optionsTitle_Tileset.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Entity.SetActive(true);

        //----- Buttons --------
        ui_btnGeomPlacer.SetActive(false);
        ui_btnTilesetPlacer.SetActive(false);
        ui_btnTemplatePlacer.SetActive(false);

        ui_btnEntityPlacer.SetActive(true);
    }

    public void ActivateTilesetsOptions() {
        //----- Menus -----------
        geomOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);
       
        tilesetOptionsMenu.SetActive(true);

        //----- Titles ---------
        optionsTitle_Geom.SetActive(false);
        optionsTitle_Entity.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Tileset.SetActive(true);

        //----- Buttons --------
        ui_btnGeomPlacer.SetActive(false);
        ui_btnEntityPlacer.SetActive(false);
        ui_btnTemplatePlacer.SetActive(false);

        ui_btnTilesetPlacer.SetActive(true);
    }

    public void ActivateTemplatesOptions() {
        //----- Menus -----------
        geomOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);

        templatesOptionsMenu.SetActive(true);

        //----- Titles ---------
        optionsTitle_Geom.SetActive(false);
        optionsTitle_Entity.SetActive(false);
        optionsTitle_Tileset.SetActive(false);

        optionsTitle_Template.SetActive(true);

        //----- Buttons --------
        ui_btnGeomPlacer.SetActive(false);
        ui_btnEntityPlacer.SetActive(false);
        ui_btnTilesetPlacer.SetActive(false);

        ui_btnTemplatePlacer.SetActive(true);
    }


}
