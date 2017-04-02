using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerController : Controller
	{ 
		
		public override void Control(GameObject gameObject)
		{
			GameObject2 = gameObject;

			Speed = 3.0f;
			YDirection = XDirection = 0;
			if ( Input.GetKey(KeyCode.W) )
				YDirection++;
			if ( Input.GetKey(KeyCode.A) )
				XDirection--;
			if ( Input.GetKey(KeyCode.S) )
				YDirection--;
			if ( Input.GetKey(KeyCode.D) )
				XDirection++;

			Direction = new Vector3(XDirection, YDirection, 0);
			Direction.Normalize();
			Move();
		}

		internal override void Move()
		{
			if ( Direction.sqrMagnitude >= 0.001f )
			{
				GameObject2.transform.rotation = Quaternion.Euler(0, 0,
					Mathf.Sign(YDirection) * Vector3.Angle(Vector3.right, Direction) - 90);
				GameObject2.transform.position += Direction * Speed * Time.deltaTime;
				GameObject2.GetComponent<Animator>().SetBool("isWalk", true);
				//gameObject.GetComponent<Character>().audioSource.P
			}
			else
			{
				GameObject2.GetComponent<Animator>().SetBool("isWalk", false);
			}
		}
	}
}
