using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ElevationMenu : MonoBehaviour {

    [SerializeField] GameObject theGridsObject;
    [SerializeField] GameObject theMainCamera;

    [SerializeField] int floorYSize;   //how many units of Y is each floor

    public int currentFloor {get; protected set;}
    public int currentYpos  {get; protected set;}

    bool posF0_negB1;
//------- UI Element Refs -----------
    [SerializeField] GameObject ui_BtnElevateUp;
    [SerializeField] GameObject ui_BtnCenterElevate;
    [SerializeField] GameObject ui_BtnElevateDown;

    [SerializeField] GameObject ui_TxtCurrentFloor;
    [SerializeField] GameObject ui_TxtCurrentYpos;

    Text uiTxt_CurrentFloor;
    Text uiTxt_CurrentYpos;




	void Start () {
        uiTxt_CurrentFloor = ui_TxtCurrentFloor.GetComponent<Text>();
        uiTxt_CurrentYpos = ui_TxtCurrentYpos.GetComponent<Text>();
        currentFloor = 0;
        currentYpos = 0;

        uiTxt_CurrentFloor.text = "1F";
        uiTxt_CurrentYpos.text = "0 y";
	}
	
	public void FloorUp () {
        theGridsObject.transform.position = new Vector3 (20f, theGridsObject.transform.position.y + floorYSize, 20f);
        theMainCamera.transform.position = new Vector3 (0, theMainCamera.transform.position.y + floorYSize, 0);
        currentFloor++;
        currentYpos += floorYSize;
        if(currentFloor > -1) 
            posF0_negB1 = false;
        FigureDisplayInfo();
        uiTxt_CurrentYpos.text = string.Format( "{0} y", currentYpos ) ;
	}

    public void FloorDown () {
        theGridsObject.transform.position = new Vector3 (20f, theGridsObject.transform.position.y - floorYSize, 20f);
        theMainCamera.transform.position = new Vector3 (0,  theMainCamera.transform.position.y - floorYSize, 0);
        currentFloor--;
        currentYpos -= floorYSize;
        if(currentFloor < 0) 
            posF0_negB1 = true;
        FigureDisplayInfo();
        uiTxt_CurrentYpos.text = string.Format( "{0} y", currentYpos ) ;
       
    }

    public void FloorCenter () {
        theGridsObject.transform.position = new Vector3 (20f, -0.1f, 20f);
        theMainCamera.transform.position = new Vector3 (0, 0, 0);
        currentFloor = 0;
        currentYpos = 0;
        posF0_negB1 = false;
        FigureDisplayInfo();
        uiTxt_CurrentYpos.text = string.Format( "{0} y", currentYpos ) ;
    }

    void FigureDisplayInfo() {
        if(posF0_negB1 == false) {     //"F" - Floor
            uiTxt_CurrentFloor.text = string.Format( "{0}F", currentFloor + 1 );
        }
        else if(posF0_negB1 == true) {     //"B" - Basement
            uiTxt_CurrentFloor.text = string.Format( "B{0}", Mathf.Abs(currentFloor) );
        }
    }
}
