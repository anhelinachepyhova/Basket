using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	public abstract class BasePlayer
	{
		public string Name { get; set; }
		public TypePlayer.TypePlayerEn Type { get; set; }
		public int Color { get; set; }

		public void setAdd(string name, int type, int color)
		{
			Name = name;
			Type = (TypePlayer.TypePlayerEn)type;
			Color = color;
		}

		public abstract bool findNumber(int weightBasket, out int num, HistoryGame[] hg = null);
	}
}
