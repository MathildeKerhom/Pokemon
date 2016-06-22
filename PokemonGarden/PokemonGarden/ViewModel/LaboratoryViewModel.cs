using System;
using PokemonGarden.Classes;
using PokemonGarden.View;
using Windows.UI.Xaml;

namespace PokemonGarden.ViewModel
{
	public class LaboratoryViewModel
	{
		private Laboratory laboratory;

		public LaboratoryViewModel(Laboratory laboratory)
		{
			this.laboratory = laboratory;
			bindEvents();
		}

		private void bindEvents()
		{
			this.laboratory.FusionBlockLeft.DragLeave += seed_DragLeave;
			this.laboratory.FusionBlockLeft.DragEnter += seed_DragEnter;
			this.laboratory.FusionBlockLeft.Drop += seedLeft_Drop;
			this.laboratory.FusionBlockLeft.AllowDrop = true;

			this.laboratory.FusionBlockRight.DragLeave += seed_DragLeave;
			this.laboratory.FusionBlockRight.DragEnter += seed_DragEnter;
			this.laboratory.FusionBlockRight.Drop += seedRight_Drop;
			this.laboratory.FusionBlockRight.AllowDrop = true;

			this.laboratory.UpgradeBlockLeft.DragLeave += pokemon_DragLeave;
			this.laboratory.UpgradeBlockLeft.DragEnter += pokemon_DragEnter;
			this.laboratory.UpgradeBlockLeft.Drop += pokemonFusion_Drop;
			this.laboratory.UpgradeBlockLeft.AllowDrop = true;

			this.laboratory.UpgradeBlockRight.DragLeave += seed_DragLeave;
			this.laboratory.UpgradeBlockRight.DragEnter += seed_DragEnter;
			this.laboratory.UpgradeBlockRight.Drop += seedFusion_Drop;
			this.laboratory.UpgradeBlockRight.AllowDrop = true;
		}

		private void seed_DragEnter(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
			}
		}

		private void pokemon_DragEnter(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
			}
		}

		private void pokemon_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void seed_DragLeave(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		private void seedLeft_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.laboratory.FusionSeedBlockLeft.DataContext = seed as MarketSeed;
			}
		}

		private void seedRight_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.laboratory.FusionSeedBlockRight.DataContext = seed as MarketSeed;
			}
		}

		private void seedFusion_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				this.laboratory.UpgradeSeed.DataContext = seed as MarketSeed;
			}
		}

		private void pokemonFusion_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				this.laboratory.UpgradePokemon.DataContext = pokemon as Pokemon;
			}
		}
	}
}