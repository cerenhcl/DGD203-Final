using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RiddlerRoom
{
    public class GameConstants
    {
        public static readonly string QUESTION = @"
------------------------- RIDDLER -----------------------------
Hello traveler. If you want to leave this room alive, you must solve my riddle!

It has a beginning, it has an end,
Sometimes it flows slowly, sometimes it flows fast.
Everyone uses it, but no one can keep it,
Everyone measures it, but no one can see it.
----------------------------------------------------------------";
        public static readonly string INTRO = "You: Where am i? What is this room? It is so dark i cannot see anything. (Press H for key bindings)";
        public static readonly string HELP_MESSAGE = @"Key Bindings:
W: Move North
A: Move West
S: Move South
D: Move Right
E: Interact
H: Help
Esc: Exit Game";
        public static readonly string FIRST_CLUE_MESSAGE = "You saw a paper on the wall.\n'Check the bookshelf for a key between these books: ...'. Press E to store the paper";
        public static readonly string FIRST_CLUE_NEGATIVE_MESSAGE = "";
        public static readonly string SECOND_CLUE_MESSAGE = "You found a bookshelf. Press E to Interact";
        public static readonly string SECOND_CLUE_NEGATIVE_MESSAGE = "You dont know what to do... Search room for a clue";
        public static readonly string LAST_CLUE_MESSAGE = "You found a case! Press E to Interact";
        public static readonly string LAST_CLUE_NEGATIVE_MESSAGE = "\nCase is locked.";

        public static readonly int DEFAULT_MAP_WIDTH = 5;
        public static readonly int DEFAULT_MAP_HEIGHT = 5;
        public static readonly Vector2 PAPER_LOCATION = Vector2.One;
        private static readonly Vector2 vector2 = new(3, 3);
        public static readonly Vector2 BOOKSHELF_LOCATION = vector2;
        public static readonly Vector2 CASE_LOCATION = new(3, 0);
        public static readonly Vector2 NPC_LOCATION = new(0, 0);

        
    }
}
