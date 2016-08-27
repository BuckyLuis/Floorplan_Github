using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class ObjectFacingToolbar : MonoBehaviour {

    public static bool anInputFieldIsInFocus; 


  // [SerializeField] GameObject toolsController;
    WorldObjectInstantiator objInstantiatorScript;


    public float tileFacingRot  {get; protected set;}

    //------- UI Element Refs ----------------

    [SerializeField] GameObject ui_TileFacingSel_N;
    [SerializeField] GameObject ui_TileFacingSel_E;
    [SerializeField] GameObject ui_TileFacingSel_S;
    [SerializeField] GameObject ui_TileFacingSel_W;
    Image uiImg_tileFacingSel_N;
    Image uiImg_tileFacingSel_E;
    Image uiImg_tileFacingSel_S;
    Image uiImg_tileFacingSel_W;


    void Start () {
        objInstantiatorScript = GetComponent<WorldObjectInstantiator>();

        uiImg_tileFacingSel_N = ui_TileFacingSel_N.transform.GetComponent<Image>();
        uiImg_tileFacingSel_E = ui_TileFacingSel_E.transform.GetComponent<Image>();
        uiImg_tileFacingSel_S = ui_TileFacingSel_S.transform.GetComponent<Image>();
        uiImg_tileFacingSel_W = ui_TileFacingSel_W.transform.GetComponent<Image>();

        tileFacingRot = 0;
        uiImg_tileFacingSel_N.enabled = true;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 
    }
	
    void Update () {
        if(anInputFieldIsInFocus == false) {
            if(InputManager.GetAxis("Vertical") > 0) {      // W - N
                TileFacing_N();
            }

            if(InputManager.GetAxis("Horizontal") > 0) {    // D - E
                TileFacing_E(); 
            }

            if(InputManager.GetAxis("Vertical") < 0) {      // S - S
                TileFacing_S();
            }

            if(InputManager.GetAxis("Horizontal") < 0) {    // A - W
                TileFacing_W();
            }
        }
    }

    public void TileFacing_N() {
        tileFacingRot = 0;
        uiImg_tileFacingSel_N.enabled = true;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_E() {
        tileFacingRot = 90;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = true;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_S() {
        tileFacingRot = 180;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = true;
        uiImg_tileFacingSel_W.enabled = false; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

    public void TileFacing_W() {
        tileFacingRot = 270;
        uiImg_tileFacingSel_N.enabled = false;
        uiImg_tileFacingSel_E.enabled = false;
        uiImg_tileFacingSel_S.enabled = false;
        uiImg_tileFacingSel_W.enabled = true; 

        objInstantiatorScript.AssignObjectRot(tileFacingRot);
    }

}
