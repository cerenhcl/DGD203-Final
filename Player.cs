using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    public class Player
    {
        public Vector2 CurrentLocation { get; set; }
        public HashSet<Item> Items{ get; set; }
    }
}
