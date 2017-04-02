using UnityEngine;

namespace Assets.Scripts
{
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
					Speed = 2.5f;
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
				//if ( (ourTrans.position - plTrans.position).magnitude < 0.001f )
				//gameObject2.GetComponent<Character>().GameOver(false);
			}
    
			if ( Direction.sqrMagnitude >= 0.001f )
			{
				gameObject2.transform.rotation = Quaternion.Euler(0, 0,
					Mathf.Sign(YDirection) * Vector3.Angle(Vector3.right, Direction) - 90);
				gameObject2.transform.position += Direction * Speed * Time.deltaTime;
				//gameObject.GetComponent<Character>().audioSource.P
			}
		}
	}
}
