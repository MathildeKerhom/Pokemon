using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes
{
	public class Player
	{
		private string name;
		private int money;
		private List<MarketSeed> seeds;
		private List<Pokemon> pokemons;
		private Rewards rewards;
		private TopBarData topBarData;

		public Player(string name, int money)
		{
			this.name = name;
			this.money = money;
			this.seeds = new List<MarketSeed>();
			this.pokemons = new List<Pokemon>();
			this.rewards = new Rewards();
			this.topBarData = new TopBarData(this.money, seeds, pokemons, rewards);
		}

		/// <summary>
		/// buy seed on mmarket
		/// </summary>
		/// <param name="marketSeed">item of market seedList</param>
		public void Buy(MarketSeed marketSeed)
		{
			topBarData.OnPropertyChanged("SeedActual");
		}

		/// <summary>
		/// sell seed on market
		/// </summary>
		/// <param name="marketSeed">item of player seedList</param>
		public void Sell(MarketSeed marketSeed)
		{
			topBarData.OnPropertyChanged("SeedActual");
		}

		/// <summary>
		/// Notify seed is ready to the user
		/// </summary>
		/// <param name="gardenSeed"></param>
		public void SendPopup(GardenSeed gardenSeed)
		{

		}

		/// <summary>
		/// data values objet of topBar
		/// </summary>
		/// <returns></returns>
		public TopBarData GetTopBarData()
		{
			return this.topBarData;
		}

		public void AddPokemon(Pokemon pokemon)
		{
			pokemons.Add(pokemon);
			topBarData.OnPropertyChanged("PokemonTotal");
		}

		public int Money
		{
			get
			{
				return this.money;
			}

			set
			{
				this.money = value;
				topBarData.OnMoneyChanged(value, "GoldActual");
				//actualizeGold();
			}
		}

		//public int RewardTotal
		//{
		//	get
		//	{
		//		return player.rewardTotal;
		//	}

		//	set
		//	{
		//		player.rewardTotal = value;
		//		topBarData.OnPropertyChanged("actualizeRewardCounter");
		//	}
		//}

		//public int RewardActual
		//{
		//	get
		//	{
		//		return player.rewardActual;
		//	}

		//	set
		//	{
		//		player.rewardActual = value;
		//		topBarData.OnPropertyChanged("actualizeRewardCounter");
		//	}
		//}

		/// <summary>
		/// singleton of player
		/// </summary>
		private static Player player;
		private static object locked = new object();

		/// <summary>
		/// get player instance
		/// </summary>
		/// <returns></returns>
		public static Player GetPlayer()
		{
			if (player == null)
			{
				lock (locked)
				{
					if (player == null)
					{
						player = new Player("localPlayer", 1000);
					}
				}
			}

			return player;
		}
	}
}
