using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokemonGarden.Classes.AutoGenerator;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace PokemonGarden.Classes
{
	public class Player : EntityBase, INotifyPropertyChanged
	{
		private string name;
		private int money;
		private ObservableCollection<MarketSeed> seeds;
		private ObservableCollection<Pokemon> pokemons;
		private ObservableCollection<Reward> rewards;


		public event PropertyChangedEventHandler PropertyChanged;

		public Player()
		{
			this.seeds = new ObservableCollection<MarketSeed>();
			this.pokemons = new ObservableCollection<Pokemon>();
			this.rewards = new ObservableCollection<Reward>();
			bindObservableForINotify();
			this.StoredGarden = new MarketSeed[9];
			this.FightingList = new Pokemon[5];


			this.StoredGarden[2] = ClassGenerator<MarketSeed>.GenerateItem();
		}

		public Player(string name, int money)
		{
			this.seeds = new ObservableCollection<MarketSeed>();
			this.pokemons = new ObservableCollection<Pokemon>();
			this.rewards = new ObservableCollection<Reward>();
			bindObservableForINotify();
			this.name = name;
			this.money = money;
			this.StoredGarden = new MarketSeed[9];
			this.FightingList = new Pokemon[5];

			this.StoredGarden[2] = ClassGenerator<MarketSeed>.GenerateItem();

			//fictive data :
			//MarketSeed seed = new MarketSeed("testSeed", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "blabla descritpion 1", 20);
			//MarketSeed seed = ClassGenerator<MarketSeed>.GenerateItem();
			//MarketSeed seed2 = new MarketSeed("testSeed2", new List<ElementType> { ElementType.Electrique }, "blabla2 descritpion 2", 12);
			//MarketSeed seed3 = new MarketSeed("testSeed3", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "blabla descritpion 3", 20);
			//MarketSeed seed4 = new MarketSeed("testSeed4", new List<ElementType> { ElementType.Electrique }, "blabla2 descritpion 4", 12);
			//this.seeds.Add(seed);
			//this.seeds.Add(seed2);
			//this.seeds.Add(seed3);
			//this.seeds.Add(seed4);

			//Pokemon pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "pokemon qui ressemble à un crabe");
			//Pokemon pokemon2 = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<ElementType> { ElementType.Electrique }, "fidel pokemon qui nous suit partout");
			//Pokemon pokemon3 = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<ElementType> { ElementType.Acier, ElementType.Dragon }, "pokemon qui ressemble à un crabe");
			//Pokemon pokemon4 = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<ElementType> { ElementType.Electrique }, "fidel pokemon qui nous suit partout");
			//this.pokemons.Add(pokemon);
			//this.pokemons.Add(pokemon2);
			//this.pokemons.Add(pokemon3);
			//this.pokemons.Add(pokemon4);

			for (int i = 0; i < new Random(DateTime.Now.Millisecond).Next(1, 21); i++)
			{
				this.seeds.Add(ClassGenerator<MarketSeed>.GenerateItem());
			}

			for (int i = 0; i < new Random(DateTime.Now.Millisecond).Next(1, 6); i++)
			{
				this.pokemons.Add(ClassGenerator<Pokemon>.GenerateItem());
			}

			//Reward testAutoGenn = ClassGenerator<Reward>.GenerateItem();
			//Debugger.Break();
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
				this.OnPropertyChanged();
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
				this.OnPropertyChanged();
			}
		}

		public int PokemonCount
		{
			get
			{
				return this.pokemons.Count;
			}
		}

		public int SeedCount
		{
			get
			{
				return this.seeds.Count;
			}
		}

		public string RewardCount
		{
			get
			{
				return $"{ this.rewards.Count } / { Reward.Max }";
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

		private void bindObservableForINotify()
		{
			this.seeds.CollectionChanged += Seeds_CollectionChanged;
			this.pokemons.CollectionChanged += Pokemons_CollectionChanged;
			this.rewards.CollectionChanged += Rewards_CollectionChanged;
		}

		private void Rewards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged(nameof(this.RewardCount));
		}

		private void Pokemons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged(nameof(this.PokemonCount));
		}

		private void Seeds_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged(nameof(this.SeedCount));
		}

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handle = PropertyChanged;
			if (handle != null)
			{
				// Raise the PropertyChanged event, passing the name of the property whose value has changed.
				handle(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		/// <summary>
		/// singleton of player
		/// </summary>
		private static volatile Player player;
		private static object locked = new object();

		/// <summary>
		/// get player instance
		/// </summary>
		/// <returns></returns>
		public static Player GetPlayer
		{
			get
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

		public MarketSeed[] StoredGarden
		{
			get;
		}

		public Pokemon[] FightingList
		{
			get;
		}
	}
}
