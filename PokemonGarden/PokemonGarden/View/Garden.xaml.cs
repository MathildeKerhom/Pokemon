using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonGarden.Classes;
using PokemonGarden.View.UserControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using PokemonGarden.ViewModel;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGarden.View
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class Garden : Page
	{
        public Grid GridSeed1 { get; set; }
        public Grid GridSeed2 { get; set; }
        public Grid GridSeed3 { get; set; }
        public Grid GridSeed4 { get; set; }
        public Grid GridSeed5 { get; set; }
        public Grid GridSeed6 { get; set; }
        public Grid GridSeed7 { get; set; }
        public Grid GridSeed8 { get; set; }
        public Grid GridSeed9 { get; set; }

        public SeedDisplay Seed1 { get; set; }
        public SeedDisplay Seed2 { get; set; }
        public SeedDisplay Seed3 { get; set; }
        public SeedDisplay Seed4 { get; set; }
        public SeedDisplay Seed5 { get; set; }
        public SeedDisplay Seed6 { get; set; }
        public SeedDisplay Seed7 { get; set; }
        public SeedDisplay Seed8 { get; set; }
        public SeedDisplay Seed9 { get; set; }

        public Image Image1 { get; set; }
        public Image Image2 { get; set; }
        public Image Image3 { get; set; }
        public Image Image4 { get; set; }
        public Image Image5 { get; set; }
        public Image Image6 { get; set; }
        public Image Image7 { get; set; }
        public Image Image8 { get; set; }
        public Image Image9 { get; set; }

        public Grid GridPokemon1 { get; set; }
        public Grid GridPokemon2 { get; set; }

        public PokemonDisplay Pokemon1 { get; set; }
        public PokemonDisplay Pokemon2 { get; set; }

        public Garden()
		{
			this.InitializeComponent();
            this.GridSeed1 = this.gridSeed1;
            this.GridSeed2 = this.gridSeed2;
            this.GridSeed3 = this.gridSeed3;
            this.GridSeed4 = this.gridSeed4;
            this.GridSeed5 = this.gridSeed5;
            this.GridSeed6 = this.gridSeed6;
            this.GridSeed7 = this.gridSeed7;
            this.GridSeed8 = this.gridSeed8;
            this.GridSeed9 = this.gridSeed9;
            this.Seed1 = this.seed1;
            this.Seed2 = this.seed2;
            this.Seed3 = this.seed3;
            this.Seed4 = this.seed4;
            this.Seed5 = this.seed5;
            this.Seed6 = this.seed6;
            this.Seed7 = this.seed7;
            this.Seed8 = this.seed8;
            this.Seed9 = this.seed9;
            this.Image1 = this.image1;
            this.Image2 = this.image2;
            this.Image3 = this.image3;
            this.Image4 = this.image4;
            this.Image5 = this.image5;
            this.Image6 = this.image6;
            this.Image7 = this.image7;
            this.Image8 = this.image8;
            this.Image9 = this.image9;
            this.GridPokemon1 = this.gridPokemon1;
            this.GridPokemon2 = this.gridPokemon2;
            this.Pokemon1 = this.pokemon1;
            this.Pokemon2 = this.pokemon2;

            new GardenViewModel(this);
        }
	}
}
