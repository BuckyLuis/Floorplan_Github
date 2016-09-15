using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntityPropertyEntry : MonoBehaviour {


//--------------- UI Refs -------------------------
    [SerializeField] GameObject ui_TxtPropertyName;
    [SerializeField] GameObject ui_PropertyInputField;
    [SerializeField] GameObject ui_PropertyDropdown;    
    [SerializeField] GameObject ui_PropertyTogglesPanel;

    Text uiTxt_PropertyName;
    InputField uiIF_InputField;

    Dropdown uiDrop_Dropdown;

    ToggleGroup thisEntryToggleGroup;


    void Start() {
        uiTxt_PropertyName = ui_TxtPropertyName.GetComponent<Text>();
        uiIF_InputField = ui_PropertyInputField.GetComponent<InputField>();

        uiDrop_Dropdown = ui_PropertyDropdown.GetComponent<Dropdown>();

        thisEntryToggleGroup = GetComponent<ToggleGroup>();
    }
}
