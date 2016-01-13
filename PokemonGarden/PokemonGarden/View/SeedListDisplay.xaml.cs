﻿using System;
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

namespace PokemonGarden.View
{
	public sealed partial class SeedListDisplay:UserControl
	{
		private List<Seed> seeds;
		public SeedListDisplay()
		{
			seeds = new List<Seed>();
			Seed seed = new Seed("testSeed", new List<Types.Element> { Types.Element.Acier, Types.Element.Dragon }, "blabla descritpion", 20);
			Seed seed2 = new Seed("testSeed2", new List<Types.Element> { Types.Element.Electrique }, "blabla2 descritpion", 12);
			seeds.Add(seed);
			seeds.Add(seed2);
			seeds.Add(seed);
			seeds.Add(seed2);

			this.InitializeComponent();
			this.seedListView.ItemsSource = seeds;
		}

		private void seed_DragStarting(object sender, DragItemsStartingEventArgs e)
		{
			object item = e.Items.FirstOrDefault();
			if (item != null)
			{
				e.Data.Properties.Add("seedSource", item);
			}
		}
	}
}
