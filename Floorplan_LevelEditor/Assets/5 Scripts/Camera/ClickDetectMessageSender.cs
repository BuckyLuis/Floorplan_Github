using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickDetectMessageSender : MonoBehaviour {

    public Camera detectionCamera;
    public bool debug = true;

    Ray ray;
    RaycastHit hit;
    Camera theCamera;


    void Start() {
        if(detectionCamera != null)
            theCamera = detectionCamera;
        else
            theCamera = Camera.main;
    }


    void Update() {
        if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) 
        {
            if (Input.GetMouseButtonDown(0)) {
                ray = theCamera.ScreenPointToRay(Input.mousePosition); 
                if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                    hit.transform.gameObject.SendMessage("Clicked", hit.point, SendMessageOptions.DontRequireReceiver);
                    if(debug)
                        Debug.Log("You clicked: " + hit.collider.gameObject.name, hit.collider.gameObject);
                }
            }

            if (Input.GetMouseButtonDown(1)) {
                ray = theCamera.ScreenPointToRay(Input.mousePosition); 
                if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                    hit.transform.gameObject.SendMessage("RightClicked", hit.point, SendMessageOptions.DontRequireReceiver);
                    if(debug)
                        Debug.Log("You clicked: " + hit.collider.gameObject.name, hit.collider.gameObject);
                }

            }

            if (Input.GetMouseButtonDown(2) && !EventSystem.current.IsPointerOverGameObject()) {
                ray = theCamera.ScreenPointToRay(Input.mousePosition); 
                if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                    hit.transform.gameObject.SendMessage("MiddleClicked", hit.point, SendMessageOptions.DontRequireReceiver);
                    if(debug)
                        Debug.Log("You clicked: " + hit.collider.gameObject.name, hit.collider.gameObject);
                }

            }
        }

    }
   
    
 
}
