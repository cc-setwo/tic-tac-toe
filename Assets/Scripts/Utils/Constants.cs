using UnityEngine;

namespace TTT.Utils
{
    public static class Constants
    {
        //Ui
        public const string UI_MANAGER_KEY = "UiManager";
        public const string UI_CANVAS_KEY = "UiCanvas";
        public const string UI_EVENT_SYSTEM_KEY = "UiEventSystem";
        public const string FINISH_POPUP_DRAW_TEXT = "Draw!";
        public const string FINISH_POPUP_WIN_TEXT = "Congrats, to {0} team!";

        //Scenes
        public const string SCENE_INIT_NAME = "Init";
        public const string SCENE_MENU_NAME = "MainMenu";
        public const string SCENE_GAME_NAME = "GameScene";

        //Win highlight
        public const int WIN_POSITIONS_REQUIRED = 2;
        public const int WIN_LAYER_ORDER = 5;
        public const float WIN_ANIMATION_DURATION = 1.5f;
        public const float WIN_WIDTH = 0.25f;
        public static readonly Color WIN_START_COLOR = Color.blue;
        public static readonly Color WIN_END_COLOR = Color.yellow;

        //Game
        public const int BOARD_SIZE = 3;
        public static int CELLS_AMOUNT => BOARD_SIZE * BOARD_SIZE;
        public const string PLAYER1_PREFAB = "Cross";
        public const string PLAYER2_PREFAB = "Circle";
        
        //https://mathworld.wolfram.com/MagicSquare.html
        public static readonly int[] MAGIC_SQUARE = { 4, 9, 2, 3, 5, 7, 8, 1, 6 };
        public static int MAGIC_SQUARE_SUM
        {
            get
            {
                var sum = 0;

                for (var i = 0; i < BOARD_SIZE; i++)
                {
                    sum += MAGIC_SQUARE[i];
                }

                return sum;
            }
        }
    }
}