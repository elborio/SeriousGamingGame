﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject target;
	public float followDistance;
	public float followHeight;
	public float speed;

	void FixedUpdate()
	{

		Vector3 targetPosition = target.transform.position + (target.transform.forward * -followDistance)+(target.transform.up * followHeight) ;
		targetPosition = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*speed);
		transform.position = targetPosition;
		transform.LookAt(target.transform.position);
	}
}
