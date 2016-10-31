using UnityEngine;
using System.Collections;
using TeamUtility.IO;

public class CameraMovement : MonoBehaviour 
{
	public int scrollBoundary = 5;
	public int scrollSpeed = 10;
    public int zoomSpeed = 100;

	public int minZoom = -5;
	public int maxZoom = 30;
	
    public static bool cameraLockForStartupMenu = true;
	public bool cameraLock = false;
	
    private int zoomAmount = 0;
	private Vector3 camCenterPos;
	private Vector3 bps_placerDefZoom;
	private Vector3 bps_placer4Zoom;

    private int minCamPos_X = -100;
    private int maxCamPos_X = 100;

    private int minCamPos_Z = -100;
    private int maxCamPos_Z = 100;


	void Start ()
	{
		cameraLock = false;
		camCenterPos = new Vector3(0,5,0); 
		//bps_placerDefZoom = new Vector3(0,5,0);
		//bps_placer4Zoom = new Vector3(0,30,0);
	}
	void Update ()
	{	
        if(cameraLockForStartupMenu == false) {
    		if(InputManager.GetButtonDown("CameraCenter"))
    		{
    			CenterCamera();
    		}
            if(InputManager.GetButtonDown("CameraLock"))
    		{
    			LockCamera();
    		}
    		
    		
    		if(cameraLock == false)
    		{
    			//Debug.Log (scrollAmount);
    			float mousePosX = Input.mousePosition.x;
    			float mousePosY = Input.mousePosition.y;
    			
                if(mousePosX < scrollBoundary && transform.position.x > minCamPos_X)
    			{
    				transform.Translate(Vector3.right *- scrollSpeed * Time.deltaTime);
    			}
    			
                if(mousePosX >= Screen.width - scrollBoundary && transform.position.x < maxCamPos_X)
    			{
    				transform.Translate (Vector3.right * scrollSpeed * Time.deltaTime); 
    			}
    			
    			
                if(mousePosY < scrollBoundary && transform.position.z > minCamPos_Z) //Y, 2D
    			{
                    transform.Translate (Vector3.forward *- scrollSpeed * Time.deltaTime);
    			}
    			
                if(mousePosY >= Screen.height - scrollBoundary && transform.position.z < maxCamPos_Z)
    			{
    				transform.Translate (Vector3.forward * scrollSpeed * Time.deltaTime);   
    			}
    			
                if (InputManager.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y < maxZoom)
    			{
                    transform.Translate (Vector3.up * zoomSpeed * Time.deltaTime); 
    				//zoomAmount++;

                    if(transform.position.y > maxZoom) {
                        transform.position = new Vector3 (transform.position.x, maxZoom, transform.position.z);
                    }
    				//if (Camera.main.fieldOfView<=100)
    				//{
    				//	Camera.main.fieldOfView +=2;
    				//}
    			}
                if (InputManager.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y  > minZoom)
    			{
                    transform.Translate (Vector3.up *- zoomSpeed * Time.deltaTime);
    				//zoomAmount--;

                    if(transform.position.y < minZoom) {
                        transform.position = new Vector3 (transform.position.x, minZoom, transform.position.z);
                    }
    				//if (Camera.main.fieldOfView>6)
    				//{
    				//	Camera.main.fieldOfView -=2;
    				//}
    			}
    		}
    	}
    }

	// funcs for UI to trigger	
	public void CenterCamera()
	{
		transform.position = camCenterPos;
	}
	
	public void LockCamera()
	{
		cameraLock = !cameraLock;
	}
	
	/*public void PlacerDefZoom()
	{
		transform.position = bps_placerDefZoom;
	}
			
	public void Placer4Zoom()
	{
		transform.position = bps_placer4Zoom;
	}
	*/
	
	
	
}
