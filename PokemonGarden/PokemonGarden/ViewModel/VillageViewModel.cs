using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGarden.View;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PokemonGarden.ViewModel
{
	public class VillageViewModel
	{
		private int xPos, yPos, xMin, xMax, yMin, yMax;
		private Village village;

		public VillageViewModel(Village village)
		{
			this.village = village;
			this.init();
			// set keyDown event to currentWindow
			Window.Current.Content.KeyDown += Content_KeyDown;
		}

		/// <summary>
		/// initialize view
		/// </summary>
		private void init()
		{
			this.xPos = 5;
			this.yPos = 6;
			this.xMin = 0;
			this.xMax = 9;
			this.yMin = 0;
			this.yMax = 9;

			Grid.SetColumn(this.village.Me, this.xPos);
			Grid.SetRow(this.village.Me, this.yPos);
		}

		private void Content_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			switch (e.Key)
			{
				case Windows.System.VirtualKey.Left:
				case Windows.System.VirtualKey.Q:
					this.moveCaracterTo(this.xPos - 1, this.yPos);
					break;
				case Windows.System.VirtualKey.Right:
				case Windows.System.VirtualKey.D:
					this.moveCaracterTo(this.xPos + 1, this.yPos);
					break;
				case Windows.System.VirtualKey.Up:
				case Windows.System.VirtualKey.Z:
					this.moveCaracterTo(this.xPos, this.yPos - 1);
					break;
				case Windows.System.VirtualKey.Down:
				case Windows.System.VirtualKey.S:
					this.moveCaracterTo(this.xPos, this.yPos + 1);
					break;
			}

			executNavigate();
		}

		/// <summary>
		/// navigate to the view when user reach it
		/// </summary>
		private void executNavigate()
		{
			if (this.xPos <= 1 && this.yPos <= 1)
			{
				navigateTo(typeof(Market));
			}
			else if (this.xPos >= 3 && this.xPos <= 5 && this.yPos >= 2 && this.yPos <= 4)
			{
				navigateTo(typeof(Garden));
			}
			else if ((this.xPos == 8 && (this.yPos == 4 || this.yPos == 5)) || (this.xPos == 9 && this.yPos == 5))
			{
				navigateTo(typeof(Laboratory));
			}
			else if (this.xPos == 2 && this.yPos == 8)
			{
				navigateTo(typeof(Arena));
			}
		}

		/// <summary>
		/// move the img caracter
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		private void moveCaracterTo(int xPos, int yPos)
		{
			if (this.xPos != xPos && xPos >= this.xMin && xPos <= this.xMax)
			{
				Grid.SetColumn(this.village.Me, xPos);
				this.xPos = xPos;
			}
			if (this.yPos != yPos && yPos >= this.yMin && yPos <= this.yMax)
			{
				Grid.SetRow(this.village.Me, yPos);
				this.yPos = yPos;
			}
		}

		/// <summary>
		/// go to precise view
		/// </summary>
		/// <param name="type"></param>
		private void navigateTo(Type type)
		{
			Window.Current.Content.KeyDown -= Content_KeyDown;
			(Window.Current.Content as Frame).Navigate(type);
		}
	}
}
