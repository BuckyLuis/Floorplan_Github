using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardDataToGfx : MonoBehaviour 
{
	private CardData CardDataScript;
	private int CardID;

	public GameObject Card_GO;
	public GameObject Title_GO;
	public GameObject Portrait_GO;

	public GameObject Stat0_GO;
	public GameObject Stat0v_GO;
	public GameObject Stat1_GO;
	public GameObject Stat1v_GO;
	public GameObject Stat2_GO;
	public GameObject Stat2v_GO;

	public GameObject Cost00_GO;
	public GameObject Cost01_GO;
	public GameObject Cost02_GO;
	public GameObject Cost03_GO;
	public GameObject Act0Text_GO;

	public GameObject Cost10_GO;
	public GameObject Cost11_GO;
	public GameObject Cost12_GO;
	public GameObject Cost13_GO;
	public GameObject Act1Text_GO;

	public GameObject Cost20_GO;
	public GameObject Cost21_GO;
	public GameObject Cost22_GO;
	public GameObject Cost23_GO;
	public GameObject Act2Text_GO;

	public GameObject FlavorText_GO;

//--------------------------------------------------------

	private RawImage Card_RawImage;
	private Text Title_Text;
	private Image Portrait_Image;

	private Image Stat0_Image;
	private Text Stat0_Text;
	private Image Stat1_Image;
	private Text Stat1_Text;
	private Image Stat2_Image;
	private Text Stat2_Text;

	private Image Cost00_Image;
	private Image Cost01_Image;
	private Image Cost02_Image;
	private Image Cost03_Image;
	private Text Act0_Text;

	private Image Cost10_Image;
	private Image Cost11_Image;
	private Image Cost12_Image;
	private Image Cost13_Image;
	private Text Act1_Text;

	private Image Cost20_Image;
	private Image Cost21_Image;
	private Image Cost22_Image;
	private Image Cost23_Image;
	private Text Act2_Text;

	private Text Flavortext_Text;



	void Start ()
	{
		CardDataScript = GetComponent<CardData>();
		CardID = CardDataScript.Card_ID;

		CacheCardUIComponents();
		AssignDataToGfx();
	}


	void CacheCardUIComponents()
	{
		Card_RawImage = Card_GO.GetComponent<RawImage>();
		Title_Text = Title_GO.GetComponent<Text>();
		Portrait_Image = Portrait_GO.GetComponent<Image>();

		Stat0_Image = Stat0_GO.GetComponent<Image>();
		Stat0_Text = Stat0v_GO.GetComponent<Text>();
		Stat1_Image = Stat1_GO.GetComponent<Image>();
		Stat1_Text = Stat1v_GO.GetComponent<Text>();
		Stat2_Image = Stat2_GO.GetComponent<Image>();
		Stat2_Text = Stat2v_GO.GetComponent<Text>();

		Cost00_Image = Cost00_GO.GetComponent<Image>();
		Cost01_Image = Cost01_GO.GetComponent<Image>();
		Cost02_Image = Cost02_GO.GetComponent<Image>();
		Cost03_Image = Cost03_GO.GetComponent<Image>();
		Act0_Text = Act0Text_GO.GetComponent<Text>();

		Cost10_Image = Cost10_GO.GetComponent<Image>();
		Cost11_Image = Cost11_GO.GetComponent<Image>();
		Cost12_Image = Cost12_GO.GetComponent<Image>();
		Cost13_Image = Cost13_GO.GetComponent<Image>();
		Act1_Text = Act1Text_GO.GetComponent<Text>();

		Cost20_Image = Cost20_GO.GetComponent<Image>();
		Cost21_Image = Cost21_GO.GetComponent<Image>();
		Cost22_Image = Cost22_GO.GetComponent<Image>();
		Cost23_Image = Cost23_GO.GetComponent<Image>();
		Act2_Text = Act2Text_GO.GetComponent<Text>();

		FlavorText_GO.GetComponent<Image>();
	}


	void AssignGraphics()
	{
		switch (CardDataScript.Element) 
		{
		case "Z":
			break;
		case "F":
			break;
		case "A":
			break;
		case "W":
			break;
		case "E":
			break;
		case "S":
			break;
		case "N":
			break;
		default:
			break;
		}

	


	}


	void AssignDataToGfx()
	{
		/*	
		Card_RawImage.texture = 
		Title_Text.text = CardDataScript.Title;
		Portrait_Image.sprite = 

		Stat0_Image.sprite = 
		Stat0_Text.text = CardDataScript.StatValue0.ToString();
		Stat1_Image.sprite = 
		Stat1_Text.text = CardDataScript.StatValue1.ToString();
		Stat2_Image.sprite = 
		Stat2_Text.text = CardDataScript.StatValue2.ToString();

		Cost00_Image.sprite = 
		Cost01_Image.sprite = 
		Cost02_Image.sprite = 
	Cost03_Image.sprite = 
		Act0_Text.text = CardDataScript.ActText0;

		Cost10_Image.sprite = 
		Cost11_Image.sprite = 
		Cost12_Image.sprite = 
		Cost13_Image.sprite = 
		Act1_Text.text = CardDataScript.ActText1;

		Cost20_Image.sprite = 
		Cost21_Image.sprite = 
		Cost22_Image.sprite = 
		Cost23_Image.sprite = 
		Act2_Text.text = CardDataScript.ActText2;

		Flavortext_Text.text = CardDataScript.FlavorText;
		*/

	}


}
