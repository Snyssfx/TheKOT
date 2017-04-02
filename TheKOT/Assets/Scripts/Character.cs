using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class Character : MonoBehaviour
	{
		//Type of character
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


		void OnTriggerEnter2D(Collider2D coll)
		{
			if (coll.gameObject.tag == "Enemy" && type == Type.Player) //Checking to losing in game
			{
				if (Vector3.Distance(gameObject.transform.position, coll.gameObject.transform.position) < 1.0f)
				{
					GameOver(false);
				}
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
					pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0.0f, -2.0f));
				else
					pos = coll.gameObject.transform.localToWorldMatrix * (new Vector3(0.0f, 2.0f));

				gameObject.transform.position += pos;
			}

			//ENEMY GIRL (if girl see the player then she run to him)
			if (coll.gameObject.tag == "Enemy" && type == Type.Player)
			{
				var script = coll.gameObject.GetComponent<Character>().controller as EnemyController;
				if (script != null)
				{
					script.Player = gameObject;
					script.isFollowPlayer = true;
				}
			}

		}

		// Update is called once per frame
		void Update ()
		{
			controller.Control(gameObject);
		}

		//See result of game
		public void GameOver(bool isWon)
		{
			if ( !isWon )
			{
				StartCoroutine(Fail());
			}
			else
			{
				Time.timeScale = 0;
				GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2000, 2000, 0);
				GameObject.FindGameObjectWithTag("GoodEnd").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			}
		}

		IEnumerator Fail() { 
			GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2000, 2000, 0);
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
			GameObject.FindGameObjectWithTag("BadEnd").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			GameObject.FindGameObjectWithTag("BadEnd").GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(2.0f);
			Time.timeScale = 0;
		}

	}
}
