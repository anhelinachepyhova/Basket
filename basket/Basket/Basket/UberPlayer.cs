using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	class UberPlayer : BasePlayer
	{
		private int step;

		private int increment()
		{
			return step++;
		}

		public override bool findNumber(int weightBasket, out int num, HistoryGame[] hg)
		{
			num = TypePlayer.min_weight + increment();
			if (num == weightBasket)
			{
				return true;
			}
			return false;
		}
	}
}
