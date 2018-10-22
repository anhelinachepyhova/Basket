using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	public struct HistoryGame
	{
		private string name;
		private TypePlayer.TypePlayerEn type;
		private int num;


		public int Num
		{
			get
			{ return num; }
		}

		public string Name
		{
			get
			{ return name; }
		}

		public TypePlayer.TypePlayerEn Type
		{
			get
			{ return type; }
		}

		public void setHistoryGame(string Name, TypePlayer.TypePlayerEn Type, int Num)
		{
			name = Name;
			type = Type;
			num = Num;
		}

		public static  bool fndNum(HistoryGame[] hg, int Num, string Name, TypePlayer.TypePlayerEn Type)
		{
			for (int i = 0; i < hg.Length; i++)
			{
				if ((hg[i].name == Name) && (hg[i].num == Num) && (hg[i].type == Type))
				{
					return true;
				}
			}
			return false;
		}

		public static bool fndNum(HistoryGame[] hg, int Num)
		{
			for (int i = 0; i < hg.Length; i++)
			{
				if ((hg[i].num == Num))
				{
					return true;
				}
			}
			return false;
		}

		private static HistoryGame[] sort(ref HistoryGame[] hg)
		{
			HistoryGame[] hg1 = new HistoryGame[1];
			for (int i = 1; i < hg.Length; i++)
				for (int j = 1; j < hg.Length; j++)
				{
					if (hg[i].num < hg[j].num)
						{
							hg1[0] = hg[i];
							hg[i] = hg[j];
							hg[j] = hg1[0];
						}
				}
			return hg;
		}

		public static int findWin(ref HistoryGame[] hg, int weightBasket)
		{
			hg = sort(ref hg);

			int fpar = 0, spar = 0, npfpar = 0, nspar = 0;
			for (int i = 1; i < hg.Length; i++)
			{
				if ((weightBasket > hg[i].num) && (fpar != hg[i].num))
				{
					fpar = hg[i].num;
					npfpar = i;
				}
				else if (weightBasket < hg[i].num)
				{
					spar = hg[i].num;
					nspar = i;
					break;
				}
			}

			if ((weightBasket - fpar) < (spar - weightBasket))
			{
				return npfpar;
			}
			else if ((weightBasket - fpar) == (spar - weightBasket))
			{
				return nspar;
			}
			else
			{
				return npfpar;
			}
		}
	}
}
