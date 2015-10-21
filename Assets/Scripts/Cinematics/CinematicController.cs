using UnityEngine;
using System.Collections;

public class CinematicController : MonoBehaviour 
{
	public Camera[] allCams;
	Animator anim;

	void Start()
	{
		//get all cameras in scene and put them in an Array called allCams.
		allCams = new Camera[Camera.allCamerasCount];
		Camera.GetAllCameras(allCams);

		DisableAllButMainCam();

		anim = GameObject.FindGameObjectWithTag("CinematicCamera").GetComponent<Animator>();

	}

	public void DisableAllButMainCam()
	{
		foreach(Camera c in allCams)
		{
			if(c.tag != "MainCamera")
			{
				c.enabled = false;
			}
			else
			{
				c.enabled = true;
			}
		}
	}

	void ActivateCinematicCam()
	{
		foreach(Camera c in allCams)
		{
			if(c.tag != "CinematicCamera")
			{
				c.enabled = false;
			}
			else
			{
				c.enabled = true;
			}
		}
	}


	public void PlayCinematic(string s)
	{
		ActivateCinematicCam();
		if(s.Equals(Cinematic.tutorial.showPier))
		{
			anim.SetTrigger("PlayPier");
		}
		else if(s.Equals(Cinematic.tutorial.showDirectionSign))
		{
			anim.SetTrigger("PlaySign");
		}
	}

}
