using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLight : MonoBehaviour {
  public bool PlayerIsHere = false;
  private bool OldPlayerIsHere = false;



	// Use this for initialization
	void Start ()
	{
		FindEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		checkPlayer();
	}

	private void FindEnemies()
	{
		foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
		{
			if (sr.gameObject.tag == "Enemy")
			{
				//sr.gameObject.
			}
		}
	}

	private void checkPlayer()
	{
		if (PlayerIsHere == OldPlayerIsHere)
			return;
		OldPlayerIsHere = PlayerIsHere;
		if (PlayerIsHere)
			foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
			{
				if (sr.gameObject.tag == "Floor")
				sr.color = new Color(0.35f, 0.35f, 0.35f, 1.0f);
			}
		else
		foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
		{
			if ( sr.gameObject.tag == "Floor" )
			sr.color = Color.white;
		}
	}
}
