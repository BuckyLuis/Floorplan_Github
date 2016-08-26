using UnityEngine;
using System.Collections;

public class ObjectOptionsController : MonoBehaviour {

    [SerializeField] GameObject tileOptionsMenu;
    [SerializeField] GameObject entityOptionsMenu;
    [SerializeField] GameObject tilesetOptionsMenu;
    [SerializeField] GameObject templatesOptionsMenu;

	

    public void ActivateTileOptions() {
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        tileOptionsMenu.SetActive(true);
    }

    public void ActivateEntitiesOptions() {
        tileOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);

        entityOptionsMenu.SetActive(true);
    }

    public void ActivateTilesetsOptions() {
        tileOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        templatesOptionsMenu.SetActive(false);
       
        tilesetOptionsMenu.SetActive(true);
    }

    public void ActivateTemplatesOptions() {
        tileOptionsMenu.SetActive(false);
        entityOptionsMenu.SetActive(false);
        tilesetOptionsMenu.SetActive(false);

        templatesOptionsMenu.SetActive(true);
    }


}
