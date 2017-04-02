using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLight : MonoBehaviour {
  public bool PlayerIsHere = false;
  private bool OldPlayerIsHere = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    checkPlayer();
	}

  public void checkPlayer() {
    if ( PlayerIsHere == OldPlayerIsHere )
      return;
    OldPlayerIsHere = PlayerIsHere;
    var enemies = GameObject.FindGameObjectsWithTag("FriendlyEnemy");
    if ( !PlayerIsHere ) {
      Debug.Log("!PlayerIsHere");
      foreach ( var sr in gameObject.GetComponentsInChildren<SpriteRenderer>() ) {
        if ( sr.gameObject.tag == "Floor" )
          sr.color = new Color(0.35f, 0.35f, 0.35f, 1.0f);
      }
      foreach ( var enemy in enemies ) {
        if ( isInRoom(enemy) ) {
          enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
      }

    } else {
      foreach ( var sr in gameObject.GetComponentsInChildren<SpriteRenderer>() ) {
        if ( sr.gameObject.tag == "Floor" )
          sr.color = Color.white;
      }
      foreach ( var enemy in enemies ) {
        if ( isInRoom(enemy) ) {
          enemy.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
      }
    }
  }

  bool isInRoom(GameObject enemy) {
    var bc = gameObject.GetComponent<BoxCollider2D>();
    return bc.OverlapPoint(enemy.transform.position);
  }
}
