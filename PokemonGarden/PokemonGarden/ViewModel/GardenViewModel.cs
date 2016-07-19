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

namespace PokemonGarden.ViewModel
{
	class GardenViewModel
	{
		private Garden garden;

		public GardenViewModel(Garden garden)
		{
			this.garden = garden;
			this.init();
			this.bind();
		}

		private void init()
		{
			Player player = Player.GetPlayer();
			this.garden.Seed1.DataContext = player.GetMarketSeedList().FirstOrDefault();
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

		private void seed_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void seed1_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed1.DataContext = (MarketSeed)seed;
			}
		}

		private void seed2_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed2.DataContext = (MarketSeed)seed;
			}
		}

		private void seed3_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed3.DataContext = (MarketSeed)seed;
			}
		}

		private void seed4_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed4.DataContext = (MarketSeed)seed;
			}
		}

		private void seed5_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed5.DataContext = (MarketSeed)seed;
			}
		}

		private void seed6_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed6.DataContext = (MarketSeed)seed;
			}
		}

		private void seed7_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed7.DataContext = (MarketSeed)seed;
			}
		}

		private void seed8_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed8.DataContext = (MarketSeed)seed;
			}
		}

		private void seed9_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.garden.Seed9.DataContext = (MarketSeed)seed;
			}
		}

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
					pokemon = GetRandomPokemon(seedDisplay.DataContext as MarketSeed);
					seedDisplay.DataContext = null;
				}
			}

			PokemonRecived pokemonPopup = new PokemonRecived(pokemon);
			Task<ContentDialogResult> getAsyncShow = pokemonPopup.ShowAsync().AsTask();

			imgSource.Visibility = Visibility.Collapsed;
			Player player = Player.GetPlayer();
			player.AddPokemon(pokemon);
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
				pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", seedSource.GetUriTypeList, "pokemon qui ressemble à un crabe");
			}
			else
			{
				pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<ElementType> { ElementType.Plante, ElementType.Poison }, "pokemon qui ressemble à un crabe");
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
