using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using PokemonGarden.ViewModel;
using Microsoft.Azure.Engagement.Overlay;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokemonGarden
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class Village : EngagementPageOverlay
	{
		public Image Me { get; set; }

		public Village()
		{
			this.InitializeComponent();
			this.Me = this.me;
			new VillageViewModel(this);
		}
	}
}
