using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
	internal abstract class IController
	{
		private int XVector;
		private int YVector;
		private float Speed;

		public abstract void Move();
	}
}
