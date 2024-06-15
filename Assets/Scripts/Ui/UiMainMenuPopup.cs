using TTT.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace TTT.Ui
{
    public class UiMainMenuPopup : UiPopupBase
    {
        [SerializeField] private Button _singlePlayerButton;
        [SerializeField] private Button _multiPlayerButton;

        public override void OnPopupShow()
        {
            _singlePlayerButton.onClick.AddListener(() => OnGameModeSelected(true));
            _multiPlayerButton.onClick.AddListener(() => OnGameModeSelected(false));
        }

        private void OnGameModeSelected(bool isAi)
        {
            TTTCore.Instance.CommandExecutor.ExecuteCommand(new GameConfigSetAiCommand(isAi));
            HidePopup();
        }
    }
}