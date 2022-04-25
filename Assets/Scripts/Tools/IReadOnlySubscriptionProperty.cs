using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }

        void SubscribeOnChange(Action<T> subscritionAction);

        void UnsubscribeOnChange(Action<T> unsubscriptionAction);
    }
}