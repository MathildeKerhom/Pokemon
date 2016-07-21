using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PokemonGarden.Classes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PokemonGarden
{
	public class Pokemon:ILockable
	{
		private Uri imgPokemon;
		private ObservableCollection<Types> imgTypes;
		private string name, description;
		private string backgroundColor = "LightGray";

		/// <summary>
		/// spec fight
		/// </summary>
		private int pv, att, def, attSpe, defSpe, speed, spe, level;

		private bool isBusy, isDead;

		internal Pokemon(Uri imgPokemon, string name, List<ElementType> types, string description, string backgroundColor = "LightGray")
		{
			this.name = name;
			this.imgPokemon = imgPokemon;
			setImgType(types);
			this.description = description;
			this.backgroundColor = backgroundColor;
			pv = 0;
			att = 0;
			def = 0;
			attSpe = 0;
			defSpe = 0;
			speed = 0;
			spe = 0;
			level = 1;
			this.IsEnable = true;
		}

		internal Pokemon(Uri imgPokemon, string name, List<Types> types, string description, string backgroundColor = "LightGray")
		{
			this.name = name;
			this.imgPokemon = imgPokemon;
			this.imgTypes = new ObservableCollection<Types>(types);
			this.description = description;
			this.backgroundColor = backgroundColor;
			pv = 0;
			att = 0;
			def = 0;
			attSpe = 0;
			defSpe = 0;
			speed = 0;
			spe = 0;
			level = 1;
			this.IsEnable = true;
		}

		private void setImgType(List<ElementType> types)
		{
			imgTypes = new ObservableCollection<Types>();

			foreach (ElementType item in types)
			{
				imgTypes.Add(new Types(item));
			}
		}

		public ObservableCollection<Types> GetUriTypeList
		{
			get
			{
				return this.imgTypes;
			}
		}

		public Uri Img
		{
			get
			{
				return this.imgPokemon;
			}
		}

		public int Level
		{
			get
			{
				return this.level;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public string GetBackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
		}

		public bool IsEnable { get; set; }

		public void SetBackgroundToTransparent()
		{
			this.backgroundColor = "Transparent";
		}

		public void Upgrade(Seed seed)
		{
			Types typesToAdd = new Types(Types.GetOneType(seed.GetUriTypeList));
			if (this.imgTypes.Count < 2)
			{
				foreach (Types types in this.GetUriTypeList)
				{
					if (types.ElementType == typesToAdd.ElementType)
					{
						return; // do nothing if element was already inside
					}
				}
				this.GetUriTypeList.Add(typesToAdd);
			}
			else
			{
				this.GetUriTypeList.RemoveAt(new Random(DateTime.Now.Millisecond).Next(1));
				foreach (Types types in this.GetUriTypeList)
				{
					if (types.ElementType == typesToAdd.ElementType)
					{
						return; // do nothing if element was already inside
					}
				}
				this.GetUriTypeList.Add(typesToAdd);
			}
		}
	}
}