using UnityEngine;

//Script for each room on scene
namespace Assets.Scripts
{
	public class RoomLight : MonoBehaviour
	{
		public bool IsLight = false;  //Shows whether the room is currently lit

		// Use this for initialization
		void Start ()
		{
			DarkRoom();
		}

		// Update is called once per frame
		void Update()
		{
			CheckPlayer();  
		}

		//Checking the player in the room and change light on room if it nessesery
		public void CheckPlayer()
		{
			var player = GameObject.FindGameObjectWithTag("Player");
			bool playerInRoom = IsInRoom(player);
			if (playerInRoom && !IsLight)
				LightRoom();
			else if (!playerInRoom && IsLight)
				DarkRoom();
		}

		//Illuminates a room
		private void LightRoom() 
		{
			foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
			{
				if (sr.gameObject.tag == "Floor")
					sr.color = Color.white;
			}
			foreach (var enemy in GameObject.FindGameObjectsWithTag("Friendly"))
			{
				if (IsInRoom(enemy))
				{
					enemy.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				}
			}
			foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				if (IsInRoom(enemy))
				{
					enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
				}
			}
			IsLight = true;
		}

		//Extinguish the light on room
		private void DarkRoom()
		{
			foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
			{
				if (sr.gameObject.tag == "Floor")
					sr.color = new Color(0.35f, 0.35f, 0.35f, 1.0f);
			}
			foreach (var enemy in GameObject.FindGameObjectsWithTag("Friendly"))
			{
				if (IsInRoom(enemy))
				{
					enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
				}
			}
			foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				if (IsInRoom(enemy))
				{
					enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
				}
			}
			IsLight = false;
		}

		//Checking somebody in the room
		private bool IsInRoom(GameObject obj)
		{
			var bc = gameObject.GetComponent<BoxCollider2D>();
			return bc.OverlapPoint(obj.transform.position);
		}
	}
}
