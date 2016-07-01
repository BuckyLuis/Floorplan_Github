using UnityEngine;
using System.Collections;

public class DestroyWithEraser : MonoBehaviour 
{
	public int destroyTimer = 30;
	
	void Update()
	{
		destroyTimer--;
		
		if(destroyTimer <= 0)
			Destroy(gameObject);				//destroys the eraser plane object
			Destroy(transform.parent.gameObject);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "blueprint_Tile")
		{
			Destroy(other.gameObject);
		}
	}
	
}
