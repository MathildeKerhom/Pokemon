using System.Collections.Generic;

namespace PokemonGarden.Classes
{
	public class MarketSeed:Seed
	{
		private int price;

		public MarketSeed(string name, List<Types.Element> types, string description, int price) : base(name, types, description)
		{
			this.price = price;
		}

		/// <summary>
		/// return "{TotalPrice} Pc"
		/// </summary>
		public string PriceQuantity
		{
			get
			{
				if (Quantity == 0)
				{
					return $"-- Pc";
				}
				else
				{
					return $"{ Quantity * this.price } Pc";
				}
			}
		}

		/// <summary>
		/// price of the seed
		/// </summary>
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