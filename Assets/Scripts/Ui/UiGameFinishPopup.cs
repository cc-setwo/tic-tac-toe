using TMPro;
using TTT.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace TTT.Ui
{
    public class UiGameFinishPopup : UiPopupBase
    {
        [SerializeField] private TextMeshProUGUI _winnerText;
        [SerializeField] private Button _playAgainButton;

        public void Init(string winner)
        {
            if (string.IsNullOrEmpty(winner))
            {
                _winnerText.text = Constants.FINISH_POPUP_DRAW_TEXT;
            }
            else
            {
                _winnerText.text = string.Format(Constants.FINISH_POPUP_WIN_TEXT, winner);
            }
        }

        public override void OnPopupShow()
        {
            _playAgainButton.onClick.AddListener(HidePopup);
        }
    }
}