using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using PokemonGarden.Classes;
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
	public sealed partial class Laboratory : Page
	{
		public Grid FusionBlockLeft { get; set; }
		public Grid FusionBlockRight { get; set; }
		public Grid UpgradeBlockLeft { get; set; }
		public Grid UpgradeBlockRight { get; set; }
		public PokemonDisplay UpgradePokemon { get; set; }
		public SeedDisplay UpgradeSeed { get; set; }
		public SeedDisplay FusionSeedBlockLeft { get; set; }
		public SeedDisplay FusionSeedBlockRight { get; set; }
		public Button FusionBtn { get; set; }
		public Button UpgradeBtn { get; set; }

		public Laboratory()
		{
			this.InitializeComponent();
			this.FusionBlockLeft = this.fusionBlockLeft;
			this.FusionBlockRight = this.fusionBlockRight;
			this.UpgradeBlockLeft = this.upgradeBlockLeft;
			this.UpgradeBlockRight = this.upgradeBlockRight;
			this.UpgradePokemon = this.pokemonUpgrade;
			this.UpgradeSeed = this.seedUpgrade;
			this.FusionSeedBlockLeft = this.seedLeftFusion;
			this.FusionSeedBlockRight = this.seedRightFusion;
			this.FusionBtn = this.btnFusion;
			this.UpgradeBtn = this.btnUpgrade;
			new LaboratoryViewModel(this);
		}
	}
}
