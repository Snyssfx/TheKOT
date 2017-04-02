﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEveryFrame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		var q = gameObject.transform.rotation;
		q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0.0f);
		gameObject.transform.rotation = q;
	}
}
