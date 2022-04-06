using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }

        void SubscribeOnChange(Action<T> subscritionAction);

        void UnsbscriptionOnChange(Action<T> unsubscriptionAction);
    }
}