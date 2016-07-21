using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using PokemonGarden.Classes;
using PokemonGarden.View;
using PokemonGarden.View.UserControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

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
			this.laboratory.FusionBlockLeft.DragLeave += dragLeaveDisplayAllowInfo;
			this.laboratory.FusionBlockLeft.DragEnter += seed_DragEnterDisplayInfo;
			this.laboratory.FusionBlockLeft.Drop += fusionSeedLeftCell_Drop;
			this.laboratory.FusionBlockLeft.AllowDrop = true;

			this.laboratory.FusionBlockRight.DragLeave += dragLeaveDisplayAllowInfo;
			this.laboratory.FusionBlockRight.DragEnter += seed_DragEnterDisplayInfo;
			this.laboratory.FusionBlockRight.Drop += fusionSeedRightCell_Drop;
			this.laboratory.FusionBlockRight.AllowDrop = true;

			this.laboratory.FusionBtn.Tapped += FusionBtn_Tapped;

			this.laboratory.UpgradeGridBlockLeft.DragLeave += dragLeaveDisplayAllowInfo;
			this.laboratory.UpgradeGridBlockLeft.DragEnter += pokemon_DragEnterDisplayInfo;
			this.laboratory.UpgradeGridBlockLeft.Drop += upgradePokemonCell_Drop;
			this.laboratory.UpgradeGridBlockLeft.AllowDrop = true;

			this.laboratory.UpgradeGridBlockRight.DragLeave += dragLeaveDisplayAllowInfo;
			this.laboratory.UpgradeGridBlockRight.DragEnter += seed_DragEnterDisplayInfo;
			this.laboratory.UpgradeGridBlockRight.Drop += upgradeSeedCell_Drop;
			this.laboratory.UpgradeGridBlockRight.AllowDrop = true;

			this.laboratory.UpgradeBtn.Tapped += UpgradeBtn_Tapped;

			this.laboratory.Pivot.SelectionChanged += Pivot_SelectionChanged;

			(Window.Current.Content as Frame).Navigating += this.onChangingFrame;
		}

		private void onChangingFrame(object sender, NavigatingCancelEventArgs e)
		{
			this.laboratory.FusionBlockLeft.DragLeave -= dragLeaveDisplayAllowInfo;
			this.laboratory.FusionBlockLeft.DragEnter -= seed_DragEnterDisplayInfo;
			this.laboratory.FusionBlockLeft.Drop -= fusionSeedLeftCell_Drop;

			this.laboratory.FusionBlockRight.DragLeave -= dragLeaveDisplayAllowInfo;
			this.laboratory.FusionBlockRight.DragEnter -= seed_DragEnterDisplayInfo;
			this.laboratory.FusionBlockRight.Drop -= fusionSeedRightCell_Drop;

			this.laboratory.FusionBtn.Tapped -= FusionBtn_Tapped;

			this.laboratory.UpgradeGridBlockLeft.DragLeave -= dragLeaveDisplayAllowInfo;
			this.laboratory.UpgradeGridBlockLeft.DragEnter -= pokemon_DragEnterDisplayInfo;
			this.laboratory.UpgradeGridBlockLeft.Drop -= upgradePokemonCell_Drop;

			this.laboratory.UpgradeGridBlockRight.DragLeave -= dragLeaveDisplayAllowInfo;
			this.laboratory.UpgradeGridBlockRight.DragEnter -= seed_DragEnterDisplayInfo;
			this.laboratory.UpgradeGridBlockRight.Drop -= upgradeSeedCell_Drop;

			this.laboratory.UpgradeBtn.Tapped -= UpgradeBtn_Tapped;

			this.laboratory.Pivot.SelectionChanged -= Pivot_SelectionChanged;

			this.unlockItemIfExist(this.laboratory.UpgradeSeed.DataContext as MarketSeed);
			this.unlockItemIfExist(this.laboratory.UpgradePokemon.DataContext as Pokemon);
			this.unlockItemIfExist(this.laboratory.FusionSeedBlockLeft.DataContext as MarketSeed);
			this.unlockItemIfExist(this.laboratory.FusionSeedBlockRight.DataContext as MarketSeed);

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;
		}

		/// <summary>
		/// do the fusion on button clic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void FusionBtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			MarketSeed seedLeft = this.laboratory.FusionSeedBlockLeft.DataContext as MarketSeed;
			MarketSeed seedRight = this.laboratory.FusionSeedBlockRight.DataContext as MarketSeed;
			if (seedLeft != null && seedRight != null)
			{
				List<ElementType> types = new List<ElementType>();
				types.Add(Types.GetOneType(seedRight.GetUriTypeList));
				types.Add(Types.GetOneType(seedLeft.GetUriTypeList));
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

		/// <summary>
		/// do the upgrade on button clic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void UpgradeBtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Pokemon pokemon = this.laboratory.UpgradePokemon.DataContext as Pokemon;
			MarketSeed seed = this.laboratory.UpgradeSeed.DataContext as MarketSeed;
			if (pokemon != null && seed != null)
			{
				pokemon.Upgrade(seed);
				await new PokemonRecived(pokemon).ShowAsync();
				this.laboratory.UpgradeSeed.DataContext = null;
				Player.GetPlayer().SeedInventory.Remove(seed);
			}
		}

		/// <summary>
		/// signal to the user, can drop seed here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void seed_DragEnterDisplayInfo(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			if (seed != null)
			{
				e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
			}
		}

		/// <summary>
		/// signal to the user, can drop pokemon here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pokemon_DragEnterDisplayInfo(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			if (pokemon != null)
			{
				e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
			}
		}

		/// <summary>
		/// signal to the user, can't move element here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dragLeaveDisplayAllowInfo(object sender, DragEventArgs e)
		{
			e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
		}

		/// <summary>
		/// event on left seed cell droping (fusion tab)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fusionSeedLeftCell_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			updateItemContent(seed as MarketSeed, this.laboratory.FusionSeedBlockLeft);
		}

		/// <summary>
		/// event on right seed cell droping (fusion tab)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fusionSeedRightCell_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			updateItemContent(seed as MarketSeed, this.laboratory.FusionSeedBlockRight);
		}

		/// <summary>
		/// event on seed cell droping (upgrade tab)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void upgradeSeedCell_Drop(object sender, DragEventArgs e)
		{
			object seed;
			e.Data.Properties.TryGetValue("seedSource", out seed);
			updateItemContent(seed as MarketSeed, this.laboratory.UpgradeSeed);
		}

		/// <summary>
		/// event on pokemon cell droping (upgrade tab)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void upgradePokemonCell_Drop(object sender, DragEventArgs e)
		{
			object pokemon;
			e.Data.Properties.TryGetValue("pokemonSource", out pokemon);
			updateItemContent(pokemon as Pokemon, this.laboratory.UpgradePokemon);
		}

		/// <summary>
		/// when pivot tab change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Player player = Player.GetPlayer();
			if (this.laboratory.Pivot.SelectedIndex == 0) // tab create
			{
				this.unlockItemIfExist(this.laboratory.UpgradeSeed.DataContext as MarketSeed);
				this.unlockItemIfExist(this.laboratory.UpgradePokemon.DataContext as Pokemon);
				this.CheckAndLockItemIfExist(this.laboratory.FusionSeedBlockLeft, player.SeedInventory);
				this.CheckAndLockItemIfExist(this.laboratory.FusionSeedBlockRight, player.SeedInventory);
			}
			else // tab upgrade
			{
				this.unlockItemIfExist(this.laboratory.FusionSeedBlockLeft.DataContext as MarketSeed);
				this.unlockItemIfExist(this.laboratory.FusionSeedBlockRight.DataContext as MarketSeed);
				this.CheckAndLockItemIfExist(this.laboratory.UpgradeSeed, player.SeedInventory);
				this.CheckAndLockItemIfExist(this.laboratory.UpgradePokemon, player.PokemonInventory);
			}
		}

		/// <summary>
		/// if userControl datacontext object is contained on list, this object'll be lock
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ItemToCheck"></param>
		/// <param name="compareItemToList"></param>
		/// <param name="userControlToCheck"></param>
		private void CheckAndLockItemIfExist<T>(UserControl userControlToCheck, ObservableCollection<T> compareItemToList) where T : class, ILockable
		{
			if (compareItemToList != null && userControlToCheck != null)
			{
				T itemToCheck = userControlToCheck.DataContext as T;
				if (itemToCheck != null)
				{
					if (compareItemToList.Contains(itemToCheck))
					{
						lockItemIfExist(itemToCheck);
					}
					else
					{
						userControlToCheck.DataContext = null;
					}
				} 
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