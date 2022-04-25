using Tools;
using UnityEngine;

namespace Game
{
    internal class BackgroundView : MonoBehaviour
    {
        [SerializeField]
        private Background[] _backgrounds;

        private IReadOnlySubscriptionProperty<float> _diff;
        private float _carSpeed;

        public void Init(IReadOnlySubscriptionProperty<float> diff, float carSpeed)
        {
            _diff = diff;
            _carSpeed = carSpeed;
            _diff.SubscribeOnChange(Move);
        }

        protected void OnDestroy()
        {
            _diff?.UnsubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (var background in _backgrounds)
            {
                background.Move(-value * _carSpeed);
            }
        }
    }
}