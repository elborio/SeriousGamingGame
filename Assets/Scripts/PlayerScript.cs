using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float walkVelocity = 5;

	CharacterController characterControl;
	Animator anim;

	void Start()
	{
		characterControl = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		float verticalMove = Input.GetAxis("Vertical");
		if(verticalMove != 0)
		{
			MovePlayer(verticalMove);
		}
		else
		{
			anim.SetBool ("isWalking",false);
		}
	}

	void MovePlayer(float vertiVelo)
	{
		vertiVelo = vertiVelo * walkVelocity;
		characterControl.SimpleMove(new Vector3(0,0,vertiVelo));
		anim.SetBool ("isWalking",true);
	}


}
