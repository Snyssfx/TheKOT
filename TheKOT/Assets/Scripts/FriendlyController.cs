using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyController : Controller
{
  private float delay;
  public float threshold = 0.4f;
  private GameObject gameObject2;

  public override void Control(GameObject gameObject)
  {
		gameObject2 = gameObject;
		if ( delay < 0 )
		{
			if ( Random.Range(0.0f, 1.0f) < threshold ) {
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
				direction = new Vector3(0, 0);
				gameObject2.GetComponent<AudioSource>().Stop();
				//gameObject2.GetComponent<Animator>().SetBool("isWalk", false);
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
		if ( direction.sqrMagnitude >= 0.01f )
		{
			gameObject2.transform.rotation = Quaternion.Euler(0, 0, 
				Mathf.Sign(yDirection) * Vector3.Angle(Vector3.right, direction) - 90);
			gameObject2.transform.position += direction * Speed * Time.deltaTime;
			gameObject2.GetComponent<Animator>().SetBool("isWalk", true);
		}
		else
		{
			gameObject2.GetComponent<Animator>().SetBool("isWalk", false);
			//Debug.Log("I stay");
		}
  }
}
