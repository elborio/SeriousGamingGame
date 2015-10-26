using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public int tutorialStep;
	int maxSteps;
	
	public GameObject tutorialPanel;

	
	public CinematicController cinematicControl;
	TutorialDialog tutorialDialog;

	void Start()
	{
		tutorialStep = 0;
		maxSteps = 2;
		tutorialDialog = tutorialPanel.GetComponent<TutorialDialog>();
		tutorialDialog.previousBut.gameObject.SetActive(false);
		PlayTutorial(0);
	}
	
	public void StartDialog()
	{
		tutorialPanel.SetActive(true);
	
//		tutorialDialog.previousBut.onClick.RemoveAllListeners();
//		tutorialDialog.previousBut.onClick.AddListener(DecreaseTutorialStep);
//		
//		tutorialDialog.nextBut.onClick.RemoveAllListeners();
//		tutorialDialog.nextBut.onClick.AddListener(IncreaseTutorialStep);
//		
//		tutorialDialog.cancelBut.onClick.RemoveAllListeners();
//		tutorialDialog.cancelBut.onClick.AddListener(Close);
	}
	
	public void PlayTutorial(int step)
	{
		switch(step)
		{
		case 0:
			//do step 0
			tutorialDialog.title.text = "Lopen";
			tutorialDialog.message.text = "Gebruik AWSD om je te bewegen en de muis om rond te kijken.";
			cinematicControl.DisableAllButMainCam();
				break;
		case 1:
			//dostep1
			Close();
			tutorialDialog.title.text = "Reizen";
			tutorialDialog.message.text = 	"In het spel is je doel om alle uitdagingen te halen. " +
				"Om bij deze uitdagingen te komen moet je naar de verschillende eilanden reizen. Dit Doe je bij de stijger.";
			cinematicControl.PlayCinematic(Cinematic.tutorial.showPier);
			StartCoroutine(ShowDialog(3.0f));
			break;
		}
//		if(step == maxSteps-1)
//		{
//			tutorialDialog.cancelBut.GetComponent<Text>().text = "Klaar";
//		}
	}
	
	IEnumerator ShowDialog(float t)
	{

		yield return new WaitForSeconds(t);
		tutorialPanel.SetActive(true);
	}
	
	public void Close()
	{
		Debug.Log("DidThis");
		tutorialPanel.SetActive(false);
		cinematicControl.DisableAllButMainCam();
	}
	
	public void DecreaseTutorialStep()
	{
		if(tutorialStep >0)
		{
			tutorialStep--;
			PlayTutorial(tutorialStep);
			tutorialDialog.nextBut.gameObject.SetActive(true);
			if(tutorialStep == 0)
			{
				tutorialDialog.previousBut.gameObject.SetActive(false);
			}
		}
	}
	
	public void IncreaseTutorialStep()
	{
		if(tutorialStep < maxSteps-1)
		{
			tutorialStep++;
			PlayTutorial(tutorialStep);
			tutorialDialog.previousBut.gameObject.SetActive(true);
			if(tutorialStep == maxSteps-1)
			{
				tutorialDialog.nextBut.gameObject.SetActive(false);
			}
		}
	}
}
