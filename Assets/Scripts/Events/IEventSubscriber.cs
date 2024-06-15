namespace TTT.Events
{
    public interface IEventSubscriber<in T> : IEventSubscriberBase where T : IEvent
    {
        void OnEvent(T eventData);
    }
}