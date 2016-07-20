using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace PokemonGarden.Classes
{
	public class MarketSeed:Seed, ILockable
	{
		private int price;

		public MarketSeed()
		{

		}

		public MarketSeed(string name, List<ElementType> types, string description, int price) : base(name, types, description)
		{
			this.price = price;
			this.IsEnable = true;
		}

		[ForeignKey(typeof(Player))]
		public int PlayerId
		{
			get; set;
		}

		/// <summary>
		/// return "{TotalPrice} Pc"
		/// </summary>
		[Ignore]
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

		[Ignore]
		public bool IsEnable
		{
			get;
			set;
		}
	}
}