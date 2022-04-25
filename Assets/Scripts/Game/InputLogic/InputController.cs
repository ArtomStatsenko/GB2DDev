using JoostenProductions;
using Tools;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal class InputController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MobileSingleStickControl" };
        private readonly SubscriptionProperty<float> _movement;
        private BaseInputView _view;

        public InputController(SubscriptionProperty<float> movement)
        {
            _movement = movement;
            _view = CreateView();
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }

        private BaseInputView CreateView()
        {
            GameObject viewObject = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(viewObject);
            return viewObject.GetComponent<BaseInputView>();
        }

        private void OnUpdate()
        {
            _movement.Value = CrossPlatformInputManager.GetAxis("Horizontal");
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        }
    }
}