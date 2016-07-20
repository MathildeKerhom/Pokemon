using System;
using System.Collections.Generic;
using PokemonGarden.Classes;
using PokemonGarden.View;
using PokemonGarden.View.UserControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PokemonGarden.ViewModel
{
	public class LaboratoryViewModel
	{
		private Laboratory laboratory;
		private Random random;

		public LaboratoryViewModel(Laboratory laboratory)
		{
			this.laboratory = laboratory;
			this.random = new Random(DateTime.Now.Millisecond);
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

			this.laboratory.FusionBtn.Tapped += FusionBtn_Tapped;

			this.laboratory.UpgradeBlockLeft.DragLeave += pokemon_DragLeave;
			this.laboratory.UpgradeBlockLeft.DragEnter += pokemon_DragEnter;
			this.laboratory.UpgradeBlockLeft.Drop += pokemonFusion_Drop;
			this.laboratory.UpgradeBlockLeft.AllowDrop = true;

			this.laboratory.UpgradeBlockRight.DragLeave += seed_DragLeave;
			this.laboratory.UpgradeBlockRight.DragEnter += seed_DragEnter;
			this.laboratory.UpgradeBlockRight.Drop += seedFusion_Drop;
			this.laboratory.UpgradeBlockRight.AllowDrop = true;

			(Window.Current.Content as Frame).Navigating += this.onChangingFrame;
		}

		private void onChangingFrame(object sender, NavigatingCancelEventArgs e)
		{
			this.laboratory.FusionBlockLeft.DragLeave -= seed_DragLeave;
			this.laboratory.FusionBlockLeft.DragEnter -= seed_DragEnter;
			this.laboratory.FusionBlockLeft.Drop -= seedLeft_Drop;

			this.laboratory.FusionBlockRight.DragLeave -= seed_DragLeave;
			this.laboratory.FusionBlockRight.DragEnter -= seed_DragEnter;
			this.laboratory.FusionBlockRight.Drop -= seedRight_Drop;

			this.laboratory.FusionBtn.Tapped -= FusionBtn_Tapped;

			this.laboratory.UpgradeBlockLeft.DragLeave -= pokemon_DragLeave;
			this.laboratory.UpgradeBlockLeft.DragEnter -= pokemon_DragEnter;
			this.laboratory.UpgradeBlockLeft.Drop -= pokemonFusion_Drop;

			this.laboratory.UpgradeBlockRight.DragLeave -= seed_DragLeave;
			this.laboratory.UpgradeBlockRight.DragEnter -= seed_DragEnter;
			this.laboratory.UpgradeBlockRight.Drop -= seedFusion_Drop;

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;
		}

		private async void FusionBtn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
		{
			MarketSeed seedLeft = this.laboratory.FusionSeedBlockLeft.DataContext as MarketSeed;
			MarketSeed seedRight = this.laboratory.FusionSeedBlockRight.DataContext as MarketSeed;
			if (seedLeft != null && seedRight != null)
			{
				List<ElementType> types = new List<ElementType>();
				types.Add(getOneType(seedRight.GetUriTypeList));
				types.Add(getOneType(seedLeft.GetUriTypeList));
				if ((int)types[0] == (int)types[1])
				{
					types.RemoveAt(1);
				}
				MarketSeed newSeedRecived = new MarketSeed(seedRight.Name + " " + seedLeft.Name, types, "test fusion", (seedLeft.Price + seedRight.Price) / 2);
				await new SeedRecived(newSeedRecived).ShowAsync();
				Player.GetPlayer().SeedInventory.Add(newSeedRecived);
				this.laboratory.FusionSeedBlockLeft.DataContext = null;
				this.laboratory.FusionSeedBlockRight.DataContext = null;
				Player.GetPlayer().SeedInventory.Remove(seedLeft);
				Player.GetPlayer().SeedInventory.Remove(seedRight);
			}
		}

		private ElementType getOneType(List<Types> types)
		{
			List<ElementType> typeList = new List<ElementType>();

			foreach (Types type in types)
			{
				typeList.Add(type.ElementType);
			}

			return getOneType(typeList);
		}

		private ElementType getOneType(List<ElementType> types)
		{
			if (types.Count > 0)
			{
				return types[this.random.Next(types.Count)];
			}
			else
			{
				throw new ArgumentException("void list recieved");
			}
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
			updateItemContent(seed as MarketSeed, this.laboratory.FusionSeedBlockLeft);
		}

		private void seedRight_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			updateItemContent(seed as MarketSeed, this.laboratory.FusionSeedBlockRight);
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

		/// <summary>
		/// update content, lock current item and unlock last
		/// </summary>
		/// <param name="item">new item to update</param>
		/// <param name="userControlToUpdate">dataContext target to update</param>
		/// <returns>dataContext updated and not null</returns>
		private void updateItemContent<T>(T item, UserControl userControlToUpdate) where T : class, ILockable
		{
			if (item != null)
			{
				unlockItemIfExist(userControlToUpdate.DataContext as T); // unlock last seed

				userControlToUpdate.DataContext = item; // replace last seed on dataContext

				if (userControlToUpdate.DataContext != null)
				{
					lockItemIfExist(item as T);
				}
			}
		}

		/// <summary>
		/// unlock item
		/// </summary>
		/// <param name="item">item to unlock</param>
		private void unlockItemIfExist<T>(T item) where T : ILockable
		{
			if (item != null)
			{
				item.IsEnable = true;
			}
		}

		/// <summary>
		/// lock item (used to prevent twice using of it)
		/// </summary>
		/// <param name="item">item to lock</param>
		private void lockItemIfExist<T>(T item) where T : ILockable
		{
			if (item != null)
			{
				item.IsEnable = false;
			}
		}
	}
}