using System;
using UnityEngine;
using Utils.Event;

namespace Player
{
    public class SwerveInput : MonoBehaviour
    {
        [SerializeField] private GameEvent StartGame;

        private float _lastXPos;
        private float _moveFactorX;
        private bool _isGameStarted;
        public float MoveFactorX => _moveFactorX;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastXPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!_isGameStarted)
                {
                    _isGameStarted = true;
                    StartGame.Raise();
                }
                _moveFactorX = Input.mousePosition.x - _lastXPos;
                _lastXPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
        }
    }
}