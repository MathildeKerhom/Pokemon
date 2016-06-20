using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using PokemonGarden.ViewModel;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokemonGarden
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class Village : Page
	{
		private int xPos, yPos, xMin, xMax, yMin, yMax;

		public int XPos
		{
			get
			{
				return this.xPos;
			}
		}

		public int YPos
		{
			get
			{
				return this.yPos;
			}
		}

		public int XMin
		{
			get
			{
				return xMin;
			}
		}

		public int XMax
		{
			get
			{
				return xMax;
			}
		}

		public int YMin
		{
			get
			{
				return yMin;
			}
		}

		public int YMax
		{
			get
			{
				return yMax;
			}
		}

		public Village()
		{
			this.InitializeComponent();
			new VillageViewModel(this);
		}

		/// <summary>
		/// initialize caracter position
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void Init(int xPos, int yPos, int xMin, int xMax, int yMin, int yMax)
		{
			this.xPos = xPos;
			this.yPos = yPos;
			this.xMin = xMin;
			this.xMax = xMax;
			this.yMin = yMin;
			this.yMax = yMax;
			Grid.SetColumn(this.me, xPos);
			Grid.SetRow(this.me, yPos);
		}

		/// <summary>
		/// move the img caracter
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void MoveCaracterTo(int xPos, int yPos)
		{
			if (this.xPos != xPos && xPos >= this.xMin && xPos <= this.xMax)
			{
				Grid.SetColumn(this.me, xPos);
				this.xPos = xPos;
			}
			if (this.yPos != yPos && yPos >= this.xMin && yPos <= this.xMax)
			{
				Grid.SetRow(this.me, yPos);
				this.yPos = yPos;
			}
		}

		public void OnKeyDown(KeyEventHandler onKeyDown)
		{
			Window.Current.Content.KeyDown += onKeyDown;
		}

		public void UnMapKeyDown(KeyEventHandler onKeyDown)
		{
			Window.Current.Content.KeyDown -= onKeyDown;
		}
	}
}
