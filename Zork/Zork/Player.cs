﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    public class Player
    {
        public int Moves { get; set; }
        public World World { get; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]
        public string LocationName 
        {
            get 
            {
                return Location?.Name;
            }
            set 
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }

        public bool Move(Directions directions) 
        {
            bool isValidMove = Location.Neighbors.TryGetValue(directions, out Room destination);
            if (isValidMove) 
            {
                Location = destination;
            }

            return isValidMove;
        }
    }
}
