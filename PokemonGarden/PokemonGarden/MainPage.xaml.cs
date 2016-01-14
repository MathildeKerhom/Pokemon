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
                    if (Grid.GetColumn(this.me) != 0)
                    {
                        Grid.SetColumn(this.me, Grid.GetColumn(this.me) - 1);
                    }
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.D:
                    if (Grid.GetColumn(this.me) != 9)
                    {
                        Grid.SetColumn(this.me, Grid.GetColumn(this.me) + 1);
                    }
                    break;
                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.Z:
                    if (Grid.GetRow(this.me) != 0)
                    {
                        Grid.SetRow(this.me, Grid.GetRow(this.me) - 1);
                    }
                    break;
                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.S:
                    if (Grid.GetRow(this.me) != 9)
                    {
                        Grid.SetRow(this.me, Grid.GetRow(this.me) + 1);
                    }
                    break;
            }

            if ((Grid.GetColumn(this.me) == 0 || Grid.GetColumn(this.me) == 1)
                && (Grid.GetRow(this.me) == 0 || Grid.GetRow(this.me) == 1))
            {
                (Window.Current.Content as Frame).Navigate(typeof(Market));
            }

            if ((Grid.GetColumn(this.me) == 3 || Grid.GetColumn(this.me) == 4)
                && (Grid.GetRow(this.me) == 2 || Grid.GetRow(this.me) == 3 || Grid.GetRow(this.me) == 4))
            {
                (Window.Current.Content as Frame).Navigate(typeof(Garden));
            }

            if (Grid.GetColumn(this.me) == 8 && (Grid.GetRow(this.me) == 4 || Grid.GetRow(this.me) == 5))
            {
                (Window.Current.Content as Frame).Navigate(typeof(Laboratory));
            }

            if (Grid.GetColumn(this.me) == 2 && Grid.GetRow(this.me) == 8)
            {
                //TODO when Arena is defined
                //(Window.Current.Content as Frame).Navigate(typeof(Arena));
            }
        }

        private void market_Click(object sender, RoutedEventArgs e)
        {

        }

        private void market_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(Garden));
        }
    }
}
