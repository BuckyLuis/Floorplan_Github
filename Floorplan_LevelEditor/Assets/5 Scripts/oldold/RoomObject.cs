using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomObject : MonoBehaviour {
//============= Loaded Room Data =========
    public Room_Base ThisRoom { get; protected set; }
//========================================
 
    public int ThisRoomID { get; protected set; }
    public string ThisRoomName { get; protected set; }
    public Color ThisRoomColor { get; protected set; }

    public Vector3 ThisRoomOriginPos { get; protected set; }
    public List<Geom_Base> ThisRoomsTiles { get; protected set; }

//--------info worldUI components----
    public Transform uiRmID;
    public Transform uiRmName;
    public Transform uiRmPos;
    Text uiRmIDTxt;
    Text uiRmNameTxt;
    Text uiRmPosTxt;
//------------------------------------

    void Start() {
        uiRmID = transform.Find("worldCanvas_RoomObject/wPanel_RoomObjectInfo/Text_worldRoomID");
        uiRmName = transform.Find("worldCanvas_RoomObject/wPanel_RoomObjectInfo/Text_worldRoomName");
        uiRmPos = transform.Find("worldCanvas_RoomObject/wPanel_RoomObjectInfo/Text_worldRoomOriginPos");
        uiRmIDTxt = uiRmID.GetComponent<Text>();
        uiRmNameTxt = uiRmName.GetComponent<Text>();
        uiRmPosTxt = uiRmPos.GetComponent<Text>();
    }

    public void AlterRoomID() {

        //uiRmIDTxt.text = ;
    }

    public void AlterRoomName() {


        //uiRmNameTxt.text = ;
    }

    public void AlterRoomColor() {
        
    }

    public void AlterRoomOrigin(Vector3 originPos) {
        ThisRoomOriginPos = originPos;

      //  uiRmPosTxt.text = string.Format("( {0}x, {1}y, {2}z )", ThisRoomOriginPos.x, ThisRoomOriginPos.y, ThisRoomOriginPos.z);
    }

    public void AddTileToRoom() {
        
    }


    public void SaveRoomDataToXml() {

    }


}
