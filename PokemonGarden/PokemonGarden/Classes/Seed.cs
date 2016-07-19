using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using Windows.UI.Xaml.Controls;

namespace PokemonGarden
{
	public abstract class Seed
	{
		private List<Types> imgTypes;
		private string name, description;
		private Uri seedImg = new Uri("ms-appx:///Assets/Graine_DM.png");
		private string backgroundColor = "LightGray";

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

		public List<Types> GetUriTypeList
		{
			get
			{
				return this.imgTypes;
			}
		}

		public Uri GetSeedImg
		{
			get
			{
				return this.seedImg;
			}
		}

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
		}

		public string Description
		{
			get
			{
				return this.description;
			}
		}

		public int Quantity
		{
			get;
			set;
		}
	}
}