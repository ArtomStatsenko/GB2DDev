using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;

        public void Init(UnityAction startGame)
        {
            _startButton.onClick.AddListener(startGame);
        }

        public void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}