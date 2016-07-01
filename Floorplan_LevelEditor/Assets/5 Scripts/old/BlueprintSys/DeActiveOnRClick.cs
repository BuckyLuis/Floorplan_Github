using UnityEngine;
using System.Collections;

public class DeActiveOnRClick : MonoBehaviour 
{
	void RightClicked()
	{
		gameObject.SetActive(false);
	}
}

