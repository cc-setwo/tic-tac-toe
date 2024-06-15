using System;

namespace TTT.States
{
    public abstract class State
    {
        public Guid Id { get; } = Guid.NewGuid();

        public abstract bool IsStateActive();

        public virtual void OnStateEnter()
        {
        }

        public virtual void OnStateExit()
        {
        }
    }
}