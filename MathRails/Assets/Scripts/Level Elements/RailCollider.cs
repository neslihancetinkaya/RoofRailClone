using System;
using Player;
using Stick;
using UnityEngine;
using Utils.Event;

namespace Level_Elements
{
    public class RailCollider : MonoBehaviour
    {
        public Transform LeftRail;
        public Transform RightRail;
        public int RailCollisionCount;

        
        private bool _isLevelFailed;
        [SerializeField] private GameEvent LevelFailed;
        public bool IsEndRail;


        private void OnTriggerStay(Collider other)
        {
            if (IsEndRail)
                return;
            other.TryGetComponent(out StickCollider stick);
            if (stick)
            {
                if (RailCollisionCount < 2)
                {
                    if (!_isLevelFailed)
                    {
                        _isLevelFailed = true;
                        LevelFailed.Raise();
                        stick.gameObject.SetActive(false);
                    }
                } 
            } 
        }
    }
}