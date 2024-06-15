using System.Collections.Generic;

namespace TTT.Events
{
    public class EventManager
    {
        private readonly List<IEventSubscriberBase> _subscribers = new();

        public void Subscribe(IEventSubscriberBase eventSubscriber)
        {
            if (!_subscribers.Contains(eventSubscriber))
            {
                _subscribers.Add(eventSubscriber);
            }
        }

        public void UnSubscribe(IEventSubscriberBase eventSubscriber)
        {
            _subscribers.Remove(eventSubscriber);
        }

        public void Broadcast<T>(T eventData) where T : IEvent
        {
            for (var i = 0; i < _subscribers.Count; i++)
            {
                if (_subscribers[i] is IEventSubscriber<T> eventToBroadCast)
                {
                    eventToBroadCast.OnEvent(eventData);
                }
            }
        }
    }
}