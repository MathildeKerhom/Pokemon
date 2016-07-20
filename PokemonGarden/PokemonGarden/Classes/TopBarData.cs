using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		
		//private Rewards rewards;
		private Player player;

		public TopBarData(Player player)
		{
			this.player = player;
			this.player.SeedInventory.CollectionChanged += Seeds_CollectionChanged;
			this.player.PokemonInventory.CollectionChanged += Pokemons_CollectionChanged;
		}

		private void Pokemons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("PokemonTotal");
		}

		private void Seeds_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("SeedActual");
		}

		public int PokemonTotal
		{
			get
			{
				return this.player.PokemonInventory.Count;
			}
		}

		public int SeedActual
		{
			get
			{
				return this.player.SeedInventory.Count;
			}
		}

		public int GoldActual
		{
			get
			{
				return this.player.Money;
			}
		}

		public string actualizeRewardCounter
		{
			get
			{
				return $"{ 0 } / { 150 }";
			}
		}

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			// Raise the PropertyChanged event, passing the name of the property whose value has changed.
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public void OnMoneyChanged()
		{
			// Raise the PropertyChanged event, passing the name of the property whose value has changed.
			OnPropertyChanged("GoldActual");
		}
	}
}
