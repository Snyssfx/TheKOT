using UnityEngine;

namespace Assets.Scripts
{
	public class FriendlyController : Controller
	{
		private float delay;
		public float Threshold = 0.4f;
		private GameObject gameObject2;

		public override void Control(GameObject gameObject)
		{
			gameObject2 = gameObject;
			if ( delay < 0 )
			{
				if ( Random.Range(0.0f, 1.0f) < Threshold ) {
					Speed = 1.0f;
					XDirection = Random.Range(-1, 2);
					YDirection = Random.Range(-1, 2);
					Direction = new Vector3(XDirection, YDirection);
					Direction.Normalize();
					gameObject2.GetComponent<AudioSource>().Play();

					delay = Random.Range(1.0f, 3.0f);
					Move();
				}
				else
				{
					Speed = 0;
					delay = Random.Range(1.0f, 3.0f);
					Direction = new Vector3(0, 0);
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
			if ( Direction.sqrMagnitude >= 0.01f )
			{
				if (gameObject2.GetComponent<Animator>().GetBool("isLaugth"))
					return;
				gameObject2.transform.rotation = Quaternion.Euler(0, 0, 
					Mathf.Sign(YDirection) * Vector3.Angle(Vector3.right, Direction) - 90);
				gameObject2.transform.position += Direction * Speed * Time.deltaTime;
				gameObject2.GetComponent<Animator>().SetBool("isWalk", true);
			}
			else
			{
				gameObject2.GetComponent<Animator>().SetBool("isWalk", false);
				//Debug.Log("I stay");
			}
		}
	}
}
