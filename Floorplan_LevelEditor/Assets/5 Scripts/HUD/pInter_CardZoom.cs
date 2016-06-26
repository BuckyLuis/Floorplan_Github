using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TeamUtility.IO;

public class pInter_CardZoom : MonoBehaviour 
{
	public GameObject HudCard;
	public GameObject cardPropsPanel;

	bool isInterOverCard = false;
	Texture cardTexture;
	RawImage zoomImg;


	void Start()
	{
		zoomImg = HudCard.GetComponent<RawImage>();
	}


	void Update ()
	{
		if(InputManager.GetButton("Action") )
		{
			RaycastHit hit;
			if( Physics.Raycast(transform.position, transform.forward,out hit, 5))
			{
				if(hit.collider.gameObject.tag == "PlayerCard")
				{
					Debug.Log("boom");
					cardTexture = hit.transform.GetComponent<Renderer>().material.mainTexture;
					zoomImg.texture = cardTexture;
					zoomImg.enabled = true;
					cardPropsPanel.SetActive(true);
				}
			}
		}
		if(InputManager.GetButtonUp("Action") )
		{
			zoomImg.enabled = false;
			cardPropsPanel.SetActive(false);
		}
	}

/*
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PlayerCard")
		{
			Debug.Log("boom");
			cardTexture = other.gameObject.GetComponent<Renderer>().material.mainTexture;
			isInterOverCard = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "PlayerCard")
		{
			Debug.Log("boom");
			cardTexture = other.gameObject.GetComponent<Renderer>().material.mainTexture;
			isInterOverCard = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "PlayerCard")
		{
			isInterOverCard = false;
		}
	}
*/
}
