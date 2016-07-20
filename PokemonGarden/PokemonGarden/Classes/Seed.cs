using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using SQLite.Net.Attributes;
using Windows.UI.Xaml.Controls;

namespace PokemonGarden
{
	public abstract class Seed: EntityBase
	{
		private List<Types> imgTypes;
		private string name, description;
		private Uri seedImg = new Uri("ms-appx:///Assets/Graine_DM.png");
		private string backgroundColor = "LightGray";

		public Seed()
		{

		}

		public Seed(string name, List<ElementType> types, string description)
		{
			this.name = name;
			setImgType(types);
			this.description = description;
		}

		private void setImgType(List<ElementType> types)
		{
			imgTypes = new List<Types>();

			foreach (ElementType item in types)
			{
				imgTypes.Add(new Types(item));
			}
		}

		[Ignore]
		public List<Types> GetUriTypeList
		{
			get
			{
				return this.imgTypes;
			}
		}

		[Ignore]
		public Uri GetSeedImg
		{
			get
			{
				return this.seedImg;
			}
		}

		[Ignore]
		public string GetBackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
		}

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

		public int Quantity
		{
			get;
			set;
		}
	}
}