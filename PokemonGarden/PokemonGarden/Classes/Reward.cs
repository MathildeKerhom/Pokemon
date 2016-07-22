using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGarden.Classes.AutoGenerator;
using PokemonGarden.Classes.AutoGenerator.Attributs;

namespace PokemonGarden.Classes
{
	public class Reward
	{
		public const int Max = 150;

		private List<MarketSeed> testAutoGen;

		[FakerTyper(SpecificFakerType.IGNORE)]
		public List<MarketSeed> TestAutoGen
		{
			get
			{
				return testAutoGen;
			}
			set
			{
				testAutoGen = value;
			}
		}

		public Reward()
		{
		}
	}
}
