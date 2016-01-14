using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class TopBar:UserControl
	{
		private static GameContent topBarContent = null;

		public TopBar()
		{
			this.InitializeComponent();
			
			if (topBarContent == null)
			{
				topBarContent = new GameContent();
			}

			actualizePokemonCounter();
			actualizeSeed();
			actualizeGold();
			actualizeRewardCounter();
		}

		public int PokemonActual
		{
			get
			{
				return topBarContent.PokemonActual;
			}

			set
			{
				topBarContent.PokemonActual = value;
				actualizePokemonCounter();
			}
		}

		public int PokemonTotal
		{
			get
			{
				return topBarContent.PokemonTotal;
			}

			set
			{
				topBarContent.PokemonTotal = value;
				actualizePokemonCounter();
			}
		}

		public int SeedActual
		{
			get
			{
				return topBarContent.SeedActual;
			}

			set
			{
				topBarContent.SeedActual = value;
				actualizeSeed();
			}
		}

		public int GoldActual
		{
			get
			{
				return topBarContent.GoldActual;
			}

			set
			{
				topBarContent.GoldActual = value;
				actualizeGold();
			}
		}

		public int RewardTotal
		{
			get
			{
				return topBarContent.RewardTotal;
			}

			set
			{
				topBarContent.RewardTotal = value;
				actualizeRewardCounter();
			}
		}

		public int RewardActual
		{
			get
			{
				return topBarContent.RewardActual;
			}

			set
			{
				topBarContent.RewardActual = value;
				actualizeRewardCounter();
			}
		}

		private void actualizePokemonCounter()
		{
			this.pokemonInventoryCounterText.Text = $"{ PokemonActual } / { PokemonTotal }";
		}

		private void actualizeRewardCounter()
		{
			this.rewardsCounterText.Text = $"{ RewardActual } / { RewardTotal }";
		}

		private void actualizeSeed()
		{
			this.seedsCounterText.Text = SeedActual.ToString();
		}

		private void actualizeGold()
		{
			this.coinsCounterText.Text = GoldActual.ToString();
		}

		private void OnClicGoToMap_Tapped(object sender, TappedRoutedEventArgs e)
		{
			(Window.Current.Content as Frame).Navigate(typeof(Village));
        }

		private void OnClicGoToInventary_Tapped(object sender, TappedRoutedEventArgs e)
		{
			//(Window.Current.Content as Frame).Navigate(typeof());
		}
	}
}
