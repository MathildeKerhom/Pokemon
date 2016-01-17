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
			MarketSeed seed = new MarketSeed("testSeed", new List<Types.Element> { Types.Element.Acier, Types.Element.Dragon }, "blabla descritpion", 20);
			MarketSeed seed2 = new MarketSeed("testSeed2", new List<Types.Element> { Types.Element.Electrique }, "blabla2 descritpion", 12);
			seeds.Add(seed);
			seeds.Add(seed2);
			seeds.Add(seed);
			seeds.Add(seed2);
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
		/// get the market seed list
		/// </summary>
		/// <returns></returns>
		public List<MarketSeed> GetMarketSeedList()
		{
			return seeds;
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
