using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets
{
	internal class AiController : Controller
	{
		private float Angle;
		private float Speed;

		private const double chanceToMove = 0.6;
		Random rnd = new Random();

		public override void Control(GameObject gameObject)
		{
			double chance = rnd.NextDouble();

			if (chance < chanceToMove)
			{
				Speed = Speed < 1.0f ? Speed + 0.1f : 1.0f;
				Angle = (float) (rnd.NextDouble()*2*Math.PI);
			}
			else
			{
				Speed = Speed > 0.0f ? Speed - 0.1f : 0.0f;
			}

			Move(gameObject);
		}

		internal override void Move(GameObject gameObject)
		{
			gameObject.transform.position += new Vector3((float)(Math.Cos(Angle) * Speed) * Time.deltaTime, (float)(Math.Sin(Angle) * Speed) * Time.deltaTime, 0.0f);
		}
	}
}
