using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using PokemonGarden.Classes.AutoGenerator;
using PokemonGarden.Classes.AutoGenerator.Attributs;
using SQLite.Net.Attributes;
using Windows.UI.Xaml.Controls;

namespace PokemonGarden
{
	public abstract class Seed : EntityBase, ILockable
	{
		private List<Types> imgTypes;
		private string name, description;
		private Uri seedImg = new Uri("ms-appx:///Assets/Graine_DM.png");
		private string backgroundColor = "LightGray";

		public Seed()
		{
			this.IsEnable = true;
		}

		public Seed(string name, List<ElementType> types, string description)
		{
			this.name = name;
			RemplaceElementType(types);
			this.description = description;
			this.IsEnable = true;
		}

		/// <summary>
		/// update types
		/// </summary>
		public void RemplaceElementType(List<ElementType> types)
		{
			imgTypes = new List<Types>();

			foreach (ElementType item in types)
			{
				Types tmpTypes = new Types(item);
				if (!imgTypes.Contains(tmpTypes))
				{
					imgTypes.Add(tmpTypes);
				}
			}
		}

		/// <summary>
		/// element type of seed (can't to be have same element)
		/// </summary>
		[Ignore]
		[FakerTyper(SpecificFakerType.ListItemMin1Max2)]
		public List<Types> UriTypeList
		{
			get
			{
				return this.imgTypes;
			}
			set
			{
				if (value != null)
				{
					this.imgTypes = new List<Types>();
					foreach (Types item in value)
					{
						if (!this.imgTypes.Exists(x => x.ElementType == item.ElementType))
						{
							this.imgTypes.Add(item);
						}
					}
				}
				else
				{
					this.imgTypes = null;
				}
			}
		}

		[Ignore]
		[FakerTyper(SpecificFakerType.IGNORE)]
		public Uri GetSeedImg
		{
			get
			{
				return this.seedImg;
			}
		}

		[Ignore]
		[FakerTyper(SpecificFakerType.IGNORE)]
		public string GetBackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
		}

		[FakerTyper(SpecificFakerType.FirstName)]
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		[FakerTyper(SpecificFakerType.Description)]
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		[FakerTyper(SpecificFakerType.IGNORE)]
		public int Quantity
		{
			get;
			set;
		}

		[Ignore]
		[FakerTyper(SpecificFakerType.IGNORE)]
		public bool IsEnable
		{
			get;
			set;
		}
	}
}