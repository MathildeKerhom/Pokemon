using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using PokemonGarden.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokemonGarden.View.UserControls
{
	public sealed partial class PokemonListDisplay : UserControl
	{
		public PokemonListDisplay()
		{
			this.InitializeComponent();
			this.pokemonListView.ItemsSource = Player.GetPlayer.PokemonInventory;
		}

		private void pokemon_DragItemsStarting(object sender, DragItemsStartingEventArgs args)
		{
			Pokemon pokemon = args.Items.FirstOrDefault() as Pokemon;
			if (pokemon != null && pokemon.IsEnable)
			{
				args.Data.Properties.Add("pokemonSource", pokemon);
			}
			else
			{
				args.Cancel = true;
			}
		}
	}
}
