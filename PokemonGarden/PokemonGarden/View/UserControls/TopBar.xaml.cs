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
			this.DataContext = Player.GetPlayer;
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
