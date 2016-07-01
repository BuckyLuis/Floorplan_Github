using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour 
{
    public GameObject databaseController;
    CurrentSettings currSettingsScript;
    CreateNewRoom newRoomScript;

    bool fromNewRoom = false;
    public GameObject newRoomColorButton;
    bool fromRoomViewer = false;
    public GameObject viewerRoomColorButton;

    public GameObject parentPanel;

	//-------------- color pick -------------------------------------------------
	public Texture2D colorPicker;  
	/*  
            /!\ Don't forget to make the texture readable
            (Select your texture : in Inspector
            [Texture Import Setting] > Texture Type > Advanced > Read/Write enabled > True  then Apply)     */
	public Color theCol;  
	public static Color outputCol;
	
    RectTransform uiRectTransform;
    Rect colorPanelRect;     
	public GUIStyle guiStyle;
	
	//-----------------------------------------------------------------
    void Start() {
        currSettingsScript = databaseController.GetComponent<CurrentSettings>();
        newRoomScript = databaseController.GetComponent<CreateNewRoom>();

        uiRectTransform = gameObject.GetComponent<RectTransform>();
        colorPanelRect = RectTransformToScreenSpace(uiRectTransform);
        Debug.Log(colorPanelRect);
    }

    public static Rect RectTransformToScreenSpace( RectTransform transform ) {
        Vector2 size = Vector2.Scale( transform.rect.size, transform.lossyScale );
        return new Rect( transform.position.x, Screen.height - transform.position.y, size.x, size.y );
    }


	void OnGUI() {
		GUI.DrawTexture(colorPanelRect, colorPicker);
		if (GUI.Button(colorPanelRect, "", guiStyle)) {
			Vector2 pickpos  = Event.current.mousePosition;
			float aaa  = pickpos.x - colorPanelRect.x;
			float bbb  =  pickpos.y - colorPanelRect.y;
			
			int aaa2  = (int)(aaa * (colorPicker.width / (colorPanelRect.width + 0.0f)));
			int bbb2  =  (int)((colorPanelRect.height - bbb) * (colorPicker.height / (colorPanelRect.height + 0.0f)));
			Color col  = colorPicker.GetPixel(aaa2, bbb2);
			
			outputCol = col;


            if(fromNewRoom) {
                newRoomColorButton.GetComponent<Button>().image.color = outputCol;
                newRoomScript.ChangeRoomColor(outputCol);
            }
            if(fromRoomViewer) {
                if(viewerRoomColorButton != null) {
                    viewerRoomColorButton.GetComponent<Button>().image.color = outputCol;
                    currSettingsScript.SetRoomColor(outputCol);
                }
                else {
                    Debug.LogError("ColorPicker -- RoomViewer Entry not found!!");
                }
            }
            fromNewRoom = false;
            fromRoomViewer = false;
			enabled = false;
            parentPanel.SetActive(false);
			
			
			//	Debug.Log(aaa2 + "||||||" + bbb2);
			//	target.renderer.material.color = col;
			//	target2.renderer.material.color = col;
		}
	}
	
	
//--------- functions for GUI to process --------------
	public void OutputTheColor () 
	{
		outputCol = theCol;
	}
	
	public void ActivateColPicker_NewRoom()
	{
		enabled = true;
        fromNewRoom = true;
	}

    public void ActivateColPicker_RoomsViewer(GameObject viewerRoomColorBtn)
    {
        enabled = true;
        fromRoomViewer = true;
        viewerRoomColorButton = viewerRoomColorBtn; // GameObject.Find("RoomViewerEntry_" + currSettingsScript.currRoomID);
    }
	
}
