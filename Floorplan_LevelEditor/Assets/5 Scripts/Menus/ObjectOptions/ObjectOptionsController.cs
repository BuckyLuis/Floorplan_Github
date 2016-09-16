using UnityEngine;
using System.Collections;

public class ObjectOptionsController : MonoBehaviour {

    [SerializeField] GameObject geomOptionsMenu;
    [SerializeField] GameObject entityOptionsMenu;
    [SerializeField] GameObject tilesetOptionsMenu;
    [SerializeField] GameObject templatesOptionsMenu;

    [SerializeField] GameObject optionsTitle_Geom;
    [SerializeField] GameObject optionsTitle_Entity;
    [SerializeField] GameObject optionsTitle_Tileset;
    [SerializeField] GameObject optionsTitle_Template;


	

    public void ActivateTileOptions() {
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        geomOptionsMenu.SetActive(true);


        optionsTitle_Entity.SetActive(false);
        optionsTitle_Tileset.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Geom.SetActive(true);
    }

    public void ActivateEntitiesOptions() {
        geomOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        entityOptionsMenu.SetActive(true);


        optionsTitle_Geom.SetActive(false);
        optionsTitle_Tileset.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Entity.SetActive(true);
    }

    public void ActivateTilesetsOptions() {
        geomOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);
       
        tilesetOptionsMenu.SetActive(true);


        optionsTitle_Geom.SetActive(false);
        optionsTitle_Entity.SetActive(false);
        optionsTitle_Template.SetActive(false);

        optionsTitle_Tileset.SetActive(true);
    }

    public void ActivateTemplatesOptions() {
        geomOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);

        templatesOptionsMenu.SetActive(true);


        optionsTitle_Geom.SetActive(false);
        optionsTitle_Entity.SetActive(false);
        optionsTitle_Tileset.SetActive(false);

        optionsTitle_Template.SetActive(true);
    }


}
