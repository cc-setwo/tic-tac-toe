using TTT.Commands;
using TTT.Ui;
using TTT.Utils;
using UnityEngine.SceneManagement;

namespace TTT.States
{
    public class MainMenuState : State
    {
        public override async void OnStateEnter()
        {
            var uiMenuPopup = await TTTCore.Instance.UiManager.GetOrShowPopup<UiMainMenuPopup>();
            uiMenuPopup.SetCloseCallback(OnMainMenuClosed);
            TTTCore.Instance.CommandExecutor.ExecuteCommand(new GameConfigInitCellsCommand(Constants.CELLS_AMOUNT));
        }

        public override bool IsStateActive()
        {
            return SceneManager.GetSceneByName(Constants.SCENE_MENU_NAME).isLoaded;
        }

        private void OnMainMenuClosed()
        {
            SceneManager.LoadSceneAsync(Constants.SCENE_GAME_NAME);
        }
    }
}