using Tools;
using UnityEngine;

namespace Profile
{
    internal class CarController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };
        private CarView _view;

        public CarController()
        {
            _view = CreateView();
        }

        private CarView CreateView()
        {
            GameObject view = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(view);
            return view.GetComponent<CarView>();
        }
    }
}