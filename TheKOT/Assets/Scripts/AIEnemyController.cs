using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets
{
	internal class AiEnemyController : Controller
	{
		private float Angle;
		private float Speed;
		private int Cooldown = 0;
		//private bool CatFound = false;

		private const float pi2 = 1.570796F;

		private const double chanceToMove = 0.5;
		Random rnd = new Random();

		public override void Control(GameObject gameObject)
		{
			
			if (Cooldown > 0)
			{
				Cooldown--;
				if (Cooldown == 0) Speed = 0.0f;
			}
			else
			{
				double chance = rnd.NextDouble();

				if (chance < chanceToMove)
				{
					Speed = 1.0f;
					Angle = (float)(rnd.NextDouble() * 2 * Math.PI);
					Cooldown = rnd.Next(100, 300);
				}
				else
				{
					Cooldown = rnd.Next(50, 200);
				}
			}

			Rotate(gameObject);
			Move(gameObject);
		}

		private void OnTriggerEnter2D(Collision2D coll)
		{
			
		}

		internal override void Move(GameObject gameObject)
		{
			gameObject.transform.position += new Vector3((float)(Math.Cos(Angle) * Speed) * Time.deltaTime, (float)(Math.Sin(Angle) * Speed) * Time.deltaTime, 0.0f);
		}

		internal override void Rotate(GameObject gameObject)
		{
			gameObject.transform.rotation = Quaternion.AngleAxis((float)(((Angle - pi2) / Math.PI * 180)), Vector3.forward);
		}
	}
}
