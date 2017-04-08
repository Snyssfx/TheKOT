using System.Collections;
using UnityEngine;

namespace Assets
{
	public class GameManager : MonoBehaviour {

		// Use this for initialization
		void Start() {
			//DontDestroyOnLoad(this);
			StartCoroutine(showComix());
			gameObject.transform.parent = gameObject.transform.parent.parent;
		}

		IEnumerator showComix() {
			GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = new Vector3(2000, 2000, 0);
			GameObject.FindGameObjectWithTag("Comix1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			while (!Input.GetKey(KeyCode.Z))
				yield return new WaitForEndOfFrame();
			GameObject.FindGameObjectWithTag("Comix1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
			GameObject.FindGameObjectWithTag("Comix2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			while (!Input.GetKey(KeyCode.X))
				yield return new WaitForEndOfFrame();
			GameObject.FindGameObjectWithTag("Comix2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
			GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = new Vector3(0, 0, -1);
		}

		// Update is called once per frame
		void Update() {
			gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0, 0, 1);
			//GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = new Quaternion(0, 0, 0, 0);
			if (Input.GetKey(KeyCode.R)) {
            
				Application.LoadLevel("FirstLevel 1");
				Time.timeScale = 1;
			}
		}
	}
}
