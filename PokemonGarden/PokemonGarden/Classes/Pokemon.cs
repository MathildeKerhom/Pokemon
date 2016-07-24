using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PokemonGarden.Classes;
using PokemonGarden.Classes.AutoGenerator;
using PokemonGarden.Classes.AutoGenerator.Attributs;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PokemonGarden
{
	public class Pokemon : ILockable
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

		public Pokemon()
		{
			level = 1;
			this.IsEnable = true;
		}

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

		/// <summary>
		/// used to auto generate element type by class generator
		/// </summary>
		/// <param name="types"></param>
		[FakerTyper(SpecificFakerType.ListItemMin1Max2)]
		public List<Types> ImgType
		{
			set
			{
				if (value != null)
				{
					this.imgTypes = new ObservableCollection<Types>();
					List<Types> checkList = new List<Types>();
					foreach (Types item in value)
					{
						if (!checkList.Exists(x => x.ElementType == item.ElementType))
						{
							this.imgTypes.Add(item);
							checkList.Add(item);
						}
					}
				}
				else
				{
					this.imgTypes = null;
				}
			}
		}
		
		public ObservableCollection<Types> UriTypeList
		{
			get
			{
				return this.imgTypes;
			}
		}

		[FakerTyper(SpecificFakerType.PokemonImg)]
		public Uri Img
		{
			get
			{
				return this.imgPokemon;
			}
			set
			{
				this.imgPokemon = value;
			}
		}

		public int Level
		{
			get
			{
				return this.level;
			}
		}

		[FakerTyper(SpecificFakerType.FirstName)]
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

		public string BackgroundColor
		{
			get
			{
				return this.backgroundColor;
			}
		}

		[FakerTyper(SpecificFakerType.IGNORE)]
		public bool IsEnable
		{
			get; set;
		}

		public void SetBackgroundToTransparent()
		{
			this.backgroundColor = "Transparent";
		}

		private void setImgType(List<ElementType> types)
		{
			imgTypes = new ObservableCollection<Types>();

			foreach (ElementType item in types)
			{
				imgTypes.Add(new Types(item));
			}
		}

		public void Upgrade(Seed seed)
		{
			Types typesToAdd = new Types(Types.GetOneType(seed.UriTypeList));
			if (this.imgTypes.Count < 2)
			{
				foreach (Types types in this.UriTypeList)
				{
					if (types.ElementType == typesToAdd.ElementType)
					{
						return; // do nothing if element was already inside
					}
				}
				this.UriTypeList.Add(typesToAdd);
			}
			else
			{
				this.UriTypeList.RemoveAt(new Random(DateTime.Now.Millisecond).Next(1));
				foreach (Types types in this.UriTypeList)
				{
					if (types.ElementType == typesToAdd.ElementType)
					{
						return; // do nothing if element was already inside
					}
				}
				this.UriTypeList.Add(typesToAdd);
			}
		}
	}
}