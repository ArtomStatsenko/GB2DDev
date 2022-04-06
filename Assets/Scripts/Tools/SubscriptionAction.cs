using System;

namespace Tools
{
    internal class SubscriptionAction : IReadOnlySubscriptionAction
    {
        private Action _action;

        public void SubscribeOnChange(Action subscritionAction)
        {
            _action += subscritionAction;
        }

        public void UnsbscriptionOnChange(Action unsubscriptionAction)
        {
            _action -= unsubscriptionAction;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }
    }
}