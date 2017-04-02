using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

  public enum Type {
    Enemy,
    Player,
    Friendly
  }

  public Type type;

  private SpriteRenderer renderer;
  private Rigidbody2D rb;

  [HideInInspector]
  public AudioSource audioSource;
  private Controller controller;

	// Use this for initialization
	void Start () {
    switch ( type ) {
      case Type.Player:
        controller = new PlayerController();
        break;
      case Type.Enemy:
        controller = new EnemyController();
        break;
      case Type.Friendly:
        controller = new FriendlyController();
        break;
    }
    renderer = gameObject.GetComponent<SpriteRenderer>();
    rb = gameObject.GetComponent<Rigidbody2D>();
    audioSource = gameObject.GetComponent<AudioSource>();
	}

  void OnTriggerEnter2D(Collider2D coll)
  {
    if ( type == Type.Player && coll.gameObject.gameObject.tag == "Room" ) {
      coll.gameObject.GetComponent<RoomLight>().PlayerIsHere = true;
    }
  }

  void OnTriggerStay2D(Collider2D coll)
  {
    //DOOR
    bool keyPressed = Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F);
    if ( type == Type.Player && coll.gameObject.tag == "Door" &&  keyPressed) {
      Vector3 pos = gameObject.transform.position;
      var colls = coll.gameObject.GetComponents<BoxCollider2D>();

      if ( colls[0] == coll )
        pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0, -1.2f));
      else
        pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0, 1.2f));

      gameObject.transform.position += pos;
    }

    //ENEMY GIRL
    if ( coll.gameObject.tag == "Enemy" && type == Type.Player ) {
      var script = coll.gameObject.GetComponent<Character>().controller as EnemyController;
      if ( script != null ) {
        script.Player = gameObject;
        script.isFollowPlayer = true;
      }
    }

  }

  void OnTriggerExit2D(Collider2D coll)
  {

    if ( type == Type.Player && coll.gameObject.tag == "Room" ) {
      Debug.Log("Leave");
      coll.gameObject.GetComponent<RoomLight>().PlayerIsHere = false;
    }
  }

	// Update is called once per frame
	void Update () {
    controller.Control(gameObject);
	}

  public void GameOver(bool isWon) {
    if ( !isWon ) {
      Debug.Log("You are the loser!");
    } else {
      Debug.Log("You are the winner!");
    }
  }

}
