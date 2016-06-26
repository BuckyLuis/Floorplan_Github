using UnityEngine;
using System.Collections;
using TeamUtility.IO;

public class MouseLook : MonoBehaviour 
{
	public static float lookSensitivity = 5.0f;
	public static bool invertRotX = false;

	float rotX;
	float rotY;

	float rotXcur;
	public float rotYcur;

	float rotXv;
	float rotYv;
	float damp = 0.1f;

	void Start () 
	{

	}
	

	void Update () 
	{
		if(invertRotX)
			rotX += (InputManager.GetAxis("LookVertical") * lookSensitivity);
		else
			rotX -= (InputManager.GetAxis("LookVertical") * lookSensitivity);


		rotY += (InputManager.GetAxis("LookHorizontal") * lookSensitivity);

		rotX = Mathf.Clamp(rotX, -90, 90);
		rotXcur = Mathf.SmoothDamp(rotXcur, rotX, ref rotXv, damp);
		rotYcur = Mathf.SmoothDamp(rotYcur, rotY, ref rotYv, damp);

		transform.rotation = Quaternion.Euler(rotXcur, rotYcur, 0);

	}
}
