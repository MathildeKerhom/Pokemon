using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using PokemonGarden.View.UserControls;
using PokemonGarden.ViewModel;
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
	public sealed partial class Inventory : Page
	{
		public TopBar TopBar { get; set; }
		public PokemonDisplay Pokemon1 { get; set; }
		public PokemonDisplay Pokemon2 { get; set; }
		public PokemonDisplay Pokemon3 { get; set; }
		public PokemonDisplay Pokemon4 { get; set; }
		public PokemonDisplay Pokemon5 { get; set; }
		public Grid ContainerPokemon1 { get; set; }
		public Grid ContainerPokemon2 { get; set; }
		public Grid ContainerPokemon3 { get; set; }
		public Grid ContainerPokemon4 { get; set; }
		public Grid ContainerPokemon5 { get; set; }

		public Inventory()
		{
			this.InitializeComponent();
			this.TopBar = this.topBar;
			this.Pokemon1 = this.pokemon1;
			this.Pokemon2 = this.pokemon2;
			this.Pokemon3 = this.pokemon3;
			this.Pokemon4 = this.pokemon4;
			this.Pokemon5 = this.pokemon5;
			this.ContainerPokemon1 = this.containerPokemon1;
			this.ContainerPokemon2 = this.containerPokemon2;
			this.ContainerPokemon3 = this.containerPokemon3;
			this.ContainerPokemon4 = this.containerPokemon4;
			this.ContainerPokemon5 = this.containerPokemon5;
			
			new InventoryViewModel(this);
		}
	}
}
