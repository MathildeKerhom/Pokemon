using PokemonGarden.Classes;
using PokemonGarden.View;
using PokemonGarden.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PokemonGarden.ViewModel
{
	class ArenaViewModel
	{
		private Arena arena;
		private Player player;

		public ArenaViewModel(Arena arena)
		{
			this.player = Player.GetPlayer;
			this.arena = arena;
			this.init();
			this.bind();
		}

		private void init()
		{
			this.arena.PokemonAI.DataContext = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<ElementType> { ElementType.Electrique }, "fidel pokemon qui nous suit partout", "Transparent");
			if (this.player.FightingList.Length != 5)
			{
				throw new InvalidOperationException("Fighting list haven't 5 elements inner tab");
			}
			for (int i = 0; i < this.player.FightingList.Length; i++)
			{
				pokemonDropInto(i + 1, this.player.FightingList[i] as Pokemon);
			}
		}

		private void bind()
		{
			this.arena.PokemonPlayer.AllowDrop = true;
			this.arena.PokemonPlayer.Drop += pokemon_Drop;
			this.arena.PokemonPlayer.DragEnter += pokemon_DragEnter;
			this.arena.PokemonPlayer.DragLeave += pokemon_DragLeave;

			this.arena.Pokemon1.CanDrag = true;
			this.arena.Pokemon1.DragStarting += pokemon_DragItemsStarting;

			this.arena.Pokemon2.CanDrag = true;
			this.arena.Pokemon2.DragStarting += pokemon_DragItemsStarting;

			this.arena.Pokemon3.CanDrag = true;
			this.arena.Pokemon3.DragStarting += pokemon_DragItemsStarting;

			this.arena.Pokemon4.CanDrag = true;
			this.arena.Pokemon4.DragStarting += pokemon_DragItemsStarting;

			this.arena.Pokemon5.CanDrag = true;
			this.arena.Pokemon5.DragStarting += pokemon_DragItemsStarting;

			(Window.Current.Content as Frame).Navigating += this.onChangingFrame;
		}

		private void onChangingFrame(object sender, NavigatingCancelEventArgs e)
		{
			this.arena.PokemonPlayer.Drop -= pokemon_Drop;
			this.arena.PokemonPlayer.DragEnter -= pokemon_DragEnter;
			this.arena.PokemonPlayer.DragLeave -= pokemon_DragLeave;

			this.arena.Pokemon1.DragStarting -= pokemon_DragItemsStarting;

			this.arena.Pokemon2.DragStarting -= pokemon_DragItemsStarting;

			this.arena.Pokemon3.DragStarting -= pokemon_DragItemsStarting;

			this.arena.Pokemon4.DragStarting -= pokemon_DragItemsStarting;

			this.arena.Pokemon5.DragStarting -= pokemon_DragItemsStarting;

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;
		}

		private void pokemon_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void pokemon_DragEnter(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
		}

		private void pokemon_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.DataView.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				(pokemon as Pokemon).SetBackgroundToTransparent();
				this.arena.PokemonPlayer.DataContext = (Pokemon)pokemon;
			}
		}

		private void pokemon_DragItemsStarting(object sender, DragStartingEventArgs e)
		{
			object item = (sender as PokemonDisplay).DataContext;
			if (item != null)
			{
				e.Data.Properties.Add("pokemonSource", item);
			}
		}

		/// <summary>
		/// drop a pokemon inside fighting block
		/// </summary>
		/// <param name="dropId">block id to pokemon fight list</param>
		/// <param name="pokemonToDrop">pokemon to drop</param>
		private void pokemonDropInto(int dropId, Pokemon pokemonToDrop)
		{
			if (pokemonToDrop != null)
			{
				switch (dropId)
				{
					case 1:
						this.arena.Pokemon1.DataContext = pokemonToDrop as Pokemon;
						break;
					case 2:
						this.arena.Pokemon2.DataContext = pokemonToDrop as Pokemon;
						break;
					case 3:
						this.arena.Pokemon3.DataContext = pokemonToDrop as Pokemon;
						break;
					case 4:
						this.arena.Pokemon4.DataContext = pokemonToDrop as Pokemon;
						break;
					case 5:
						this.arena.Pokemon5.DataContext = pokemonToDrop as Pokemon;
						break;
				}
			}
		}
	}
}
