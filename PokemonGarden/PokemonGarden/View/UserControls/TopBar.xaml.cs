using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public sealed partial class TopBar : UserControl
	{
		public TopBar()
		{
			this.InitializeComponent();
			//Player.GetPlayer().AddPokemon(new Pokemon(null, "pika", new List<Types.Element> { Types.Element.Acier }, "blabla"));
			Player player = Player.GetPlayer();
			this.DataContext = player.GetTopBarData();
			//player.Money += 50;
			//player.AddPokemon(new Pokemon(null, "truc", new List<Types.Element> { Types.Element.Acier }, "blabla"));

		}

		private void OnClicGoToMap_Tapped(object sender, TappedRoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(Village));
		}

		private void OnClicGoToInventary_Tapped(object sender, TappedRoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(Inventory));
		}

		/// <summary>
		/// disable navigation to inventory
		/// </summary>
		public void DisableInventoryButton()
		{
			this.goToInventary.IsEnabled = false;
		}
	}
}
