using PokemonGarden.Classes;
using PokemonGarden.View;
using PokemonGarden.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using PokemonGarden.Classes.AutoGenerator;

namespace PokemonGarden.ViewModel
{
	class GardenViewModel
	{
		private Garden garden;
		private Player player;

		public GardenViewModel(Garden garden)
		{
			this.player = Player.GetPlayer;
			this.garden = garden;
			this.init();
			this.bind();
		}

		private void init()
		{
			if (this.player.StoredGarden.Length != 9)
			{
				throw new InvalidOperationException("Pokemon garden haven't 9 element inner tab");
			}
			for (int i = 0; i < this.player.StoredGarden.Length; i++)
			{
				seedDropInto(i, this.player.StoredGarden[i] as MarketSeed);
			}
		}

		private void bind()
		{
			this.garden.GridSeed1.DragLeave += seed_DragLeave;
			this.garden.GridSeed1.DragEnter += seed_DragEnter;
			this.garden.GridSeed1.Drop += seed1_Drop;
			this.garden.GridSeed1.AllowDrop = true;

			this.garden.GridSeed2.DragLeave += seed_DragLeave;
			this.garden.GridSeed2.DragEnter += seed_DragEnter;
			this.garden.GridSeed2.Drop += seed2_Drop;
			this.garden.GridSeed2.AllowDrop = true;

			this.garden.GridSeed3.DragLeave += seed_DragLeave;
			this.garden.GridSeed3.DragEnter += seed_DragEnter;
			this.garden.GridSeed3.Drop += seed3_Drop;
			this.garden.GridSeed3.AllowDrop = true;

			this.garden.GridSeed4.DragLeave += seed_DragLeave;
			this.garden.GridSeed4.DragEnter += seed_DragEnter;
			this.garden.GridSeed4.Drop += seed4_Drop;
			this.garden.GridSeed4.AllowDrop = true;

			this.garden.GridSeed5.DragLeave += seed_DragLeave;
			this.garden.GridSeed5.DragEnter += seed_DragEnter;
			this.garden.GridSeed5.Drop += seed5_Drop;
			this.garden.GridSeed5.AllowDrop = true;

			this.garden.GridSeed6.DragLeave += seed_DragLeave;
			this.garden.GridSeed6.DragEnter += seed_DragEnter;
			this.garden.GridSeed6.Drop += seed6_Drop;
			this.garden.GridSeed6.AllowDrop = true;

			this.garden.GridSeed7.DragLeave += seed_DragLeave;
			this.garden.GridSeed7.DragEnter += seed_DragEnter;
			this.garden.GridSeed7.Drop += seed7_Drop;
			this.garden.GridSeed7.AllowDrop = true;

			this.garden.GridSeed8.DragLeave += seed_DragLeave;
			this.garden.GridSeed8.DragEnter += seed_DragEnter;
			this.garden.GridSeed8.Drop += seed8_Drop;
			this.garden.GridSeed8.AllowDrop = true;

			this.garden.GridSeed9.DragLeave += seed_DragLeave;
			this.garden.GridSeed9.DragEnter += seed_DragEnter;
			this.garden.GridSeed9.Drop += seed9_Drop;
			this.garden.GridSeed9.AllowDrop = true;

			this.garden.Image1.Tapped += Transph_Tapped;
			this.garden.Image2.Tapped += Transph_Tapped;
			this.garden.Image3.Tapped += Transph_Tapped;
			this.garden.Image4.Tapped += Transph_Tapped;
			this.garden.Image5.Tapped += Transph_Tapped;
			this.garden.Image6.Tapped += Transph_Tapped;
			this.garden.Image7.Tapped += Transph_Tapped;
			this.garden.Image8.Tapped += Transph_Tapped;
			this.garden.Image9.Tapped += Transph_Tapped;

			this.garden.GridPokemon1.DragLeave += pokemon_DragLeave;
			this.garden.GridPokemon1.DragEnter += pokemon_DragEnter;
			this.garden.GridPokemon1.Drop += pokemon1_Drop;
			this.garden.GridPokemon1.AllowDrop = true;

			this.garden.GridPokemon2.DragLeave += pokemon_DragLeave;
			this.garden.GridPokemon2.DragEnter += pokemon_DragEnter;
			this.garden.GridPokemon2.Drop += pokemon2_Drop;
			this.garden.GridPokemon2.AllowDrop = true;

			(Window.Current.Content as Frame).Navigating += this.onChangingFrame;
		}

		private void onChangingFrame(object sender, NavigatingCancelEventArgs e)
		{
			this.garden.GridSeed1.DragLeave -= seed_DragLeave;
			this.garden.GridSeed1.DragEnter -= seed_DragEnter;
			this.garden.GridSeed1.Drop -= seed1_Drop;

			this.garden.GridSeed2.DragLeave -= seed_DragLeave;
			this.garden.GridSeed2.DragEnter -= seed_DragEnter;
			this.garden.GridSeed2.Drop -= seed2_Drop;

			this.garden.GridSeed3.DragLeave -= seed_DragLeave;
			this.garden.GridSeed3.DragEnter -= seed_DragEnter;
			this.garden.GridSeed3.Drop -= seed3_Drop;

			this.garden.GridSeed4.DragLeave -= seed_DragLeave;
			this.garden.GridSeed4.DragEnter -= seed_DragEnter;
			this.garden.GridSeed4.Drop -= seed4_Drop;

			this.garden.GridSeed5.DragLeave -= seed_DragLeave;
			this.garden.GridSeed5.DragEnter -= seed_DragEnter;
			this.garden.GridSeed5.Drop -= seed5_Drop;

			this.garden.GridSeed6.DragLeave -= seed_DragLeave;
			this.garden.GridSeed6.DragEnter -= seed_DragEnter;
			this.garden.GridSeed6.Drop -= seed6_Drop;

			this.garden.GridSeed7.DragLeave -= seed_DragLeave;
			this.garden.GridSeed7.DragEnter -= seed_DragEnter;
			this.garden.GridSeed7.Drop -= seed7_Drop;

			this.garden.GridSeed8.DragLeave -= seed_DragLeave;
			this.garden.GridSeed8.DragEnter -= seed_DragEnter;
			this.garden.GridSeed8.Drop -= seed8_Drop;

			this.garden.GridSeed9.DragLeave -= seed_DragLeave;
			this.garden.GridSeed9.DragEnter -= seed_DragEnter;
			this.garden.GridSeed9.Drop -= seed9_Drop;

			this.garden.Image1.Tapped -= Transph_Tapped;
			this.garden.Image2.Tapped -= Transph_Tapped;
			this.garden.Image3.Tapped -= Transph_Tapped;
			this.garden.Image4.Tapped -= Transph_Tapped;
			this.garden.Image5.Tapped -= Transph_Tapped;
			this.garden.Image6.Tapped -= Transph_Tapped;
			this.garden.Image7.Tapped -= Transph_Tapped;
			this.garden.Image8.Tapped -= Transph_Tapped;
			this.garden.Image9.Tapped -= Transph_Tapped;

			this.garden.GridPokemon1.DragLeave -= pokemon_DragLeave;
			this.garden.GridPokemon1.DragEnter -= pokemon_DragEnter;
			this.garden.GridPokemon1.Drop -= pokemon1_Drop;

			this.garden.GridPokemon2.DragLeave -= pokemon_DragLeave;
			this.garden.GridPokemon2.DragEnter -= pokemon_DragEnter;
			this.garden.GridPokemon2.Drop -= pokemon2_Drop;

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;
		}

		/// <summary>
		/// user can drop only is block is free
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void seed_DragEnter(object sender, DragEventArgs e)
		{
			UIElementCollection childs = (sender as Grid).Children;
			foreach (UIElement child in childs)
			{
				if (child.GetType() == typeof(Image))
				{
					if ((child as Image).Visibility == Visibility.Visible)
					{
						e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
						return;
					}
				}
			}
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
		}

		/// <summary>
		/// user can't drop element outer of block
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void seed_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		/// <summary>
		/// drop a marketseed inside garden block and remove the seed in user list
		/// </summary>
		/// <param name="dropId">block id to drop seed</param>
		/// <param name="seedToDrop">seed to drop</param>
		private void seedDropInto(int dropId, MarketSeed seedToDrop)
		{
			if (seedToDrop != null)
			{
				switch (dropId)
				{
					case 1:
						this.garden.Image1.Visibility = Visibility.Visible;
						this.garden.Seed1.DataContext = seedToDrop;
						break;
					case 2:
						this.garden.Image2.Visibility = Visibility.Visible;
						this.garden.Seed2.DataContext = seedToDrop;
						break;
					case 3:
						this.garden.Image3.Visibility = Visibility.Visible;
						this.garden.Seed3.DataContext = seedToDrop;
						break;
					case 4:
						this.garden.Image4.Visibility = Visibility.Visible;
						this.garden.Seed4.DataContext = seedToDrop;
						break;
					case 5:
						this.garden.Image5.Visibility = Visibility.Visible;
						this.garden.Seed5.DataContext = seedToDrop;
						break;
					case 6:
						this.garden.Image6.Visibility = Visibility.Visible;
						this.garden.Seed6.DataContext = seedToDrop;
						break;
					case 7:
						this.garden.Image7.Visibility = Visibility.Visible;
						this.garden.Seed7.DataContext = seedToDrop;
						break;
					case 8:
						this.garden.Image8.Visibility = Visibility.Visible;
						this.garden.Seed8.DataContext = seedToDrop;
						break;
					case 9:
						this.garden.Image9.Visibility = Visibility.Visible;
						this.garden.Seed9.DataContext = seedToDrop;
						break;
				}
				this.player.SeedInventory.Remove(seedToDrop);
			}
		}

		private void seed1_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(1, seed as MarketSeed);
		}

		private void seed2_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(2, seed as MarketSeed);
		}

		private void seed3_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(3, seed as MarketSeed);
		}

		private void seed4_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(4, seed as MarketSeed);
		}

		private void seed5_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(5, seed as MarketSeed);
		}

		private void seed6_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(6, seed as MarketSeed);
		}

		private void seed7_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(7, seed as MarketSeed);
		}

		private void seed8_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(8, seed as MarketSeed);
		}

		private void seed9_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			seedDropInto(9, seed as MarketSeed);
		}

		/// <summary>
		/// On metamorph tapped, generate a new pokemon with seed abilities
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Transph_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Pokemon pokemon = null;
			Image imgSource = e.OriginalSource as Image;
			Grid parent = imgSource.Parent as Grid;
			UIElementCollection childs = (parent as Grid).Children;
			foreach (UIElement child in childs)
			{
				if (child.GetType() == typeof(SeedDisplay))
				{
					SeedDisplay seedDisplay = child as SeedDisplay;
					MarketSeed seed = seedDisplay?.DataContext as MarketSeed;
					if (seed != null)
					{
						pokemon = GetRandomPokemon(seed);
						seedDisplay.DataContext = null;
						PokemonRecived pokemonPopup = new PokemonRecived(pokemon);
						Task<ContentDialogResult> getAsyncShow = pokemonPopup.ShowAsync().AsTask();

						Player player = Player.GetPlayer;
						player.AddPokemon(pokemon);
					}
					imgSource.Visibility = Visibility.Collapsed;
				}
			}
		}

		/// <summary>
		/// create a random pokemon with seed attributs
		/// </summary>
		/// <param name="source">original source</param>
		/// <returns></returns>
		private Pokemon GetRandomPokemon(MarketSeed seedSource)
		{
			Pokemon pokemon = null;

			if (seedSource != null)
			{
				pokemon = ClassGenerator<Pokemon>.GenerateItem();
				pokemon.ImgType = seedSource.UriTypeList;
			}

			return pokemon;
		}

		private void pokemon_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void pokemon_DragEnter(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
		}

		private void pokemon1_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.garden.Pokemon1.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon2_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.garden.Pokemon2.DataContext = (Pokemon)pokemon;
			}
		}
	}
}
