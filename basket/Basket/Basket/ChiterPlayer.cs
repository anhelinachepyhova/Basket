using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	class ChiterPlayer : BasePlayer
	{
		private int getNumber(HistoryGame[] hg)
		{
			Random chnum = new Random((int)DateTime.Now.Ticks);
			int num;
			do
			{
				num = chnum.Next(TypePlayer.min_weight, TypePlayer.max_weight);
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
