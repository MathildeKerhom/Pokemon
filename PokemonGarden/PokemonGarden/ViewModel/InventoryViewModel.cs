using System;
using PokemonGarden.Classes;
using PokemonGarden.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PokemonGarden.ViewModel
{
	internal class InventoryViewModel
	{
		private Inventory inventory;
		private Player player;

		public InventoryViewModel(Inventory inventory)
		{
			this.player = Player.GetPlayer;
			this.inventory = inventory;
			this.inventory.TopBar.DisableInventoryButton();
			init();
			bind();
		}

		private void init()
		{
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
			this.inventory.ContainerPokemon1.DragEnter += pokemon_DragEnter;
			this.inventory.ContainerPokemon1.DragLeave += pokemon_DragLeave;
			this.inventory.ContainerPokemon1.Drop += pokemon1_Drop;
			this.inventory.ContainerPokemon1.AllowDrop = true;

			this.inventory.ContainerPokemon2.DragEnter += pokemon_DragEnter;
			this.inventory.ContainerPokemon2.DragLeave += pokemon_DragLeave;
			this.inventory.ContainerPokemon2.Drop += pokemon2_Drop;
			this.inventory.ContainerPokemon2.AllowDrop = true;

			this.inventory.ContainerPokemon3.DragEnter += pokemon_DragEnter;
			this.inventory.ContainerPokemon3.DragLeave += pokemon_DragLeave;
			this.inventory.ContainerPokemon3.Drop += pokemon3_Drop;
			this.inventory.ContainerPokemon3.AllowDrop = true;

			this.inventory.ContainerPokemon4.DragEnter += pokemon_DragEnter;
			this.inventory.ContainerPokemon4.DragLeave += pokemon_DragLeave;
			this.inventory.ContainerPokemon4.Drop += pokemon4_Drop;
			this.inventory.ContainerPokemon4.AllowDrop = true;

			this.inventory.ContainerPokemon5.DragEnter += pokemon_DragEnter;
			this.inventory.ContainerPokemon5.DragLeave += pokemon_DragLeave;
			this.inventory.ContainerPokemon5.Drop += pokemon5_Drop;
			this.inventory.ContainerPokemon5.AllowDrop = true;

			(Window.Current.Content as Frame).Navigating += this.onChangingFrame;
		}

		private void onChangingFrame(object sender, NavigatingCancelEventArgs e)
		{
			this.inventory.ContainerPokemon1.DragEnter -= pokemon_DragEnter;
			this.inventory.ContainerPokemon1.DragLeave -= pokemon_DragLeave;
			this.inventory.ContainerPokemon1.Drop -= pokemon1_Drop;

			this.inventory.ContainerPokemon2.DragEnter -= pokemon_DragEnter;
			this.inventory.ContainerPokemon2.DragLeave -= pokemon_DragLeave;
			this.inventory.ContainerPokemon2.Drop -= pokemon2_Drop;

			this.inventory.ContainerPokemon3.DragEnter -= pokemon_DragEnter;
			this.inventory.ContainerPokemon3.DragLeave -= pokemon_DragLeave;
			this.inventory.ContainerPokemon3.Drop -= pokemon3_Drop;

			this.inventory.ContainerPokemon4.DragEnter -= pokemon_DragEnter;
			this.inventory.ContainerPokemon4.DragLeave -= pokemon_DragLeave;
			this.inventory.ContainerPokemon4.Drop -= pokemon4_Drop;

			this.inventory.ContainerPokemon5.DragEnter -= pokemon_DragEnter;
			this.inventory.ContainerPokemon5.DragLeave -= pokemon_DragLeave;
			this.inventory.ContainerPokemon5.Drop -= pokemon5_Drop;

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;

			for (int i = 0; i < this.player.FightingList.Length; i++)
			{
				this.player.FightingList[i] = getFightingPokemon(i + 1);
			}
		}

		private void pokemon_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void pokemon_DragEnter(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
		}

		private void pokemon1_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.inventory.Pokemon1.DataContext = pokemon as Pokemon;
			}
		}

		private void pokemon2_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.inventory.Pokemon2.DataContext = pokemon as Pokemon;
			}
		}

		private void pokemon3_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.inventory.Pokemon3.DataContext = pokemon as Pokemon;
			}
		}

		private void pokemon4_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.inventory.Pokemon4.DataContext = pokemon as Pokemon;
			}
		}

		private void pokemon5_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.inventory.Pokemon5.DataContext = pokemon as Pokemon;
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
						this.inventory.Pokemon1.DataContext = pokemonToDrop as Pokemon;
						break;
					case 2:
						this.inventory.Pokemon2.DataContext = pokemonToDrop as Pokemon;
						break;
					case 3:
						this.inventory.Pokemon3.DataContext = pokemonToDrop as Pokemon;
						break;
					case 4:
						this.inventory.Pokemon4.DataContext = pokemonToDrop as Pokemon;
						break;
					case 5:
						this.inventory.Pokemon5.DataContext = pokemonToDrop as Pokemon;
						break;
				}
			}
		}

		/// <summary>
		/// reverse of pokemonDropInto methode
		/// </summary>
		/// <param name="blockId">block id to pokemon fight list</param>
		/// <returns></returns>
		private Pokemon getFightingPokemon(int blockId)
		{
			switch (blockId)
			{
				case 1:
					return this.inventory.Pokemon1.DataContext as Pokemon;
				case 2:
					return this.inventory.Pokemon2.DataContext as Pokemon;
				case 3:
					return this.inventory.Pokemon3.DataContext as Pokemon;
				case 4:
					return this.inventory.Pokemon4.DataContext as Pokemon;
				case 5:
					return this.inventory.Pokemon5.DataContext as Pokemon;
				default:
					return null;
			}
		}
	}
}