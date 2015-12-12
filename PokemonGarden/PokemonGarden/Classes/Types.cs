using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes
{
	public class Types
	{
		public enum Element { Acier, Combat, Dragon, Eau, Electrique, Fee, Feu, Glace, Insecte, Normal, Plante, Poison, Psy, Roche, Sol, Spectre, Tenebres, Vol };

		private Uri uriType;

		public Types(Element element)
		{
			uriType = getUri(element);
		}

		private Uri getUri(Element nameType)
		{
			switch (nameType)
			{
				case Element.Acier: return new Uri("ms-appx:///Assets/Type_miniat_acier.png");
				case Element.Combat: return new Uri("ms-appx:///Assets/Type_miniat_combat.png");
				case Element.Dragon: return new Uri("ms-appx:///Assets/Type_miniat_dragon.png");
				case Element.Eau: return new Uri("ms-appx:///Assets/Type_miniat_eau.png");
				case Element.Electrique: return new Uri("ms-appx:///Assets/Type_miniat_electrique.png");
				case Element.Fee: return new Uri("ms-appx:///Assets/Type_miniat_fee.png");
				case Element.Feu: return new Uri("ms-appx:///Assets/Type_miniat_feu.png");
				case Element.Glace: return new Uri("ms-appx:///Assets/Type_miniat_glace.png");
				case Element.Insecte: return new Uri("ms-appx:///Assets/Type_miniat_insecte.png");
				case Element.Normal: return new Uri("ms-appx:///Assets/Type_miniat_normal.png");
				case Element.Plante: return new Uri("ms-appx:///Assets/Type_miniat_plante.png");
				case Element.Poison: return new Uri("ms-appx:///Assets/Type_miniat_poison.png");
				case Element.Psy: return new Uri("ms-appx:///Assets/Type_miniat_psy.png");
				case Element.Roche: return new Uri("ms-appx:///Assets/Type_miniat_roche.png");
				case Element.Sol: return new Uri("ms-appx:///Assets/Type_miniat_sol.png");
				case Element.Spectre: return new Uri("ms-appx:///Assets/Type_miniat_spectre.png");
				case Element.Tenebres: return new Uri("ms-appx:///Assets/Type_miniat_tenebres.png");
				case Element.Vol: return new Uri("ms-appx:///Assets/Type_miniat_vol.png");
				default: return new Uri("ms-appx:///Assets/pokeball.jpg");
			}
		}

		public Uri GetUri
		{
			get
			{
				return uriType;
			}
		}
	}
}
