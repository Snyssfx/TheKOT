using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Inventar : MonoBehaviour
{
	public bool IsWinner = false;
	public int NumOfFeathers = 0;

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
		if ( coll.gameObject.tag == "Feather" ) //Triger for picking feather
		{
			GameObject.Destroy(coll.gameObject);
			NumOfFeathers++;	
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if ( coll.gameObject.tag == "Friendly") //If count of feathers not zero then make action with NPC
		{
			if ( NumOfFeathers > 0 )
			{
				Debug.Log("I'm killed by you!");
				//GameObject.Destroy(coll.gameObject);
				coll.gameObject.GetComponent<Animator>().SetBool("isLaugth", true);
				gameObject.GetComponent<Animator>().SetBool("isCloud", true);

				StartCoroutine(StopAnim());
				IsWinner = true;
				NumOfFeathers--;
			}
		}	
		if (coll.gameObject.tag == "Exit" && IsWinner) //Checking to achieve all conditions for victory
		{
			gameObject.GetComponent<Character>().GameOver(true);
		}
	}

	IEnumerator StopAnim()
	{
		yield return new WaitForSeconds(1.0f);
		gameObject.GetComponent<Animator>().SetBool("isCloud", false);
		yield return null;
	}
}
