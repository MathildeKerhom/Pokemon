using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonGarden.Classes;
using PokemonGarden.View.UserControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGarden.View
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class Garden : Page
	{
		public Garden()
		{
			this.InitializeComponent();
			//this.DataContext = Player.GetPlayer();
			Player player = Player.GetPlayer();
			this.seed1.DataContext = player.GetMarketSeedList().FirstOrDefault();
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
				seed1.DataContext = (MarketSeed)seed;
			}
		}

		private void seed2_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed2.DataContext = (MarketSeed)seed;
			}
		}

		private void seed3_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed3.DataContext = (MarketSeed)seed;
			}
		}

		private void seed4_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed4.DataContext = (MarketSeed)seed;
			}
		}

		private void seed5_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed5.DataContext = (MarketSeed)seed;
			}
		}

		private void seed6_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed6.DataContext = (MarketSeed)seed;
			}
		}

		private void seed7_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed7.DataContext = (MarketSeed)seed;
			}
		}

		private void seed8_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed8.DataContext = (MarketSeed)seed;
			}
		}

		private void seed9_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				seed9.DataContext = (MarketSeed)seed;
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
				pokemon = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<Types.Element> { Types.Element.Plante, Types.Element.Poison }, "pokemon qui ressemble à un crabe");
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
				this.pokemon1.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon2_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.pokemon2.DataContext = (Pokemon)pokemon;
			}
		}
	}
}
