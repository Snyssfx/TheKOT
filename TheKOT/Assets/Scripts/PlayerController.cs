using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{ 
	
	public override void Control(GameObject gameObject) {
    gameObject2 = gameObject;

    Speed = 2.0f;
    yDirection = xDirection = 0;
    if ( Input.GetKey(KeyCode.W) )
      yDirection++;
    if ( Input.GetKey(KeyCode.A) )
      xDirection--;
    if ( Input.GetKey(KeyCode.S) )
      yDirection--;
    if ( Input.GetKey(KeyCode.D) )
      xDirection++;

    direction = new Vector3(xDirection, yDirection, 0);
    direction.Normalize();
    Move();
  }

	internal override void Move()
	{
		if ( direction.sqrMagnitude >= 0.001f )
		{
			gameObject2.transform.rotation = Quaternion.Euler(0, 0,
				Mathf.Sign(yDirection) * Vector3.Angle(Vector3.right, direction) - 90);
			gameObject2.transform.position += direction * Speed * Time.deltaTime;
			gameObject2.GetComponent<Animator>().SetBool("isWalk", true);
			//gameObject.GetComponent<Character>().audioSource.P
		}
		else
		{
			gameObject2.GetComponent<Animator>().SetBool("isWalk", false);
		}
	}
}
