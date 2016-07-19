using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes
{
	public class GardenSeed:Seed
	{
		private DateTime createDate;

		public GardenSeed(string name, List<ElementType> types, string description) : base(name, types, description)
		{
			this.createDate = DateTime.Now;
		}

		/// <summary>
		/// check if the seed is ready to collect
		/// </summary>
		/// <returns></returns>
		public bool IsReady()
		{
			return true;
		}
	}
}
