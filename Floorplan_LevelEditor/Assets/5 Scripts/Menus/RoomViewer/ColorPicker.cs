using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour 
{
    [SerializeField] GameObject databaseController;
    RoomViewerMenu theRoomViewerMenu;
    RoomViewerEntry roomViewerEntryScriptTemp;

    public Button viewerRoomColorButton;

    public GameObject parentPanel;
	//-------------- color pick -------------------------------------------------
	public Texture2D colorPicker;  
	/*      /!\ Don't forget to make the texture readable
            (Select your texture : in Inspector
            [Texture Import Setting] > Texture Type > Advanced > Read/Write enabled > True  then Apply)     */
	public Color theCol;  
	public static Color outputCol;
	
    RectTransform uiRectTransform;
    Rect colorPanelRect;     
	public GUIStyle guiStyle;
	
	//-----------------------------------------------------------------
    void Start() {
        //databaseController = GameObject.Find("- == Database Controller == -");
        theRoomViewerMenu = databaseController.GetComponent<RoomViewerMenu>();

        uiRectTransform = gameObject.GetComponent<RectTransform>();                           //align old GUI object to 4.6 UI object
        colorPanelRect = RectTransformToScreenSpace(uiRectTransform);
        Debug.Log(colorPanelRect);
    }

    public static Rect RectTransformToScreenSpace( RectTransform transform ) {
        Vector2 size = Vector2.Scale( transform.rect.size, transform.lossyScale );
        return new Rect( transform.position.x, Screen.height - transform.position.y, size.x, size.y );
    }                                                                                        //align old GUI object to 4.6 UI object
                        

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


            if(viewerRoomColorButton != null) {
                viewerRoomColorButton.image.color = outputCol;
                roomViewerEntryScriptTemp.ChangeRoomColor(outputCol);
            }
            else {
                Debug.LogError("ColorPicker -- RoomViewer Entry not found!!");
            }
			enabled = false;
            parentPanel.SetActive(false);
			
			
			//	Debug.Log(aaa2 + "||||||" + bbb2);
			//	target.renderer.material.color = col;
			//	target2.renderer.material.color = col;
		}
	}
	
	
//--------- functions for GUI to process --------------
    public void ActivateColPicker(Button theButton)
    {
        roomViewerEntryScriptTemp = theRoomViewerMenu.roomEntries[theRoomViewerMenu.activeRoomIndex].GetComponent<RoomViewerEntry>();
        //roomViewerEntryScriptTemp.userIsEditingEntry = true;
        theRoomViewerMenu.DeactivateToggles();
        enabled = true;
        viewerRoomColorButton = theButton; // theRoomViewerMenu.roomEntries[theRoomViewerMenu.activeRoomIndex].transform.Find("Button_RVEColor").gameObject.GetComponent<Button>();
    }

    /*  public void OutputTheColor () 
    {
        outputCol = theCol;
    }
    */
	
}
