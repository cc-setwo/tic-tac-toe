using TTT.Ui;
using TTT.Utils;
using UnityEngine.SceneManagement;

namespace TTT.States
{
    public class GameFinishState : State
    {
        public override bool IsStateActive()
        {
            return TTTCore.Instance.UiManager.IsPopupOpened<UiGameFinishPopup>();
        }

        public override void OnStateEnter()
        {
            SceneManager.LoadSceneAsync(Constants.SCENE_MENU_NAME);
        }
    }
}