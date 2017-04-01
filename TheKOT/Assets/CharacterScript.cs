using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
	private Controller controller;
	public bool isAI;

	// Use this for initialization
	void Start ()
	{
		controller = isAI ? (Controller) new AiController() : new PlayerController();
	}
	
	// Update is called once per frame
	void Update ()
	{
		controller.Control(gameObject);
	}
}
