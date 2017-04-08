using UnityEngine;

namespace Assets.Scripts._2D_Version
{
	public abstract class Controller
	{
		public float Speed;
		public GameObject gameObject2;

		public int xDirection, yDirection;
		public Vector3 direction;

		public abstract void Control(GameObject gameObject, float moveThreshold);
		internal abstract void Move();
	}
}
