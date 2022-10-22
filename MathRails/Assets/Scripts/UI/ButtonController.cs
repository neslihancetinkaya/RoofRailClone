using UnityEngine;
using Utils.Event;

namespace UI
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private GameEvent GoToNextLevel;
        [SerializeField] private GameEvent RetryLevel;

        public void OnClicked()
        {
            GoToNextLevel.Raise();
        }
    }
}