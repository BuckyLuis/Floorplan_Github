﻿using UnityEngine;
using System.Collections;
using TeamUtility.IO;

public class moveCamera : MonoBehaviour 
{
	public int scrollBoundary = 5;
	public int scrollSpeed = 10;

	public int minZoom = -5;
	public int maxZoom = 30;
	
	public bool cameraLock = false;
	
	private int scrollAmount = 0;
	private Vector3 camCenterPos;
	private Vector3 bps_placerDefZoom;
	private Vector3 bps_placer4Zoom;


	void Start ()
	{
		cameraLock = false;
		camCenterPos = new Vector3(0,5,0); 
		bps_placerDefZoom = new Vector3(0,5,0);
		bps_placer4Zoom = new Vector3(0,30,0);
	}
	void Update ()
	{	
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
			
			if(mousePosX < scrollBoundary)
			{
				transform.Translate(Vector3.right *- scrollSpeed * Time.deltaTime);
			}
			
			if(mousePosX >= Screen.width - scrollBoundary)
			{
				transform.Translate (Vector3.right * scrollSpeed * Time.deltaTime); 
			}
			
			
			if(mousePosY < scrollBoundary)
			{
				transform.Translate (Vector3.forward *- scrollSpeed * Time.deltaTime);
			}
			
			if(mousePosY >= Screen.height - scrollBoundary)
			{
				transform.Translate (Vector3.forward * scrollSpeed * Time.deltaTime);   
			}
			
            if (InputManager.GetAxis("Mouse ScrollWheel") < 0 && scrollAmount < maxZoom)
			{
				transform.Translate (Vector3.up * 50 * Time.deltaTime); 
				scrollAmount++;
				//if (Camera.main.fieldOfView<=100)
				//{
				//	Camera.main.fieldOfView +=2;
				//}
			}
            if (InputManager.GetAxis("Mouse ScrollWheel") > 0 && scrollAmount > minZoom)
			{
				transform.Translate (Vector3.up *- 50 * Time.deltaTime);
				scrollAmount--;
				//if (Camera.main.fieldOfView>6)
				//{
				//	Camera.main.fieldOfView -=2;
				//}
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
