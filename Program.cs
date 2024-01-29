using RiddlerRoom;
using System;

internal class Program
{

    private static void Main(string[] args)
    {
        Game gameInstance = new Game();
        gameInstance.StartGame(gameInstance);
    }
}
