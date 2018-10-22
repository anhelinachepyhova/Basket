using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	class Uber_ChiterPlayer : BasePlayer
	{
		private int step;

		private int increment()
		{
			return step++;
		}

		private int getNumber(HistoryGame[] hg)
		{
			int num;
			do
			{
				num = TypePlayer.min_weight + increment();
			} while (HistoryGame.fndNum(hg, num));
			return num;
		}

		public override bool findNumber(int weightBasket, out int num, HistoryGame[] hg)
		{
			num = getNumber(hg);
			if (num == weightBasket)
			{
				return true;
			}
			return false;
		}
	}
}
