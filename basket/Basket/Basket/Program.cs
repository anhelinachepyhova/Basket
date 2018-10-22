using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Basket");

			BasePlayer[] orm = new BasePlayer[1];
			HistoryGame[] hg = new HistoryGame[TypePlayer.stepcount+1];

			Random rnd1 = new Random((int)DateTime.Now.Ticks);
			Random bskt = new Random((int)DateTime.Now.Ticks);

			int count_Plaer = getvaluecwint("Укажите  количество играков, которіе будут принимать участие от (2 - 8) - ");
			int cnt = 0;

			Console.WriteLine("Создаем играков ");
			createPlaer(ref orm, rnd1, ref cnt, count_Plaer);

			Console.Clear();

			int weight = bskt.Next(TypePlayer.min_weight, TypePlayer.max_weight);

			Console.WriteLine($"Вес корзині - {weight}");

			Console.WriteLine("Начинаем игру");
			give(count_Plaer, orm, weight, hg);

			Console.ReadLine();

		}

		static public int getvaluecwint(string str)
		{
			bool flag_exit;
		    int par = 0;

			do
			{
				string str1 = getvaluecwstr(str);
				flag_exit = int.TryParse(str1, out par);
			} while (flag_exit == false);

			return par;
		}

		static public string getvaluecwstr(string str)
		{
			bool flag_exit;
			string par;
			do
			{
				Console.Write(str);
				par = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(par))
				{
					flag_exit = false;
					break;
				}
				else
				{
					flag_exit = true;
				}
			} while (flag_exit == false);
			return par;
		}

		static void createPlaer(ref BasePlayer[] orm, Random rnd1, ref int cnt, int count_Plaer)
		{
			do
			{
				foreach (int type in Enum.GetValues(typeof(TypePlayer.TypePlayerEn)))
				{
						Console.WriteLine($"{type}. {Enum.GetName(typeof(TypePlayer.TypePlayerEn), type)}");
				}
				int numtype = getvaluecwint("Віберите тип игрока: ");
				string nameplayer = getvaluecwstr("Уажите имя игрока: ");

				switch (numtype)
				{
					case 1:
						{
							orm[cnt] = new OrdinaryPlayer();
							orm[cnt].setAdd(nameplayer, 1, rnd1.Next(1, 16));
							Array.Resize(ref orm, orm.Length + 1);
							cnt++;
							break;
						}
					case 2:
						{
							orm[cnt] = new BlocknotPlayer();
							orm[cnt].setAdd(nameplayer, 2, rnd1.Next(1, 16));
							Array.Resize(ref orm, orm.Length + 1);
							cnt++;
							break;
						}
					case 3:
						{
							orm[cnt] = new UberPlayer();
							orm[cnt].setAdd(nameplayer, 3, rnd1.Next(1, 16));
							Array.Resize(ref orm, orm.Length + 1);
							cnt++;
							break;
						}
					case 4:
						{
							orm[cnt] = new ChiterPlayer();
							orm[cnt].setAdd(nameplayer, 4, rnd1.Next(1, 16));
							Array.Resize(ref orm, orm.Length + 1);
							cnt++;
							break;
						}
					case 5:
						{
							orm[cnt] = new Uber_ChiterPlayer();
							orm[cnt].setAdd(nameplayer, 5, rnd1.Next(1, 16));
							Array.Resize(ref orm, orm.Length + 1);
							cnt++;
							break;
						}
					default:
						{
							Console.WriteLine("Такого типа игрока нет!!!");
							break;
						}
				}
			} while (count_Plaer != cnt);
		}

		static void give(int count_Plaer, BasePlayer[] orm, int weight, HistoryGame[] hg)
		{
			bool flag_exit = false;
			int num, num1;

			for (int i = 1; i <= TypePlayer.stepcount;)
			{
				for (int j = 0; j < count_Plaer && i <= TypePlayer.stepcount; j++)
				{
					Console.ForegroundColor = (ConsoleColor)orm[j].Color;
					flag_exit = orm[j].findNumber(weight, out num, hg);
					Console.Write($"{orm[j].Name} - step {i} = {num}; ");

					hg[i].setHistoryGame(orm[j].Name, (TypePlayer.TypePlayerEn)orm[j].Type, num);

					if (flag_exit)
					{
						Console.WriteLine($"Gime Over! Plaer {orm[j].Name} is WIN!!!");
						break;
					}

					Console.ResetColor();
					i++;
				}
				Console.WriteLine();
				if (flag_exit)
				{
					break;
				}
			}

			if (flag_exit == false)
			{

				num1 = HistoryGame.findWin(ref hg, weight);
				Console.WriteLine($"Gime Over! Plaer {hg[num1].Name} is WIN!!!. Your value is {hg[num1].Num}");
			}

		}
	}
}
