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
	void Start ()
	{
		switch ( type )
		{
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

	void OnTriggerStay2D(Collider2D coll)
	{
		if ( coll.gameObject.tag == "Enemy" && type == Type.Player)
		{
			Debug.Log("OnTriggerStay");
			var script = coll.gameObject.GetComponent<Character>().controller as EnemyController;
			if ( script != null )
			{
			script.Player = gameObject;
			script.isFollowPlayer = true;
			}
		}
		else if (type == Type.Player && coll.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E))
		{
			Vector3 pos = gameObject.transform.position;
			var colls = coll.gameObject.GetComponents<BoxCollider2D>();

			if (colls[0] == coll)
			{
				pos = coll.gameObject.transform.localToWorldMatrix*(new Vector3(0, -1.2f));
			}
			else
			{
				pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0, 1.2f));
			}

			gameObject.transform.position += pos;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy" && type == Type.Player)
		{
			if (Vector3.Distance(gameObject.transform.position, coll.gameObject.transform.position) < 3.0f)
			{
				GameOver(false);
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		controller.Control(gameObject);
	}

	public void GameOver(bool isWon)
	{
		if ( !isWon )
		{
			Time.timeScale = 0;
			Debug.Log("You are the loser!");
		}
		else
		{
			Debug.Log("You are the winner!");
		}
	}
}
