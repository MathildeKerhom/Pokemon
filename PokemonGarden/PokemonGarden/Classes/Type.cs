using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes
{
	public static class Type
	{
		public enum Types { Acier, Combat, Dragon, Eau, Electrique, Fee, Feu, Glace, Insecte, Normal, Plante, Poison, Psy, Roche, Sol, Spectre, Tenebres, Vol };

		public static Uri GetUri(Types nameType)
		{
			switch (nameType)
			{
				case Types.Acier:
					return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Combat: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Dragon: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Eau: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Electrique: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Fee: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Feu: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Glace: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Insecte: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Normal: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Plante: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Poison: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Psy: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Roche: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Sol: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Spectre: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Tenebres: return new Uri("ms-appx:///Assets/pokeball.jpg");
				case Types.Vol: return new Uri("ms-appx:///Assets/pokeball.jpg");
				default: return new Uri("ms-appx:///Assets/pokeball.jpg");
			}
		}
	}
}
