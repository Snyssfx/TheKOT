﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
	internal abstract class Controller
	{
		private float Angle;
		private float Speed;

		public abstract void Control(GameObject gameObject);

		internal abstract void Move(GameObject gameObject);
	}
}