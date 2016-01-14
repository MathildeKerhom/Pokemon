using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PokemonGarden
{
	internal class Pokemon
	{
		private Uri imgPokemon;
		private List<Types> imgTypes;
		private string name, description;

		/// <summary>
		/// spec fight
		/// </summary>
		private int pv, att, def, attSpe, defSpe, speed, spe, level;


		internal Pokemon(Uri imgPokemon, string name, List<Types.Element> types, string description)
		{
			this.name = name;
			this.imgPokemon = imgPokemon;
			setImgType(types);
			this.description = description;
			pv = 0;
			att = 0;
			def = 0;
			attSpe = 0;
			defSpe = 0;
			speed = 0;
			spe = 0;
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

        public Uri Img
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
	}
}