using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	public static class TypePlayer
	{
		public enum TypePlayerEn
		{
			Ordinary = 1,
			Blocknot = 2,
			Uber = 3,
			Chiter = 4,
			Uber_Chiter = 5
		}

		public const int count_Pl = 8;
		public const int min_weight = 40;
		public const int max_weight = 140;
		public const int stepcount = 20;

	}
}
