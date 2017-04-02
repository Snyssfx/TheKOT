using UnityEngine;

namespace Assets.Scripts
{
	public abstract class Controller
	{
		public float Speed;
		public GameObject GameObject2;

		public int XDirection, YDirection;
		public Vector3 Direction;

		//Manage control of player
		public abstract void Control(GameObject gameObject);

		//Performing a step in the selected direction
		internal abstract void Move();
	}
}
