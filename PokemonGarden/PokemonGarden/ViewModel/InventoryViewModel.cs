using System;
using PokemonGarden.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PokemonGarden.ViewModel
{
	internal class InventoryViewModel
	{
		private Inventory inventory;

		public InventoryViewModel(Inventory inventory)
		{
			this.inventory = inventory;
			this.inventory.TopBar.DisableInventoryButton();
			bind();
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
	}
}