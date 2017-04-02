using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
	public int numOfFeathers = 0;

	// Use this for initialization
	void Start ()
	{  	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if ( coll.gameObject.tag == "Feather" )
		{
			GameObject.Destroy(coll.gameObject);
			numOfFeathers++;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if ( coll.gameObject.tag == "Friendly" )
		{
			if ( numOfFeathers > 0 )
			{
				Debug.Log("I'm killed by you!");
				GameObject.Destroy(coll.gameObject);
			numOfFeathers--;
			}
		}
	}
}
