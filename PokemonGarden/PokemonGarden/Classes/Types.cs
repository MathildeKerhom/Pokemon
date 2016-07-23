using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGarden.Classes.AutoGenerator;
using PokemonGarden.Classes.AutoGenerator.Attributs;

namespace PokemonGarden.Classes
{
	public enum ElementType
	{
		Normal,
		Plante,
		Electrique,
		Eau,
		Feu,
		Insecte,
		Spectre,
		Psy,
		Acier,
		Tenebres,
		Vol,
		Glace,
		Poison,
		Sol,
		Roche,
		Dragon,
		Combat,
		Fee,
		None
	}

	public class Types
	{
		//The given type is defending
		//ie: normal.weak would have fighting
		private static readonly ElementType[][] weak, strong, noEffect; //TODO fill noEffect

		// to chose a random type
		private static Random random = new Random(DateTime.Now.Millisecond);

		static Types()
		{
			weak = new ElementType[Enum.GetValues(typeof(ElementType)).Length][];
			strong = new ElementType[Enum.GetValues(typeof(ElementType)).Length][];
			noEffect = new ElementType[Enum.GetValues(typeof(ElementType)).Length][];

			weak[(int)ElementType.Normal] = new ElementType[] { ElementType.Combat };
			strong[(int)ElementType.Normal] = new ElementType[] { };
			noEffect[(int)ElementType.Normal] = new ElementType[] { ElementType.Spectre };
			//Grass
			weak[(int)ElementType.Plante] = new ElementType[] { ElementType.Vol, ElementType.Poison, ElementType.Insecte, ElementType.Feu, ElementType.Glace };
			strong[(int)ElementType.Plante] = new ElementType[] { ElementType.Sol, ElementType.Eau, ElementType.Plante, ElementType.Electrique };
			noEffect[(int)ElementType.Plante] = new ElementType[] { };
			//Electric
			weak[(int)ElementType.Electrique] = new ElementType[] { ElementType.Sol };
			strong[(int)ElementType.Electrique] = new ElementType[] { ElementType.Vol, ElementType.Acier, ElementType.Electrique };
			noEffect[(int)ElementType.Electrique] = new ElementType[] { };
			//Water
			weak[(int)ElementType.Eau] = new ElementType[] { ElementType.Plante, ElementType.Electrique };
			strong[(int)ElementType.Eau] = new ElementType[] { ElementType.Acier, ElementType.Feu, ElementType.Eau, ElementType.Glace };
			noEffect[(int)ElementType.Eau] = new ElementType[] { };
			//Fire
			weak[(int)ElementType.Feu] = new ElementType[] { ElementType.Sol, ElementType.Roche, ElementType.Eau };
			strong[(int)ElementType.Feu] = new ElementType[] { ElementType.Insecte, ElementType.Acier, ElementType.Feu, ElementType.Plante, ElementType.Glace, ElementType.Fee };
			noEffect[(int)ElementType.Feu] = new ElementType[] { };
			//Bug
			weak[(int)ElementType.Insecte] = new ElementType[] { ElementType.Vol, ElementType.Roche, ElementType.Feu };
			strong[(int)ElementType.Insecte] = new ElementType[] { ElementType.Combat, ElementType.Sol, ElementType.Plante };
			noEffect[(int)ElementType.Insecte] = new ElementType[] { };
			//Ghost
			weak[(int)ElementType.Spectre] = new ElementType[] { ElementType.Spectre, ElementType.Tenebres };
			strong[(int)ElementType.Spectre] = new ElementType[] { ElementType.Poison, ElementType.Insecte };
			noEffect[(int)ElementType.Spectre] = new ElementType[] { ElementType.Normal, ElementType.Combat };
			//Psychic
			weak[(int)ElementType.Psy] = new ElementType[] { ElementType.Insecte, ElementType.Spectre, ElementType.Tenebres };
			strong[(int)ElementType.Psy] = new ElementType[] { ElementType.Combat, ElementType.Psy };
			noEffect[(int)ElementType.Psy] = new ElementType[] { };
			//Steel
			weak[(int)ElementType.Acier] = new ElementType[] { ElementType.Combat, ElementType.Sol, ElementType.Feu };
			strong[(int)ElementType.Acier] = new ElementType[] { ElementType.Normal, ElementType.Vol, ElementType.Roche, ElementType.Insecte, ElementType.Acier, ElementType.Plante, ElementType.Psy, ElementType.Glace, ElementType.Dragon, ElementType.Fee };
			noEffect[(int)ElementType.Acier] = new ElementType[] { ElementType.Poison };
			//Dark
			weak[(int)ElementType.Tenebres] = new ElementType[] { ElementType.Combat, ElementType.Insecte, ElementType.Fee };
			strong[(int)ElementType.Tenebres] = new ElementType[] { ElementType.Spectre, ElementType.Tenebres };
			noEffect[(int)ElementType.Tenebres] = new ElementType[] { ElementType.Psy };
			//Flying
			weak[(int)ElementType.Vol] = new ElementType[] { ElementType.Roche, ElementType.Electrique, ElementType.Glace };
			strong[(int)ElementType.Vol] = new ElementType[] { ElementType.Combat, ElementType.Insecte, ElementType.Plante };
			noEffect[(int)ElementType.Vol] = new ElementType[] { ElementType.Sol };
			//Ice
			weak[(int)ElementType.Glace] = new ElementType[] { ElementType.Combat, ElementType.Roche, ElementType.Acier, ElementType.Feu };
			strong[(int)ElementType.Glace] = new ElementType[] { ElementType.Glace };
			noEffect[(int)ElementType.Glace] = new ElementType[] { };
			//Poison
			weak[(int)ElementType.Poison] = new ElementType[] { ElementType.Sol, ElementType.Psy };
			strong[(int)ElementType.Poison] = new ElementType[] { ElementType.Combat, ElementType.Poison, ElementType.Plante, ElementType.Fee };
			noEffect[(int)ElementType.Poison] = new ElementType[] { };
			//Ground
			weak[(int)ElementType.Sol] = new ElementType[] { ElementType.Eau, ElementType.Plante, ElementType.Glace };
			strong[(int)ElementType.Sol] = new ElementType[] { ElementType.Poison, ElementType.Roche };
			noEffect[(int)ElementType.Sol] = new ElementType[] { ElementType.Electrique };
			//Rock
			weak[(int)ElementType.Roche] = new ElementType[] { ElementType.Combat, ElementType.Sol, ElementType.Acier, ElementType.Eau, ElementType.Plante };
			strong[(int)ElementType.Roche] = new ElementType[] { ElementType.Normal, ElementType.Vol, ElementType.Poison, ElementType.Feu };
			noEffect[(int)ElementType.Roche] = new ElementType[] { };
			//Dragon
			weak[(int)ElementType.Dragon] = new ElementType[] { ElementType.Glace, ElementType.Dragon, ElementType.Fee };
			strong[(int)ElementType.Dragon] = new ElementType[] { ElementType.Feu, ElementType.Eau, ElementType.Plante, ElementType.Electrique };
			noEffect[(int)ElementType.Dragon] = new ElementType[] { };
			//Fighting
			weak[(int)ElementType.Combat] = new ElementType[] { ElementType.Vol, ElementType.Psy, ElementType.Fee };
			strong[(int)ElementType.Combat] = new ElementType[] { ElementType.Roche, ElementType.Insecte, ElementType.Tenebres };
			noEffect[(int)ElementType.Combat] = new ElementType[] { };
			//Fairy
			weak[(int)ElementType.Fee] = new ElementType[] { ElementType.Poison, ElementType.Acier };
			strong[(int)ElementType.Fee] = new ElementType[] { ElementType.Combat, ElementType.Insecte, ElementType.Tenebres };
			noEffect[(int)ElementType.Fee] = new ElementType[] { ElementType.Dragon };
			//None to avoid null reference errors
			weak[(int)ElementType.None] = new ElementType[] { };
			strong[(int)ElementType.None] = new ElementType[] { };
			noEffect[(int)ElementType.None] = new ElementType[] { };
		}

		/// <summary>
		/// obtain weak of element
		/// </summary>
		/// <param name="type">type to obtain weak</param>
		/// <returns></returns>
		public static ElementType[] GetWeak(ElementType type)
		{
			return weak[(int)type];
		}

		/// <summary>
		/// obtain strong of element
		/// </summary>
		/// <param name="type">type to obtain strong</param>
		/// <returns></returns>
		public static ElementType[] GetStrong(ElementType type)
		{
			return strong[(int)type];
		}

		/// <summary>
		/// obtain no effects of element
		/// </summary>
		/// <param name="type">type to obtain no effect</param>
		/// <returns></returns>
		public static ElementType[] GetNoEffect(ElementType type)
		{
			return noEffect[(int)type];
		}

		/// <summary>
		/// chose a random element into list of types (parent of ElementType)
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static ElementType GetOneType(List<Types> types)
		{
			List<ElementType> typeList = new List<ElementType>();

			foreach (Types type in types)
			{
				typeList.Add(type.ElementType);
			}

			return GetOneType(typeList);
		}

		/// <summary>
		/// chose a random element into list of ElementType
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static ElementType GetOneType(List<ElementType> types)
		{
			if (types.Count > 0)
			{
				return types[random.Next(types.Count)];
			}
			else
			{
				throw new ArgumentException("void list recieved");
			}
		}
		
		private ElementType elementType;

		[FakerTyper(SpecificFakerType.ElementType)]
		public ElementType ElementType
		{
			get
			{
				return elementType;
			}
			set
			{
				elementType = value;
			}
		}

		/// <summary>
		/// generate random element
		/// </summary>
		public Types()
		{
			//this.ElementType = (ElementType)Faker.RandomNumber.Next(0, Enum.GetValues(typeof(ElementType)).Length - 1);
		}

		/// <summary>
		/// generate with specified element
		/// </summary>
		/// <param name="element"></param>
		public Types(ElementType element)
		{
			this.ElementType = element;
		}

		/// <summary>
		/// return image of element
		/// </summary>
		public Uri GetUri
		{
			get
			{
				return getUri(this.elementType);
			}
		}

		/// <summary>
		/// match enum with image
		/// </summary>
		/// <param name="nameType"></param>
		/// <returns></returns>
		private Uri getUri(ElementType nameType)
		{
			switch (nameType)
			{
				case ElementType.Acier:
					return new Uri("ms-appx:///Assets/Type_miniat_acier.png");
				case ElementType.Combat:
					return new Uri("ms-appx:///Assets/Type_miniat_combat.png");
				case ElementType.Dragon:
					return new Uri("ms-appx:///Assets/Type_miniat_dragon.png");
				case ElementType.Eau:
					return new Uri("ms-appx:///Assets/Type_miniat_eau.png");
				case ElementType.Electrique:
					return new Uri("ms-appx:///Assets/Type_miniat_electrique.png");
				case ElementType.Fee:
					return new Uri("ms-appx:///Assets/Type_miniat_fee.png");
				case ElementType.Feu:
					return new Uri("ms-appx:///Assets/Type_miniat_feu.png");
				case ElementType.Glace:
					return new Uri("ms-appx:///Assets/Type_miniat_glace.png");
				case ElementType.Insecte:
					return new Uri("ms-appx:///Assets/Type_miniat_insecte.png");
				case ElementType.Normal:
					return new Uri("ms-appx:///Assets/Type_miniat_normal.png");
				case ElementType.Plante:
					return new Uri("ms-appx:///Assets/Type_miniat_plante.png");
				case ElementType.Poison:
					return new Uri("ms-appx:///Assets/Type_miniat_poison.png");
				case ElementType.Psy:
					return new Uri("ms-appx:///Assets/Type_miniat_psy.png");
				case ElementType.Roche:
					return new Uri("ms-appx:///Assets/Type_miniat_roche.png");
				case ElementType.Sol:
					return new Uri("ms-appx:///Assets/Type_miniat_sol.png");
				case ElementType.Spectre:
					return new Uri("ms-appx:///Assets/Type_miniat_spectre.png");
				case ElementType.Tenebres:
					return new Uri("ms-appx:///Assets/Type_miniat_tenebres.png");
				case ElementType.Vol:
					return new Uri("ms-appx:///Assets/Type_miniat_vol.png");
				default: // unknown
					return new Uri("ms-appx:///Assets/pokeball.jpg");
			}
		}
	}
}
