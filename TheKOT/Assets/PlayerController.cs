using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
	internal class PlayerController : Controller
	{
		private float Angle;
		private float Speed;

		private const float pi2 = 1.570796F;

		public PlayerController()
		{
			
		}

		public override void Control(GameObject gameObject)
		{
			if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
			{
				Angle = (float)(Math.PI / 4);
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
			{
				Angle = (float)(Math.PI / 4 * 3);
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
			{
				Angle = - (float)(Math.PI / 4 * 3);
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
			{
				Angle = - (float)(Math.PI / 4);
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.W))
			{
				Angle = pi2;
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.A))
			{
				Angle = pi2 * 2;
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				Angle = -pi2;
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				Angle = 0;
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
			}
			else
			{
				Speed = Speed > 0.0f ? Speed - 0.1f : 0.0f;
			}

			Move(gameObject);
		}

		internal override void Move(GameObject gameObject)
		{
			gameObject.transform.position += new Vector3((float) (Math.Cos(Angle)*Speed) * Time.deltaTime, (float) (Math.Sin(Angle)*Speed) * Time.deltaTime, 0.0f);
		}
	}
}
