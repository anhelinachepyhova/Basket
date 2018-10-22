using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	class OrdinaryPlayer : BasePlayer
	{
		public override bool findNumber(int weightBasket, out int num, HistoryGame[] hg)
		{
			Random chnum = new Random((int)DateTime.Now.Ticks);
			num = chnum.Next(TypePlayer.min_weight, TypePlayer.max_weight);

			if (num == weightBasket)
				{
					return true;
				}
			return false;
		}
	}
}
