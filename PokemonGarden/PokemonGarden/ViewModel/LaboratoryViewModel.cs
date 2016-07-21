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
		private Random random;

		public LaboratoryViewModel(Laboratory laboratory)
		{
			this.laboratory = laboratory;
			this.random = new Random(DateTime.Now.Millisecond);
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

			(Window.Current.Content as Frame).Navigating -= this.onChangingFrame;
		}

		/// <summary>
		/// do the fusion
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

		/// <summary>
		/// do the upgrade
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void UpgradeBtn_Tapped(object sender, TappedRoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// chose a random element into list of types (parent of ElementType)
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		private ElementType getOneType(List<Types> types)
		{
			List<ElementType> typeList = new List<ElementType>();

			foreach (Types type in types)
			{
				typeList.Add(type.ElementType);
			}

			return getOneType(typeList);
		}

		/// <summary>
		/// chose a random element into list of ElementType
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
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
			if (pokemon != null)
			{
				this.laboratory.UpgradePokemon.DataContext = pokemon as Pokemon;
			}
		}

		/// <summary>
		/// when pivot tab change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Player player = Player.GetPlayer();
			if (this.laboratory.Pivot.SelectedIndex == 0) // create tab
			{
				unlockItemIfExist(this.laboratory.UpgradeSeed.DataContext as MarketSeed);
				CheckAndLockItemIfExist(this.laboratory.FusionSeedBlockLeft, player.SeedInventory);
				CheckAndLockItemIfExist(this.laboratory.FusionSeedBlockRight, player.SeedInventory);
			}
			else // upgrade tab
			{
				unlockItemIfExist(this.laboratory.FusionSeedBlockLeft.DataContext as MarketSeed);
				unlockItemIfExist(this.laboratory.FusionSeedBlockRight.DataContext as MarketSeed);
				CheckAndLockItemIfExist(this.laboratory.UpgradeSeed, player.SeedInventory);
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