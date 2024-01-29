using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    public class Map
    {
        private readonly int _width;
        private readonly int _height;
        public Dictionary<Vector2, LocationAction> ActionLocations;
        public Map(int width, int height, Dictionary<Vector2, LocationAction> actionLocations)
        {
            _width = width;
            _height = height;
            ActionLocations = actionLocations;
        }

        //Check Boundaries
        public bool IsLocationValid(Vector2 coord) =>
            coord.X >= 0 && coord.X < _width && coord.Y >= 0 && coord.Y < _height;
        
        
        
    }
}
