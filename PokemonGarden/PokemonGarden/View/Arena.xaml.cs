using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using PokemonGarden.Classes;
using PokemonGarden.View.UserControls;
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
			this.pokemonAI.DataContext = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<Types.Element> { Types.Element.Electrique }, "fidel pokemon qui nous suit partout", "Transparent");
			this.pokemon1.DataContext = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<Types.Element> { Types.Element.Insecte, Types.Element.Plante }, "pokemon qui ressemble à un crabe");
		}

		private void pokemon_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void pokemon_DragEnter(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
		}

		private void pokemon_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.DataView.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				(pokemon as Pokemon).SetBackgroundToTransparent();
				this.pokemonPlayer.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon_DragItemsStarting(object sender, DragStartingEventArgs e)
		{
			object item = (sender as PokemonDisplay).DataContext;
			if (item != null)
			{
				e.Data.Properties.Add("pokemonSource", item);
			}
		}
	}
}
