using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    public class ClueLocationActionFactory
    {
        public static LocationAction InitClueAction(string locationActionDesc, Item? requiredItem, Item newItem, Vector2 location, string failInteractText)
        {
            return new LocationAction
            (
                locationActionDesc,
                (GameState state) =>
                {
                    //Check item requirement for action
                    if (!requiredItem.HasValue || state.Player.Items.Contains(requiredItem.Value))
                    {
                        Console.WriteLine($"You acquired {newItem}"); //Item acquired Message
                        state.Player.Items.Add(newItem); //Add Item to player
                        state.Map.ActionLocations.Remove(location); //Remove the action
                    }
                    else
                        Console.WriteLine(failInteractText);
                }
            );
        }
    }
}
