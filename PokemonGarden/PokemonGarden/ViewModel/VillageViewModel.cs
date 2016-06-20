using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGarden.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PokemonGarden.ViewModel
{
	public class VillageViewModel
	{
		Village village;

		public VillageViewModel(Village village)
		{
			this.village = village;
			this.village.Init(5, 6, 0, 9, 0, 9);
			// set keyDown event to currentWindow
			this.village.OnKeyDown(Content_KeyDown);
		}

		private void Content_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			switch (e.Key)
			{
				case Windows.System.VirtualKey.Left:
				case Windows.System.VirtualKey.Q:
					this.village.MoveCaracterTo(this.village.XPos - 1, this.village.YPos);
					break;
				case Windows.System.VirtualKey.Right:
				case Windows.System.VirtualKey.D:
					this.village.MoveCaracterTo(this.village.XPos + 1, this.village.YPos);
					break;
				case Windows.System.VirtualKey.Up:
				case Windows.System.VirtualKey.Z:
					this.village.MoveCaracterTo(this.village.XPos, this.village.YPos - 1);
					break;
				case Windows.System.VirtualKey.Down:
				case Windows.System.VirtualKey.S:
					this.village.MoveCaracterTo(this.village.XPos, this.village.YPos + 1);
					break;
			}

			executNavigate();
		}

		private void executNavigate()
		{
			if (this.village.XPos <= 1 && this.village.YPos <= 1)
			{
				navigateTo(typeof(Market));
			}
			else if (this.village.XPos >= 3 && this.village.XPos <= 5 && this.village.YPos >= 2 && this.village.YPos <= 4)
			{
				navigateTo(typeof(Garden));
			}
			else if ((this.village.XPos == 8 && (this.village.YPos == 4 || this.village.YPos == 5)) || (this.village.XPos == 9 && this.village.YPos == 5))
			{
				navigateTo(typeof(Laboratory));
			}
			else if (this.village.XPos == 2 && this.village.YPos == 8)
			{
				navigateTo(typeof(Arena));
			}
		}

		private void market_Click(object sender, RoutedEventArgs e)
		{

		}

		private void market_Tapped(object sender, TappedRoutedEventArgs e)
		{
			navigateTo(typeof(Garden));
		}

		private void navigateTo(Type type)
		{
			this.village.UnMapKeyDown(Content_KeyDown);
			(Window.Current.Content as Frame).Navigate(type);
		}
	}
}
