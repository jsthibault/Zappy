#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Zappy_Client
{
	static class Program
	{
		private static Zappy mainZappy;

		[STAThread]
		static void Main ()
		{
			mainZappy = new Zappy();
			mainZappy.Run ();
		}
	}
}
