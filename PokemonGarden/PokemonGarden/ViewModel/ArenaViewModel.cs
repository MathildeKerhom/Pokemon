﻿using PokemonGarden.Classes;
using PokemonGarden.View;
using PokemonGarden.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace PokemonGarden.ViewModel
{
    class ArenaViewModel
    {
        private Arena arena;

        public ArenaViewModel(Arena arena)
        {
            this.arena = arena;
            this.init();
            this.bind();
        }

        private void init()
        {
            this.arena.PokemonAI.DataContext = new Pokemon(new Uri("ms-appx:///Assets/pika.PNG"), "pika", new List<Types.Element> { Types.Element.Electrique }, "fidel pokemon qui nous suit partout", "Transparent");
            this.arena.Pokemon1.DataContext = new Pokemon(new Uri("ms-appx:///Assets/para.jpg"), "para", new List<Types.Element> { Types.Element.Insecte, Types.Element.Plante }, "pokemon qui ressemble à un crabe");
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
    }
}
