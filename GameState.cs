using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    public class GameState
    {
        public Map Map { get; set; }
        public Player Player { get; set; }

        public void Inspect()
        {
            if (Map.ActionLocations.ContainsKey(Player.CurrentLocation))
                Map.ActionLocations[Player.CurrentLocation].Inspect();
            else
                Console.WriteLine("There is nothing here...");
        }

        //Move Player and show message if new location is invalid 
        public void MovePlayer(Vector2 direction)
        {
            var newLocation = Player.CurrentLocation + direction;
            if (!Map.IsLocationValid(newLocation))
            {
                Console.WriteLine("You cannot pass through a wall...");
                return;
            }

            Player.CurrentLocation = newLocation;
        }

        //Interact with action if exists
        public void Interact()
        {
            if (Map.ActionLocations.ContainsKey(Player.CurrentLocation))
            {
                var state = this;
                Map.ActionLocations[Player.CurrentLocation].Act(ref state);
            }
                


        }
    }
}
