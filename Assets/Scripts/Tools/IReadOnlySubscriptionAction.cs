using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscritionAction);

        void UnsbscriptionOnChange(Action unsubscriptionAction);
    }
}