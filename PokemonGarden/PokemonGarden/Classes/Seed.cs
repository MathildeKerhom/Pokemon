using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using Windows.UI.Xaml.Controls;

namespace PokemonGarden
{
	class Seed
	{
		private List<Types> imgTypes;
		private string name, description;
		private int price;

		public Seed(string name, List<Types.Element> types, string description, int price)
		{
			this.name = name;
			setImgType(types);
			this.description = description;
			this.price = price;
		}

		private void setImgType(List<Types.Element> types)
		{
			imgTypes = new List<Types>();

			foreach (Types.Element item in types)
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

		public string PriceQuantity
		{
			get
			{
				return $"Qté : { Quantity * this.price }";
			}
		}

		public int Price
		{
			get
			{
				return this.price;
			}

			set
			{
				this.price = value;
			}
		}
	}
}