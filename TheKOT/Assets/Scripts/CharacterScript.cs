using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
	private Controller controller;
	public bool isAI;
  //public Rigidbody2D rigidbody;

  void OnTriggerEnter2D(Collider2D coll)
  {
    if (!isAI && coll.gameObject.gameObject.tag == "Room" ) {
      coll.gameObject.GetComponent<roomLight>().PlayerIsHere = true;
    }
  }

  void OnTriggerExit2D(Collider2D coll)
  {
    
    if (!isAI && coll.gameObject.tag == "Room" ) {
      Debug.Log("Leave");
      coll.gameObject.GetComponent<roomLight>().PlayerIsHere = false;
    }
  }


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
