using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

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

  void OnTriggerStay2D(Collider2D coll) {
    if ( coll.gameObject.tag == "Enemy" && type == Type.Player) {
      Debug.Log("OnTriggerStay");
      var script = coll.gameObject.GetComponent<Character>().controller as EnemyController;
      if ( script != null ) {
        script.Player = gameObject;
        script.isFollowPlayer = true;
      }
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
