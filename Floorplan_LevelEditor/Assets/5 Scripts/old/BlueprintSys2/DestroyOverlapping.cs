using UnityEngine;
using System.Collections;

public class DestroyOverlapping : MonoBehaviour 
{
	public int deactiveTimer = 3;
	
	void Update()
	{
		deactiveTimer--;
		
		if(deactiveTimer <= 0)
			Destroy(this);				//destroys THIS script instance from GameObject.
											//since we are checking for triggerCollision on instantiation, we dont care if collisions happen anytime afterwards, 
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "blueprint_Tile")
		{
			Destroy(gameObject);
		}
	}
	
}
