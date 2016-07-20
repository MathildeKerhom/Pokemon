using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace PokemonGarden.Classes
{
	public class Player : EntityBase
	{
		private string name;
		private int money;
		private ObservableCollection<MarketSeed> seeds;
		private ObservableCollection<Pokemon> pokemons;
		private Rewards rewards;
		private TopBarData topBarData;

		public Player()
		{
			this.seeds = new ObservableCollection<MarketSeed>();
			this.pokemons = new ObservableCollection<Pokemon>();
			this.rewards = new Rewards();
			this.topBarData = new TopBarData(this);
		}

		public Player(string name, int money)
		{
			this.seeds = new ObservableCollection<MarketSeed>();
			this.pokemons = new ObservableCollection<Pokemon>();
			this.rewards = new Rewards();
			this.topBarData = new TopBarData(this);
			this.name = name;
			this.money = money;

			//fictive data :
			MarketSeed seed = new MarketSeed("testSeed", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "blabla descritpion 1", 20);
			MarketSeed seed2 = new MarketSeed("testSeed2", new List<ElementType> { ElementType.Electrique }, "blabla2 descritpion 2", 12);
			MarketSeed seed3 = new MarketSeed("testSeed3", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "blabla descritpion 3", 20);
			MarketSeed seed4 = new MarketSeed("testSeed4", new List<ElementType> { ElementType.Electrique }, "blabla2 descritpion 4", 12);
			seeds.Add(seed);
			seeds.Add(seed2);
			seeds.Add(seed3);
			seeds.Add(seed4);

			Pokemon pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "pokemon qui ressemble à un crabe");
			Pokemon pokemon2 = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<ElementType> { ElementType.Electrique }, "fidel pokemon qui nous suit partout");
			pokemons.Add(pokemon);
			pokemons.Add(pokemon2);
			pokemons.Add(pokemon);
			pokemons.Add(pokemon2);

			//end fictive data
		}

		///// <summary>
		///// buy seed on mmarket
		///// </summary>
		///// <param name="marketSeed">item of market seedList</param>
		//public void Buy(MarketSeed marketSeed)
		//{
		//	topBarData.OnPropertyChanged("SeedActual");
		//}

		///// <summary>
		///// sell seed on market
		///// </summary>
		///// <param name="marketSeed">item of player seedList</param>
		//public void Sell(MarketSeed marketSeed)
		//{
		//	topBarData.OnPropertyChanged("SeedActual");
		//}

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
				topBarData.OnMoneyChanged();
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				this.name = value;
			}
		}

		/// <summary>
		/// player seed list
		/// </summary>
		/// <returns></returns>
		[OneToMany(CascadeOperations = CascadeOperation.All)]
		public ObservableCollection<MarketSeed> SeedInventory
		{
			get
			{
				return this.seeds;
			}
			set
			{
				this.seeds = value;
			}
		}

		/// <summary>
		/// player pokemon list
		/// </summary>
		/// <returns></returns>
		[Ignore]
		public ObservableCollection<Pokemon> PokemonInventory
		{
			get
			{
				return this.pokemons;
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
