using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour 
{
	public GameObject popupPanel;//panel that is the popup.
	public Text popupText; //text component of the popupPanel.

	public float popupFadeInTime,popupShowTime,popupFadeoutTime;

	float popupTimer = 0;

	void Start()
	{
		popupPanel.SetActive(false); // dont show any messages yet.
	}

	void Update()
	{
		if((Time.time - popupTimer) > popupFadeInTime+popupShowTime) //after 4 seconds since popup requested.
		{
			FadeOutPopup();
		}
	}

	public void ShowPopupMessage(string message)
	{
		popupTimer = Time.time; 
		popupPanel.SetActive(true);
		popupText.text = message;
		FadeInPopup();
	}

	void FadeOutPopup()
	{
		popupPanel.GetComponent<Image>().CrossFadeAlpha(0.0f,popupFadeoutTime,true);
		popupText.CrossFadeAlpha(0.0f,popupFadeoutTime,true);
		if((Time.time - popupTimer) > popupFadeInTime+popupShowTime+popupFadeoutTime) //after 7 seconds since popup requested.
		{
			popupPanel.SetActive(false);
		}
	}

	void FadeInPopup()
	{
		popupPanel.GetComponent<Image>().CrossFadeAlpha(1.0f,popupFadeInTime,true);
		popupText.CrossFadeAlpha(1.0f,popupFadeInTime,true);
	}

}
