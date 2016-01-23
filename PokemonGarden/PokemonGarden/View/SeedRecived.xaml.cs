using PokemonGarden.Classes;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Boîte de dialogue de contenu, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGarden
{
	public sealed partial class SeedRecived : ContentDialog
	{
		public SeedRecived(MarketSeed seed)
		{
			this.InitializeComponent();
			this.DataContext = seed;
		}

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.Hide();
		}
	}
}
