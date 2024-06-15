using System.Collections.Generic;
using TTT.States.StatesProviders;
using UnityEngine;

namespace TTT.States
{
    public class StateMachine
    {
        private readonly List<StateTransition> _transitions;
        private State _currentState;

        public StateMachine(IStatesProvider statesProvider)
        {
            _transitions = statesProvider.GetStates();
            _currentState = _transitions[0].From;
            _currentState.OnStateEnter();
        }

        public void OnUpdate()
        {
            for (var i = 0; i < _transitions.Count; i++)
            {
                if (_transitions[i].From.Id == _currentState.Id && _transitions[i].CanExit())
                {
                    _currentState.OnStateExit();
                    _currentState = _transitions[i].To;
                    _currentState.OnStateEnter();
                    
                    Debug.Log($"[StateMachine] OnUpdate -> state: {_currentState.GetType()} entered");
                }
            }
        }
    }
}