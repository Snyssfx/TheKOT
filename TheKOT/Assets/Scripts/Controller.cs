using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller {

  public float Speed;
  public GameObject gameObject2;

  public int xDirection, yDirection;
  public Vector3 direction;

  public abstract void Control(GameObject gameObject);
  internal abstract void Move();

}
