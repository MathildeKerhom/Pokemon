using System;
using System.Collections.Generic;

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

			//fictive data :
			MarketSeed seed = new MarketSeed("testSeed", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "blabla descritpion", 20);
			MarketSeed seed2 = new MarketSeed("testSeed2", new List<ElementType> { ElementType.Electrique }, "blabla2 descritpion", 12);
			seeds.Add(seed);
			seeds.Add(seed2);
			seeds.Add(seed);
			seeds.Add(seed2);

			Pokemon pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "pokemon qui ressemble à un crabe");
			Pokemon pokemon2 = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<ElementType> { ElementType.Electrique }, "fidel pokemon qui nous suit partout");
			pokemons.Add(pokemon);
			pokemons.Add(pokemon2);
			pokemons.Add(pokemon);
			pokemons.Add(pokemon2);

			//end fictive data
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
		/// get the pokemon list
		/// </summary>
		/// <returns></returns>
		public List<Pokemon> GetPokemonList()
		{
			return pokemons;
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

		public List<MarketSeed> SeedInventory
		{
			get
			{
				return this.seeds;
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
