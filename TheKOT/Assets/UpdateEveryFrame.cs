using System;
using UnityEngine;

namespace Assets
{
	public class UpdateEveryFrame : MonoBehaviour
	{
		private bool isEndOfGame;

		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
			var q = gameObject.transform.rotation;
			q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0.0f);
			gameObject.transform.rotation = q;

			if (Math.Abs(Time.timeScale) < 1)  //If end of game then stop all AudioSources
			{
				var allAudioSource = GameObject.FindObjectsOfType<AudioSource>();

				foreach (var audioSource in allAudioSource)
				{
					audioSource.Stop();
				}
			}
		}
	}
}
