using System.Collections.Generic;

namespace TTT.States.StatesProviders
{
    public interface IStatesProvider
    {
        public List<StateTransition> GetStates();
    }
}