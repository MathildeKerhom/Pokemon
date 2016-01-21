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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGarden.View
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class Arena : Page
	{
		public Arena()
		{
			this.InitializeComponent();
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

		private void pokemon3_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.pokemon3.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon4_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.pokemon4.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon5_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.pokemon5.DataContext = (Pokemon)pokemon;
			}
		}
	}
}
