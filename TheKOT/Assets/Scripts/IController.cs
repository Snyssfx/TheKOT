using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
	internal abstract class Controller
	{
		public abstract void Control(GameObject gameObject);

		internal abstract void Move(GameObject gameObject);

		internal abstract void Rotate(GameObject gameObject);
	}
}
