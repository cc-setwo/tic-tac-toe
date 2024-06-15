using UnityEngine;

namespace TTT.Events
{
    public class OnCellClickedEvent : IEvent
    {
        public Vector2 ClickPos { get; }
        public int IndexOnBoard { get; }

        public OnCellClickedEvent(Vector2 clickPos, int indexOnBoard)
        {
            ClickPos = clickPos;
            IndexOnBoard = indexOnBoard;
        }
    }
}