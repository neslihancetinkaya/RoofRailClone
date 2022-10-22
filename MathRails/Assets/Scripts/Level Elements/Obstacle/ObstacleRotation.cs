using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Level_Elements.Obstacle
{
    public class ObstacleRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 RotationVector = new Vector3(0, 0, 1);

        private void Update()
        {
            transform.Rotate(RotationVector * Time.deltaTime);
        }

    }
}