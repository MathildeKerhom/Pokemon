using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes
{
	public class TopBarData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		private int money;
		private List<MarketSeed> seeds;
		private List<Pokemon> pokemons;
		private Rewards rewards;

		public TopBarData(int money, List<MarketSeed> seeds, List<Pokemon> pokemons, Rewards rewards)
		{
			this.money = money;
			this.seeds = seeds;
			this.pokemons = pokemons;
			this.rewards = rewards;
		}
		
		public int PokemonTotal
		{
			get
			{
				return this.pokemons.Count;
			}
		}

		public int SeedActual
		{
			get
			{
				return this.seeds.Count;
			}
		}

		public int GoldActual
		{
			get
			{
				return this.money;
			}
		}

		public string actualizeRewardCounter
		{
			get
			{
				return $"{ 0 } / { 150 }";
			}
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			// Raise the PropertyChanged event, passing the name of the property whose value has changed.
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public void OnMoneyChanged(int value, [CallerMemberName] string propertyName = null)
		{
			this.money = value;
			// Raise the PropertyChanged event, passing the name of the property whose value has changed.
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
