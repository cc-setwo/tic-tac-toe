using System;
using UnityEngine;

namespace TTT.Ui
{
    public abstract class UiPopupBase : MonoBehaviour
    {
        public int Priority => 0;

        private Action _closeCallback;
        
        public virtual void OnPopupShow()
        {
        }

        public void SetCloseCallback(Action closeCallback)
        {
            _closeCallback = closeCallback;
        }

        protected void HidePopup()
        {
            TTTCore.Instance.UiManager.HidePopup(this);
            _closeCallback?.Invoke();
        }
    }
}