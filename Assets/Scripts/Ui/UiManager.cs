using System.Collections.Generic;
using System.Threading.Tasks;
using TTT.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TTT.Ui
{
     public class UiManager
    {
        private GameObject _uiManagerRoot;
        private GameObject _canvas;
        
        private List<UiPopupBase> _openedPopups;

        public UiManager()
        {
            _openedPopups = new List<UiPopupBase>();
            _uiManagerRoot = new GameObject(Constants.UI_MANAGER_KEY);
            Object.DontDestroyOnLoad(_uiManagerRoot);

            var loadedCanvas = LoadAssetSync<GameObject>(Constants.UI_CANVAS_KEY);
            var loadedEventSystem = LoadAssetSync<GameObject>(Constants.UI_EVENT_SYSTEM_KEY);
            
            _canvas = Object.Instantiate(loadedCanvas, _uiManagerRoot.transform);
            Object.Instantiate(loadedEventSystem, _uiManagerRoot.transform);
        }

        public async Task<T> GetOrShowPopup<T>() where T : UiPopupBase
        {
            var existingPopup = _openedPopups.Find(a => a is T);

            if (existingPopup != null)
            {
                return (T) existingPopup;
            }
            
            var popupNameToSpawn = typeof(T).Name;
            var loadOperation = Addressables.LoadAssetAsync<Object>(popupNameToSpawn);
            var popupObj = await loadOperation.Task;

            if (popupObj is not GameObject popupGameObj)
            {
                Debug.LogError("[UiManager] ShowPopup -> Unable to find popup: " + popupNameToSpawn);
                return null;
            }

            var popup = popupGameObj.GetComponent<T>();

            var popupInstance = Object.Instantiate(popup, _canvas.transform);
            
            _openedPopups.Add(popupInstance);
            popupInstance.OnPopupShow();

            for (var i = 0; i < _openedPopups.Count; i++)
            {
                _openedPopups[i].transform.SetSiblingIndex(_openedPopups[i].Priority);
            }
            
            Debug.Log("[UiManager] ShowPopup -> Showing popup: " + popupNameToSpawn);
            return popupInstance;
        }

        public bool IsPopupOpened<T>() where T : UiPopupBase
        {
            return _openedPopups.Exists(a => a is T);
        }

        public void HidePopup(UiPopupBase popupToHide)
        {
            Debug.Log("[UiManager] HidePopup -> Hiding popup: " + popupToHide.name);
            _openedPopups.Remove(popupToHide);
            Object.Destroy(popupToHide.gameObject);
        }
        
        private T LoadAssetSync<T>(string prefabName) where T : Object
        {
            var loadOperation = Addressables.LoadAssetAsync<T>(prefabName);
            loadOperation.WaitForCompletion();
            
            return loadOperation.Result;
        }
    }
}