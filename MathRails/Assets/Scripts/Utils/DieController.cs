using System;
using Player;
using UnityEngine;
using Utils.Event;

namespace Utils
{
    public class DieController : MonoBehaviour
    {
        [SerializeField] private GameEvent LevelFailed;

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider playerCollider);
            if (playerCollider)
            {
                LevelFailed.Raise();
            }
        }
    }
}