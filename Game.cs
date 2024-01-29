using RiddlerRoom;
using System.IO;
using System.Numerics;

namespace RiddlerRoom
{
    public class Game
    {
        private bool _isAnsweredBefore = false;
        private GameState _state;
        private bool _gameRunning;
        private ConsoleKeyInfo? _playerInput;

        #region METHODS

        #region Initialization

        public void StartGame(Game gameInstanceReference)
        {
            _gameRunning = true;
            _isAnsweredBefore = false;
            Console.WriteLine(GameConstants.INTRO);
            InitializeGameState();
            StartGameLoop();
            
        }
        //Initialize actions (3 clues and 1 NPC)
        private void InitializeGameState()
        {

            var actionLocations = new Dictionary<Vector2, LocationAction>
            {
                //First Clue
                {
                    GameConstants.PAPER_LOCATION,
                    ClueLocationActionFactory.InitClueAction(
                        GameConstants.FIRST_CLUE_MESSAGE,
                        null,
                        Item.PAPER_NOTE,
                        GameConstants.PAPER_LOCATION,
                        ""
                    )
                },

                //Second Clue
                {
                    GameConstants.BOOKSHELF_LOCATION,
                    ClueLocationActionFactory.InitClueAction(
                        GameConstants.SECOND_CLUE_MESSAGE,
                        Item.PAPER_NOTE,
                        Item.KEY,
                        GameConstants.BOOKSHELF_LOCATION,
                        GameConstants.SECOND_CLUE_NEGATIVE_MESSAGE
                    )
                },

                //Solution Item
                {
                    GameConstants.CASE_LOCATION,
                    ClueLocationActionFactory.InitClueAction(
                        GameConstants.LAST_CLUE_MESSAGE,
                        Item.KEY,
                        Item.CLOCK,
                        GameConstants.CASE_LOCATION,
                        GameConstants.LAST_CLUE_NEGATIVE_MESSAGE
                    )
                },
                
                //NPC
                {
                    GameConstants.NPC_LOCATION,
                    new LocationAction(
                        GameConstants.QUESTION +"\nPress E to see answers",
                        (GameState state) =>
                        {
                            Console.WriteLine("(Press other keys to not answer)");
                            Console.WriteLine("Answers:\n1. Ocean\n2. Universe\n3. Earth\n4. War\n5. Sand");

                            //If player has the last item, show the correct answer
                            if (state.Player.Items.Contains(Item.CLOCK))
                                Console.WriteLine("6. Time");

                            switch (GetInput())
                            {
                                //Correct Answer (Only accessible if last item is found)
                                case ConsoleKey.D6:
                                case ConsoleKey.NumPad6:
                                    if (state.Player.Items.Contains(Item.CLOCK))
                                    {
                                        Console.WriteLine("NPC: Congrulations, Correct Answer, You are free to go! ");
                                        EndGame();
                                    }
                                    break;

                                //Wrong answers
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D4:
                                case ConsoleKey.NumPad4:
                                case ConsoleKey.D5:
                                case ConsoleKey.NumPad5:
                                    if (_isAnsweredBefore)
                                    {
                                        Console.WriteLine("NPC: You are wrong! I dont want to be in the same room with you!");
                                        Console.WriteLine("You died.");
                                        EndGame();
                                    }
                                    else
                                    {
                                        Console.WriteLine("NPC: You are wrong! Your other try will be your last try!");
                                        _isAnsweredBefore = true;
                                    }
                                    break;
                                //Other keys: dont answer
                                default:
                                    break;
                            }
                        }
                    )
                },

            };

            //Initialize game state
            _state = new GameState
            {
                Map = new Map(GameConstants.DEFAULT_MAP_WIDTH, GameConstants.DEFAULT_MAP_HEIGHT, actionLocations),
                Player = new Player { CurrentLocation = Vector2.Zero, Items = new HashSet<Item>() }
            };
        }

        #endregion

        #region Game Loop

        private void StartGameLoop()
        {
            while (_gameRunning)
            {
                PrintCurrentState();
                GetInput();
                Console.Clear();
                ProcessInput();
                

            }
        }

        //Inform user about current state (position and items)
        private void PrintCurrentState()
        {
            Console.WriteLine($"---|Current Location: ({_state.Player.CurrentLocation.X + "," + _state.Player.CurrentLocation.Y}), Current Items: [{string.Join(", ", _state.Player.Items.ToList().Select(x => x.ToString()))}]|---");
            _state.Inspect();
        }

        private ConsoleKey GetInput()
        {
            Console.Write("\n---\nPress a key: ");
            _playerInput = Console.ReadKey();
            Console.WriteLine("\n---\n");
            return _playerInput.Value.Key;
        }


        private void ProcessInput()
        {
            if (!_playerInput.HasValue)
            {
                Console.WriteLine("Invalid Key!");
                return;
            }

            switch (_playerInput.Value.Key)
            {
                case ConsoleKey.W:
                    _state.MovePlayer(new Vector2(0,1));
                    break;
                case ConsoleKey.S:
                    _state.MovePlayer(new Vector2(0, -1));
                    break;
                case ConsoleKey.A:
                    _state.MovePlayer(new Vector2(-1, 0));
                    break;
                case ConsoleKey.D:
                    _state.MovePlayer(new Vector2(1, 0));
                    break;
                case ConsoleKey.E:
                    _state.Interact();
                    break;
                case ConsoleKey.H:
                    Console.WriteLine(GameConstants.HELP_MESSAGE);
                    break;
                case ConsoleKey.Escape:
                    _gameRunning = false;
                    break;
                default:
                    Console.WriteLine("Unrecognized command. Please press 'H' for a list of available commands");
                    break;
            }
        }
        private void EndGame()
        {
            Console.WriteLine("Game Over");
            _gameRunning = false;
        }

        #endregion

        #endregion
    }
}