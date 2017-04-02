using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
	private float delay;
	public float threshold = 0.4f;
	private GameObject gameObject2;
	public bool isFollowPlayer = false;
	public GameObject Player;

	public override void Control(GameObject gameObject)
	{
		gameObject2 = gameObject;
		if ( delay < 0 )
		{
			if ( Random.Range(0.0f, 1.0f) < threshold )
			{
				Speed = 1.0f;
				xDirection = Random.Range(-1, 2);
				yDirection = Random.Range(-1, 2);
				direction = new Vector3(xDirection, yDirection);
				direction.Normalize();

				gameObject2.GetComponent<AudioSource>().Play();

				delay = Random.Range(1.0f, 3.0f);
				Move();
			}
			else
			{
				Speed = 0;
				delay = Random.Range(1.0f, 3.0f);

				gameObject2.GetComponent<AudioSource>().Stop();
			}
		}
		else
		{
			delay -= Time.deltaTime;
			Move();
		}
	}

	internal override void Move()
	{
		if ( isFollowPlayer )
		{
			var ourTrans = gameObject2.transform;
			var plTrans = Player.transform;
			gameObject2.transform.position += (plTrans.position - ourTrans.position).normalized * Speed * Time.deltaTime;
			if ( (ourTrans.position - plTrans.position).magnitude < 0.001f )
			gameObject2.GetComponent<Character>().GameOver(false);
		}
    
		if ( direction.sqrMagnitude >= 0.001f )
		{
			gameObject2.transform.rotation = Quaternion.Euler(0, 0,
			Mathf.Sign(yDirection) * Vector3.Angle(Vector3.right, direction) - 90);
			gameObject2.transform.position += direction * Speed * Time.deltaTime;
			//gameObject.GetComponent<Character>().audioSource.P
		}
	}
}
