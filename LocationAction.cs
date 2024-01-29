using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    /*
    1. İpucu olabilir (otomatik alınır)
    2. Aksiyonu gerçekleştirmek için item gerekliğiği olabilir

     */
    public class LocationAction
    {
        private string _locationActionDesc;
        private Action<GameState> _locationAction;
        public LocationAction(string locationActionDesc, Action<GameState> locationAction)
        {
            _locationActionDesc = locationActionDesc;
            _locationAction = locationAction;
        }
        public void Inspect()
        {
            Console.WriteLine(_locationActionDesc);

        }
        public void Act(ref GameState gameState)
        {
            _locationAction?.Invoke(gameState);
        }
    }
}
