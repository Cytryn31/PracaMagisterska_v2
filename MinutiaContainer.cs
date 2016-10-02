using System;
using System.Collections.Generic;

namespace PracaMagisterska_v2
{
	public class MinutiaContainer
	{

		public List<Minutia> ReferenceMinutiaeList = new List<Minutia>();
		public List<Minutia> CalculatedMinutiaeList = new List<Minutia>();


		public static MinutiaContainer Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncRoot)
					{
						if (instance == null)
							instance = new MinutiaContainer();
					}
				}

				return instance;
			}
		}







		private static volatile MinutiaContainer instance;
		private static object syncRoot = new Object();

		private MinutiaContainer() { }
	}
}
