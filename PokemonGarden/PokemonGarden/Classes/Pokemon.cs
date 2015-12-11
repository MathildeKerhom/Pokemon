using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PokemonGarden
{
	internal class Pokemon
	{
		private Uri img;
		private string name;
		/// <summary>
		/// spec fight
		/// </summary>
		private int pv, att, def, attSpe, defSpe, speed, spe;



		Pokemon(Uri imgLink, string name)
		{
			img = imgLink;
		}
	}
}