using System.Collections;
using System.Collections.Generic;
using Assets;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
	private Controller controller;
	public bool isAI;
	public bool isEnemy;
  //public Rigidbody2D rigidbody;

  void OnTriggerEnter2D(Collider2D coll)
  {
    if (!isAI && coll.gameObject.gameObject.tag == "Room" ) {
      coll.gameObject.GetComponent<roomLight>().PlayerIsHere = true;
    }
  }

  void OnTriggerStay2D(Collider2D coll) {
    
    if ( !isAI && coll.gameObject.tag == "Door" && (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F))) {
      Debug.Log("Stay");
      Vector3 pos = gameObject.transform.position;
      var colls = coll.gameObject.GetComponents<BoxCollider2D>();

      if ( colls[0] == coll )
        pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0, -1.2f));
      else
        pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0, 1.2f));

      gameObject.transform.position += pos;
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
		controller = isAI ? 
			isEnemy ? (Controller) new AiEnemyController() : new AiFriendlyController() 
			: new PlayerController();
	}
	
	// Update is called once per frame
	void Update ()
	{
		controller.Control(gameObject);
	}
}
