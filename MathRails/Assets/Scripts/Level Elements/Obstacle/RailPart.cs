using System;
using Player;
using Stick;
using UnityEngine;

namespace Level_Elements.Obstacle
{
    public class RailPart : MonoBehaviour
    {
        [SerializeField] private RailCollider RailCol;
        private void OnCollisionEnter(Collision collision)
        {
            collision.collider.TryGetComponent(out StickCollider stick);
            if (stick)
            {
                RailCol.RailCollisionCount++;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            other.collider.TryGetComponent(out StickCollider stick);
            if (stick)
            {
                RailCol.RailCollisionCount--;
            }
        }
    }
}