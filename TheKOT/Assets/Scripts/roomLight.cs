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
    Debug.Log("Im here");
    OldPlayerIsHere = PlayerIsHere;
    if (PlayerIsHere)
      foreach ( var sr in gameObject.GetComponentsInChildren<SpriteRenderer>() ) {
        sr.color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
      }
    else
      foreach ( var sr in gameObject.GetComponentsInChildren<SpriteRenderer>() ) {
        sr.color = Color.white;
      }
  }
}
