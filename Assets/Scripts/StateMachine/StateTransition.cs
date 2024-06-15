namespace TTT.States
{
    public class StateTransition
    {
        public State From { get; }
        public State To { get; }

        public StateTransition(State from, State to)
        {
            From = from;
            To = to;
        }

        public bool CanExit()
        {
            return !From.IsStateActive() && To.IsStateActive();
        }
    }
}