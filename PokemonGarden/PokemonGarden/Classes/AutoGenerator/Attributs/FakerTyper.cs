using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGarden.Classes.AutoGenerator.Attributs
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
	public class FakerTyper : Attribute
	{
		private SpecificFakerType fakerType;

		public SpecificFakerType FakerType
		{
			get
			{
				return this.fakerType;
			}
		}

		public FakerTyper(SpecificFakerType customFakerType)
		{
			this.fakerType = customFakerType;
		}

		public override string ToString()
		{
			return Enum.GetName(typeof(SpecificFakerType), this.fakerType);
		}
	}
}
