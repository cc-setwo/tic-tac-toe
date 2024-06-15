using TTT.Events;
using UnityEngine;

namespace TTT.Utils
{
    public class CellClickHandler : MonoBehaviour, IEventSubscriber<AiMoveEvent>, IEventSubscriber<WinHighlightEvent>
    {
        [SerializeField] private int _indexOnBoard;
        
        public void OnMouseDown()
        {
            TTTCore.Instance.EventManager.Broadcast(new OnCellClickedEvent(transform.position, _indexOnBoard));
        }

        public void OnEvent(AiMoveEvent eventData)
        {
            if (_indexOnBoard == eventData.IndexOfCell)
            {
                OnMouseDown();
            }
        }

        public void OnEvent(WinHighlightEvent eventData)
        {
            if (eventData.WinIndexes.Contains(_indexOnBoard))
            {
                eventData.WinWorldPositions.Add(transform.position);
            }
        }

        private void Start()
        {
            TTTCore.Instance.EventManager.Subscribe(this);
        }

        private void OnDestroy()
        {
            if (TTTCore.IsAvailable)
            {
                TTTCore.Instance.EventManager.UnSubscribe(this);
            }
        }
    }
}