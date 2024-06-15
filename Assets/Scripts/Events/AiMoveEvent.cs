namespace TTT.Events
{
    public class AiMoveEvent : IEvent
    {
        public int IndexOfCell { get; }

        public AiMoveEvent(int indexOfCell)
        {
            IndexOfCell = indexOfCell;
        }
    }
}