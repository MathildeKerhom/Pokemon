using PokemonGarden.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokemonGarden
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class MainPage:Page
	{
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.Content.KeyDown += Content_KeyDown;
        }

        private void Content_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.Q:
                    Grid.SetColumn(this.me, Grid.GetColumn(this.me) - 1);
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.D:
                    Grid.SetColumn(this.me, Grid.GetColumn(this.me) + 1);
                    break;
                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.Z:
                    Grid.SetRow(this.me, Grid.GetRow(this.me) - 1);
                    break;
                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.S:
                    Grid.SetRow(this.me, Grid.GetRow(this.me) + 1);
                    break;
            }
        }

        private void me_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.Q:
                    Grid.SetRow(this.me, Grid.GetRow(this.me) - 1);
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.D:
                    Grid.SetRow(this.me, Grid.GetRow(this.me) + 1);
                    break;
                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.Z:
                    Grid.SetColumn(this.me, Grid.GetColumn(this.me) + 1);
                    break;
                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.S:
                    Grid.SetColumn(this.me, Grid.GetColumn(this.me) - 1);
                    break;
            }
        }

        private void market_Click(object sender, RoutedEventArgs e)
        {

        }

        private void market_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
