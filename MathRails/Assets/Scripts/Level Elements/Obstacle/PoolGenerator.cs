using System;
using UnityEngine;

namespace Level_Elements.Obstacle
{
    public class PoolGenerator : MonoBehaviour
    {
        [SerializeField] private BoxCollider Collider;
        [SerializeField] private GameObject LavaCube;
        [SerializeField] private int Length = 1;
        [SerializeField] private Transform Parent;

        private void Awake()
        {
            for (int i = 0; i < Length; i++)
            {
                var newCube = Instantiate(LavaCube);
                newCube.transform.parent = Parent;
                var scale = newCube.transform.localScale;
                newCube.transform.localPosition = new Vector3(0, 0, i * scale.z);
            }
            Collider.size = new Vector3(Collider.size.x, Collider.size.y,Length);
            Collider.center = new Vector3(Collider.center.x, Collider.center.y, Length / 2);
        }

    }
}