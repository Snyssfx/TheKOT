using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public bool isLight = false;

	// Use this for initialization
	void Start ()
	{
        darkRoom();
	}

  // Update is called once per frame
  void Update()
  {
    checkPlayer();
  }

    public void checkPlayer()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        bool playerInRoom = isInRoom(player);
        if (playerInRoom && !isLight)
            lightRoom();
        else if (!playerInRoom && isLight)
            darkRoom();
    }

    void lightRoom()
    {
        foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (sr.gameObject.tag == "Floor")
                sr.color = Color.white;
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Friendly"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Interier"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }

        isLight = true;
    }

    void darkRoom()
    {
        foreach (var sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (sr.gameObject.tag == "Floor")
                sr.color = new Color(0.35f, 0.35f, 0.35f, 1.0f);
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Friendly"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Interier"))
        {
            if (isInRoom(enemy))
            {
                enemy.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0.35f, 0.35f, 1);
            }
        }

        isLight = false;
    }


  bool isInRoom(GameObject go)
  {
    var bc = gameObject.GetComponent<BoxCollider2D>();
    return bc.OverlapPoint(go.transform.position);
  }
}
