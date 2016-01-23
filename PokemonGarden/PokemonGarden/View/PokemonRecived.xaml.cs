using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Boîte de dialogue de contenu, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGarden
{
	public sealed partial class PokemonRecived : ContentDialog
	{
		public PokemonRecived(Pokemon pokemonRecived)
		{
			this.InitializeComponent();
			this.DataContext = pokemonRecived;
		}

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.Hide();
		}
	}
}
