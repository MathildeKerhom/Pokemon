using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public sealed partial class SeedListDisplay : UserControl
	{
		public SeedListDisplay()
		{
			this.InitializeComponent();
			this.seedListView.ItemsSource = Player.GetPlayer.SeedInventory;
		}

		private void seed_DragStarting(object sender, DragItemsStartingEventArgs args)
		{
			MarketSeed item = args.Items.FirstOrDefault() as MarketSeed;
			if (item != null && item.IsEnable)
			{
				args.Data.Properties.Add("seedSource", item);
			}
			else
			{
				args.Cancel = true;
			}
		}
	}
}
